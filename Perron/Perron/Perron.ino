#include <TM1637Display.h>

/*------------------------------------------------==||## Defines ##||==------------------------------------------------*/
#define CLK1 2       // Display #1
#define DIO1 4
#define CLK2 7       // Display #2
#define DIO2 8
#define CLK3 12      // Display #3
#define DIO3 13

#define LED1Red 3    // LED strip #1
#define LED1Green 5
#define LED2Red 6    // LED strip #1
#define LED2Green 9
#define LED3Red 10   // LED strip #1
#define LED3Green 11

#define idle 0
#define writeToDisplayState 1
#define writeToLEDStripState 2

/*------------------------------------------------==||## Variables ##||==------------------------------------------------*/
int state = idle;
String displayMessage = "";
String lastDisplayMessage = "";

/*------------------------------------------------==||## Setup ##||==------------------------------------------------*/
TM1637Display display(CLK1, DIO1);

void setup()
{
  pinMode(LED1Red, OUTPUT);
  pinMode(LED1Green, OUTPUT);
  pinMode(LED2Red, OUTPUT);
  pinMode(LED2Green, OUTPUT);
  pinMode(LED3Red, OUTPUT);
  pinMode(LED3Green, OUTPUT);

  Serial.begin(9600);
  display.setBrightness(0x0f);
}

/*------------------------------------------------==||## Loop ##||==------------------------------------------------*/
void loop()
{
  ReadSerial();
  switch (state)
  {
    case idle:
      if (displayMessage != lastDisplayMessage) {
        state = writeToDisplayState;
        Serial.println(displayMessage);
      }
      break;

    case writeToDisplayState:
      if (WriteToDisplay(displayMessage, lastDisplayMessage))
      {
        state = writeToLEDStripState;
      }
      break;

    case writeToLEDStripState:
      lastDisplayMessage = displayMessage;
      Serial.println(lastDisplayMessage);
      state = idle;
      break;
  }
}

/*------------------------------------------------==||## Read Serial ##||==------------------------------------------------*/
void ReadSerial()
{
  static String message = "";
  if (Serial.available() > 0) {
    char readChar = (char) Serial.read();
    message = message + readChar;
    message.trim();
  }
  if (message.startsWith("#") && message.endsWith("%")) {
    message = message.substring(1, message.length() - 1);
    displayMessage = message;
    message = "";
  }
}

/*------------------------------------------------==||## Write Message To Display ##||==------------------------------------------------*/
bool WriteToDisplay(String messageToDisplay, String lastMessageToDisplay)
{
  static int displayNumber = 0;
  int displayText = messageToDisplay.substring((displayNumber * 4), (displayNumber * 4) + 4).toInt();
  display.showNumberDec(displayText, true);
  if ((displayNumber + 1) >= ((messageToDisplay.length() + 1) / 4))
  {
    displayNumber = 0;
    return true;
  }
  else
  {
    displayNumber++;
    return false;
  }
}

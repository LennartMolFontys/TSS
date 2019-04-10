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
#define LED2Red 6    // LED strip #2
#define LED2Green 9
#define LED3Red 10   // LED strip #3
#define LED3Green 11

#define readSerialState 0
#define writeToDisplayState 1
#define writeToLEDStripState 2

/*------------------------------------------------==||## Variables ##||==------------------------------------------------*/
int state = readSerialState;
String displayMessage = "";
String lastDisplayMessage = "";

/*------------------------------------------------==||## Setup ##||==------------------------------------------------*/
TM1637Display display1(CLK1, DIO1);
TM1637Display display2(CLK2, DIO2);
TM1637Display display3(CLK3, DIO3);

void setup()
{
  pinMode(LED1Red, OUTPUT);
  pinMode(LED1Green, OUTPUT);
  pinMode(LED2Red, OUTPUT);
  pinMode(LED2Green, OUTPUT);
  pinMode(LED3Red, OUTPUT);
  pinMode(LED3Green, OUTPUT);

  Serial.begin(9600);
  display1.setBrightness(0x0f);
  display2.setBrightness(0x0f);
  display3.setBrightness(0x0f);
}

/*------------------------------------------------==||## Loop ##||==------------------------------------------------*/
void loop()
{
  ReadSerial();
  switch (state)
  {
    case readSerialState:
      if (displayMessage != lastDisplayMessage) {
        state = writeToDisplayState;
      }
      break;

    case writeToDisplayState:
      if (WriteToDisplay(displayMessage))
      {
        state = writeToLEDStripState;
      }
      break;

    case writeToLEDStripState:
      lastDisplayMessage = displayMessage;
      if (WriteToLEDStrip(displayMessage))
      {
        state = readSerialState;
      }
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
bool WriteToDisplay(String messageToDisplay)
{
  static int displayNumber = 0;
  int displayText = messageToDisplay.substring((displayNumber * 4), (displayNumber * 4) + 4).toInt();
  switch (displayNumber)
  {
    case 0:
      display1.showNumberDec(displayText, true);
      break;

    case 1:
      display2.showNumberDec(displayText, true);
      break;

    case 2:
      display3.showNumberDec(displayText, true);
      break;
  }
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

/*------------------------------------------------==||## Write Message To LED Strip ##||==------------------------------------------------*/
bool WriteToLEDStrip(String messageToDisplay)
{
  static int stripNumber = 0;
  int red = 0;
  int green = 0;
  
  int numberOfSeats = messageToDisplay.substring((stripNumber * 4), (stripNumber * 4) + 4).toInt();
  if(numberOfSeats <= 5)
  {
    red = 255;
    green = 0;
  }
  else if(numberOfSeats <= 20)
  {
    red = 255;
    green = 30;
  }
  else
  {
    red = 0;
    green = 100;
  }
  switch (stripNumber)
  {
    case 0:
      analogWrite(LED1Red, red);
      analogWrite(LED1Green, green);
      break;

    case 1:
      analogWrite(LED2Red, red);
      analogWrite(LED2Green, green);
      break;

    case 2:
      analogWrite(LED3Red, red);
      analogWrite(LED3Green, green);
      break;
  }
  if ((stripNumber + 1) >= ((messageToDisplay.length() + 1) / 4))
  {
    stripNumber = 0;
    return true;
  }
  else
  {
    stripNumber++;
    return false;
  }
}

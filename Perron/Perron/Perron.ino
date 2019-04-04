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

#define readSerialState 0
#define writeToDisplayState 1
#define writeToLEDStripState 2

/*------------------------------------------------==||## Variables ##||==------------------------------------------------*/
int state = readSerialState;
String message = "";

/*------------------------------------------------==||## Setup ##||==------------------------------------------------*/

void setup()
{
  pinMode(LED1Red, OUTPUT);
  pinMode(LED1Green, OUTPUT);
  pinMode(LED2Red, OUTPUT);
  pinMode(LED2Green, OUTPUT);
  pinMode(LED3Red, OUTPUT);
  pinMode(LED3Green, OUTPUT);

  Serial.begin(9600);
}

/*------------------------------------------------==||## Loop ##||==------------------------------------------------*/
void loop()
{
  switch (state)
  {
    case readSerialState:
      ReadSerial();
      break;
  }
}

String ReadSerial()
{
  
}

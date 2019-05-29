#include "Display.h"
#include "Communication.h"
#include "LED_Strip.h"

#define readSerialState 0
#define writeToDisplayState 1
#define writeToLEDStripState 2

#define numberOfDisplays 3

#define LED1Red 3    // LED strip #1
#define LED1Green 5
#define LED2Red 6    // LED strip #2
#define LED2Green 9
#define LED3Red 10   // LED strip #3
#define LED3Green 11

int ledPinArray[] = {LED1Red, LED1Green, LED2Red, LED2Green, LED3Red, LED3Green};
int* ledPinArrayPtr = ledPinArray;

int state = readSerialState;
String lastDisplayMessage = "";
String message = "";

void setup()
{
  SetUpLedStrip(ledPinArrayPtr, numberOfDisplays);
  SetUpSerial();
  SetUpDisplay();
}

void loop()
{
  switch (state)
  {
    case readSerialState:
      message = ReadSerial();
      if (message != lastDisplayMessage && message != "") {
        state = writeToDisplayState;
      }
      break;

    case writeToDisplayState:
      if (WriteToDisplay(message))
      {
        state = writeToLEDStripState;
      }
      break;

    case writeToLEDStripState:
      lastDisplayMessage = message;
      if (WriteToLEDStrip(message))
      {
        state = readSerialState;
      }
      break;
  }
}

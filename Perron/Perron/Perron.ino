#include "Display.h"
#include "Communication.h"
#include "LED_Strip.h"

#define readSerialState 0
#define writeToDisplayState 1
#define writeToLEDStripState 2

int state = readSerialState;
String lastDisplayMessage = "";
String message = "";

void setup()
{
  SetUpLedStrip();
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

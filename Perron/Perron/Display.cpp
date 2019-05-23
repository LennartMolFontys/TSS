#include "Display.h"

TM1637Display display1(CLK1, DIO1);
TM1637Display display2(CLK2, DIO2);
TM1637Display display3(CLK3, DIO3);

void SetUpDisplay(){
  display1.setBrightness(0x0f);
  display2.setBrightness(0x0f);
  display3.setBrightness(0x0f);
}

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

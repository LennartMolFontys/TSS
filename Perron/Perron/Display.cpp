#include "Display.h"

TM1637Display displays[numberOfDisplays] = {TM1637Display(CLK1, DIO1), TM1637Display(CLK2, DIO2), TM1637Display(CLK3, DIO3)};

void SetUpDisplay() {
  for(int i = 0; i < numberOfDisplays; i++)
  {
    displays[i].setBrightness(0x0f);
  }
}

bool WriteToDisplay(String messageToDisplay)
{
  static int displayNumber = firstDisplay;
  int displayText = messageToDisplay.substring((displayNumber * numberOfDigits), (displayNumber * numberOfDigits) + numberOfDigits).toInt();
  
  displays[displayNumber].showNumberDec(displayText, true);
  
  if ((displayNumber + 1) >= ((messageToDisplay.length() + 1) / numberOfDigits))
  {
    displayNumber = firstDisplay;
    return true;
  }
  else
  {
    displayNumber++;
    return false;
  }
}

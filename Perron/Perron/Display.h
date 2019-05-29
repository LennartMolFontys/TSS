#ifndef DISPLAY_H
#define DISPLAY_H

#define CLK1 2       // Display #1
#define DIO1 4
#define CLK2 7       // Display #2
#define DIO2 8
#define CLK3 12      // Display #3
#define DIO3 13
#define numberOfDigits 4
#define firstDisplay 0
#define numberOfDisplays 3

#include <arduino.h>
#include <TM1637Display.h>

void SetUpDisplay();
bool WriteToDisplay(String messageToDisplay);

#endif

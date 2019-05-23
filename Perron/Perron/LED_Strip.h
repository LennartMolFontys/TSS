#ifndef LED_STRIP_H
#define LED_STRIP_H

#include <Arduino.h>

#define LED1Red 3    // LED strip #1
#define LED1Green 5
#define LED2Red 6    // LED strip #2
#define LED2Green 9
#define LED3Red 10   // LED strip #3
#define LED3Green 11

void SetUpLedStrip();
bool WriteToLEDStrip(String messageToDisplay);

#endif

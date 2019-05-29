#ifndef LED_STRIP_H
#define LED_STRIP_H

#include <Arduino.h>

#define maxStrips 20
#define firstStrip 0
#define numberOfDigits 4
#define numberOfSeatsFull 5
#define numberOfSeatsBusy 20
#define off 0
#define on 255
#define greenFull 100
#define greenHalf 30

typedef struct {
  int RedPin;
  int GreenPin;
  int RedValue = 0;
  int GreenValue = 0;
} LEDStrip;

void SetUpLedStrip(int* ledPinArray, int numberOfStrips);
bool WriteToLEDStrip(String messageToDisplay);

#endif

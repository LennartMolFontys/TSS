#include "LED_Strip.h"
LEDStrip strips[maxStrips];
int numberOfStrips;

void SetUpLedStrip(int* ledPinArray, int amountOfStrips) {
  numberOfStrips = amountOfStrips;
  for(int i = 0; i < numberOfStrips; i++)
  {
    strips[i].RedPin = ledPinArray[2*i];
    strips[i].GreenPin = ledPinArray[(2*i) + 1];
    pinMode(strips[i].RedPin, OUTPUT);
    pinMode(strips[i].GreenPin, OUTPUT);
  }
}

bool WriteToLEDStrip(String messageToDisplay)
{
  static int stripNumber = firstStrip;
  int red = off;
  int green = off;

  int numberOfSeats = messageToDisplay.substring((stripNumber * numberOfDigits), (stripNumber * numberOfDigits) + numberOfDigits).toInt();
  
  if (numberOfSeats <= numberOfSeatsFull)
  {
    strips[stripNumber].RedValue = on;
    strips[stripNumber].GreenValue = off;
  }
  else if (numberOfSeats <= numberOfSeatsBusy)
  {
    strips[stripNumber].RedValue = on;
    strips[stripNumber].GreenValue = greenHalf;
  }
  else
  {
    strips[stripNumber].RedValue = off;
    strips[stripNumber].GreenValue = greenFull;
  }

  analogWrite(strips[stripNumber].RedPin, strips[stripNumber].RedValue);
  analogWrite(strips[stripNumber].GreenPin, strips[stripNumber].GreenValue);



/*
  if (numberOfSeats <= numberOfSeatsFull)
  {
    red = on;
    green = off;
  }
  else if (numberOfSeats <= numberOfSeatsBusy)
  {
    red = on;
    green = greenHalf;
  }
  else
  {
    red = off;
    green = greenFull;
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
  */
  if ((stripNumber + 1) >= ((messageToDisplay.length() + 1) / numberOfDigits))
  {
    stripNumber = firstStrip;
    return true;
  }
  else
  {
    stripNumber++;
    return false;
  }
}

#include "LED_Strip.h"

void SetUpLedStrip() {
  pinMode(LED1Red, OUTPUT);
  pinMode(LED1Green, OUTPUT);
  pinMode(LED2Red, OUTPUT);
  pinMode(LED2Green, OUTPUT);
  pinMode(LED3Red, OUTPUT);
  pinMode(LED3Green, OUTPUT);
}

bool WriteToLEDStrip(String messageToDisplay)
{
  static int stripNumber = 0;
  int red = 0;
  int green = 0;

  int numberOfSeats = messageToDisplay.substring((stripNumber * 4), (stripNumber * 4) + 4).toInt();
  if (numberOfSeats <= 5)
  {
    red = 255;
    green = 0;
  }
  else if (numberOfSeats <= 20)
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

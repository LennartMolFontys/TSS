#include "Communication.h"

int currentCarriage = 1;
int lastTime = 0;

void setup() {
  SetUpCommunication();
}

void loop() {
  SendAddress();
  if (currentCarriage == 1) {
    NewMessage();
  }
  if (!RequestSeats(currentCarriage)) {
    currentCarriage = 1;
  }
  else {
    currentCarriage++;
  }
}

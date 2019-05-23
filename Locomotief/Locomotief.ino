#include "Communication.h"

int currentCarriage = 1;

void setup() {
  SetUpCommunication();
}

void loop() {
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

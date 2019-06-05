#include "Communication.h"
#include "SeatDetection.h"

int currentCarriage = 1;
int lastTime = 0;
int seatsTaken = 0;
int lengthOfTrain = 7;
int totalSeats = 255;
unsigned long timeToWait = 0;


void setup() {
  SetUpCommunication();
}

void loop() {
  SendAddress();
  seatsTaken = GetTakenSeats();
  if (timeToWait < millis()) {
    if (currentCarriage == 1) {
      NewMessage();
      SendFirstSeats(totalSeats, lengthOfTrain, seatsTaken);
    }

    if (RequestSeats(currentCarriage)) {
      currentCarriage++;
    }
    else {
      currentCarriage = 1;
      timeToWait = timeToWait + 500;
    }
  }
}

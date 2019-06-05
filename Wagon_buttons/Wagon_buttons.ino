#include "SeatDetection.h"
#include "Communication.h"

int address = 0;
bool isConnected = false;

void setup() {
  SetUpCommunication();
  SetUpSeatPins();
}

void loop() {
  if (!isConnected) {
    address = readAddress();
    if (address != -1) {
      Connect(address);
      isConnected = true;
    }
  }
  else {
    sendAddress(address + 1);
  }
  SetSeatsTaken(GetTakenSeats());
}

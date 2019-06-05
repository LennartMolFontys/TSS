#include "SeatDetection.h"
#include "Communication.h"
#include "MAX7219Matrix.h"

bool seatArray[4][4];
int address = 0;
bool isConnected = false;

void setup() {
  SetUpCommunication();
  SetUpSeatPins();
  setUpMatrix(12, 11, 10, 1);
}

void loop() {
  if (!isConnected) {
    readAddress(&address);
    if (address != 0) {
      Connect(address);
      isConnected = true;
    }
  }
  else {
    sendAddress(address + 1);
  }
  SetSeatsTaken(GetTakenSeats());

  getAllSeats(seatArray);
  Serial.println(address);
  updateMatrix(0, seatArray);
}

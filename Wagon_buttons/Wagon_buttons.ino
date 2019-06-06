#include "SeatDetection.h"
#include "Communication.h"
#include "MAX7219Matrix.h"

#define DIN 12
#define CLK 11
#define LOAD 10
#define NR_OF_DISPLAYS 1

bool seatArray[4][4];
int address = 0;
bool isConnected = false;

void setup() {
  SetUpCommunication();
  SetUpSeatPins();
  setUpMatrix(DIN, CLK, LOAD, NR_OF_DISPLAYS);
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

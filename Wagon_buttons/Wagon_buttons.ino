#include <Wire.h>
#include <SoftwareSerial.h>
#include "SeatDetection.h"
#include "Communication.h"

#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int seatsTaken;
int address = 0;
bool isConnected = false;
int maxNumberOfSeats = 255;
int lengthOfTrain = 7;

void setup() {
  Serial.begin(9600);
  SetUpSeatPins();
}

void loop() {
  if (!isConnected) {
    address = readAddress();
    if (address != 0) {
      Connect(address);
      isConnected = true;
    }
  }
  else {
    addressBus.print("#");
    addressBus.print(address + 1);
    addressBus.println("%");
  }
  CheckSeats();
  seatsTaken = GetTakenSeats();
  Serial.println(seatsTaken);
}

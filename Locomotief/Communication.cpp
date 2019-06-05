#include "Communication.h"
SoftwareSerial addressBus(addressBusRX, addressBusTX);

int numberOfCarriages = 1;
int seatsTakenInTrain;

void SetUpCommunication() {
  addressBus.begin(9600);
  Wire.begin();
  Serial.begin(9600);
}

void NewMessage() {
  Serial.println("");
}

void SendAddress()
{
  addressBus.println("#1%");
}

bool RequestSeats(int carriage)
{
  Wire.requestFrom(carriage, 4);
  if (Wire.available()) {
    Serial.print("|");
    Serial.print(carriage);
    Serial.print("|");
    Serial.print(Wire.read());
    Serial.print("|");
    Serial.print(Wire.read());
    Serial.print("|");
    Serial.print(Wire.read());
    int secondFloor = Wire.read();
    if (secondFloor != 0) {
      Serial.print(",");
      Serial.print(secondFloor);
    }
    return true;
  }
  else {
    numberOfCarriages = carriage - 1;
    return false;
  }
}

void SendFirstSeats(int totalSeats, int lengthOfTrain, int seatsTakenInTrain) {
  Serial.print("0|");
  Serial.print(totalSeats);
  Serial.print("|");
  Serial.print(lengthOfTrain);
  Serial.print("|");
  Serial.print(seatsTakenInTrain);
}

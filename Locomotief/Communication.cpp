#include "Communication.h"
SoftwareSerial addressBus(addressBusRX, addressBusTX);

int numberOfCarriages = 1;

void SetUpCommunication() {
  addressBus.begin(9600);
  Wire.begin();
  Serial.begin(9600);
}

void NewMessage() {
  Serial.println("");
}

bool RequestSeats(int carriage)
{
  Wire.requestFrom(carriage, 4);
  if (Wire.available()) {
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
      Serial.print(Wire.read());
    }
    return true;
  }
  else {
    numberOfCarriages = carriage - 1;
    return false;
  }
}

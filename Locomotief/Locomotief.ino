#include <Wire.h>
#include <SoftwareSerial.h>

#define scanState 0
#define printSeatState 1
#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int state = printSeatState;
int numberOfCarriages = 1;
int currentCarriage = 1;

void setup() {
  addressBus.begin(9600);
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  addressBus.println("#1%");
  switch (state) {
    case printSeatState:
      if (currentCarriage == 1) {
        Serial.println("");
        Serial.print("[Aantal: ");
        Serial.print(numberOfCarriages);
        Serial.print("]");
      }
      if (!requestSeats(currentCarriage)) {
        currentCarriage = 1;
      }
      else {
        currentCarriage++;
      }
      break;
  }
}

bool requestSeats(int Carriage) {
  Wire.requestFrom(Carriage, 2);
  if (Wire.available()) {
    int i = Wire.read() * 256 + Wire.read();
    Serial.print(" [");
    Serial.print(Carriage);
    Serial.print("] ");
    Serial.print(i);
    return true;
  }
  else {
    numberOfCarriages = Carriage - 1;
    return false;
  }
}

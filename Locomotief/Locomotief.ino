#include <Wire.h>
#include <SoftwareSerial.h>

#define scanState 0
#define printSeatState 1
#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int state = scanState;
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
    case scanState:
      if (pollCarriages(numberOfCarriages)) {
        Serial.print("Number of carriages: ");
        Serial.println(numberOfCarriages);
        numberOfCarriages++;
      }
      else {
        numberOfCarriages--;
        state = printSeatState;
      }
      break;

    case printSeatState:
      requestSeats(currentCarriage);
      currentCarriage++;
      if (currentCarriage > numberOfCarriages) {
        currentCarriage = 1;
      }
      break;
  }
}

bool pollCarriages(int Carriage) {
  Wire.requestFrom(Carriage, 1);
  if (Wire.available()) {
    return true;
  }
  else {
    return false;
  }
}

void requestSeats(int Carriage) {
  Serial.print("Carriage ");
  Serial.print(Carriage);
  Serial.print(": ");
  Wire.requestFrom(Carriage, 2);
  if (Wire.available()) {
    int i = Wire.read() * 256 + Wire.read();
    Serial.print(i);
  }
  Serial.println("");
}

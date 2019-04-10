#include <Wire.h>
#include <SoftwareSerial.h>

#define idle 0
#define initializeState 1
#define printSeatState 2

#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int state = idle;
int numberOfCarriages = 1;
int currentCarriage = 1;

String message;
String fullMessage;

void setup() {
  addressBus.begin(9600);
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  addressBus.println("#1%");
  ReadSerial();
  if (fullMessage == "Initialize") {
    state = initializeState;
    fullMessage = "";
  }
  switch (state) {
    case idle:

      break;
    case initializeState:
      SerialPrintInitializeString();
      state = printSeatState;
      break;
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

bool requestSeats(int Carriage)
{
  Wire.requestFrom(Carriage, 3);
  if (Wire.available()) {
    Serial.print(" [");
    Serial.print(Carriage);
    Serial.print("] [");
    Serial.print(Wire.read());
    Serial.print("] [");
    Serial.print(Wire.read());
    Serial.print("] [");
    Serial.print(Wire.read());
    Serial.print("]");
    return true;
  }
  else {
    numberOfCarriages = Carriage - 1;
    return false;
  }
}

void ReadSerial()
{
  static String message = "";
  if (Serial.available() > 0) {
    char readChar = (char) Serial.read();
    message = message + readChar;
    message.trim();
  }
  if (message.startsWith("#") && message.endsWith("%")) {
    message = message.substring(1, message.length() - 1);
    fullMessage = message;
    message = "";
  }
}

void SerialPrintInitializeString()
{
  
}

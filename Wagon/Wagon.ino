#include <Wire.h>
#include <SoftwareSerial.h>

#define potPin A0
#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int seatsAvailable;
int address = 0;
bool isConnected = false;
String addressMessage;

void setup() {
  Serial.begin(9600);
  addressBus.begin(9600);
}

void loop() {
  if (!isConnected) {
    readAddress();
    if (address != 0) {
      Connect(address);
    }
  }
  else {
    addressBus.print("#");
    addressBus.print(address + 1);
    addressBus.println("%");
  }
  seatsAvailable = analogRead(potPin);
}

void sendSeats() {
  Wire.write(seatsAvailable / 256);
  Wire.write(seatsAvailable);
  Serial.println(seatsAvailable);
}

void readAddress() {
  if (addressBus.available() > 0) {
    char readChar = (char) addressBus.read();
    addressMessage = addressMessage + readChar;
    addressMessage.trim();
  }
  if (addressMessage.startsWith("#") && addressMessage.endsWith("%")) {
    addressMessage = addressMessage.substring(1, addressMessage.length() - 1);
    address = addressMessage.toInt();
    addressMessage = "";
  }
}

void Connect(int connectToAddress) {
  Wire.begin(connectToAddress);
  Wire.onRequest(sendSeats);
  isConnected = true;
  Serial.println(connectToAddress);
}

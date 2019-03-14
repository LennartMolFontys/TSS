#include <Wire.h>
#include <SoftwareSerial.h>

SoftwareSerial mySerial(5, 6); // RX, TX

int seatsAvailable;
int potPin = A0;
String address = "";
bool isConnected = false;
String message;

void setup() {
  Serial.begin(9600);
  mySerial.begin(9600);
}

void loop() {
  if (isConnected == false) {
    readAddress();
    if (address != "") {
      Connect(address.toInt());
    }
  }
  else {
    mySerial.print("#");
    mySerial.print(address.toInt() + 1);
    mySerial.println("%");
  }
  seatsAvailable = analogRead(potPin);
}

void requestEvent() {
  Wire.write(seatsAvailable / 256);
  Wire.write(seatsAvailable);
  Serial.println(seatsAvailable);
}

void readAddress() {
  if (mySerial.available() > 0) {
    char readChar = (char) mySerial.read();
    message = message + readChar;
    message.trim();
  }
  if (message.startsWith("#") && message.endsWith("%")) {
    message = message.substring(1, message.length() - 1);
    address = message;
    message = "";
  }
}

void Connect(int address) {
  Wire.begin(address);
  Wire.onRequest(requestEvent);
  isConnected = true;
  Serial.println(address);
}

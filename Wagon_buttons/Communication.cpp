#include "Communication.h"
SoftwareSerial addressBus(addressBusRX, addressBusTX);

String addressMessage = "";
int address = 0;

void sendSeats(int seatsTaken, int maxNumberOfSeats, int lengthOfTrain) {
  Wire.write(seatsTaken);
  Wire.write(maxNumberOfSeats);
  Wire.write(lengthOfTrain);
  Serial.println(seatsTaken);
}

int readAddress() {
  if (addressBus.available() > 0) {
    char readChar = (char) addressBus.read();
    addressMessage = addressMessage + readChar;
    addressMessage.trim();
  }
  if (addressMessage.startsWith("#") && addressMessage.endsWith("%")) {
    addressMessage = addressMessage.substring(1, addressMessage.length() - 1);
    address = addressMessage.toInt();
    addressMessage = "";
    return address;
  }
  else{
    return -1;
  }
}

void Connect(int connectToAddress) {
  Wire.begin(connectToAddress);
  Wire.onRequest(sendSeats);
}

void SetUpCommunication(){
  addressBus.begin(9600);
}

#include "Communication.h"
SoftwareSerial addressBus(addressBusRX, addressBusTX);

String addressMessage = "";
int seatsTaken;
int maxNumberOfSeats = 255;
int lengthOfTrain = 7;

void sendSeats() {
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
    int address = addressMessage.toInt();
    addressMessage = "";
    return address;
  }
  else{
    return -1;
  }
}

void sendAddress(int address){
    addressBus.print("#");
    addressBus.print(address);
    addressBus.println("%");
}

void Connect(int connectToAddress) {
  Wire.begin(connectToAddress);
  Wire.onRequest(sendSeats);
}

void SetUpCommunication(){
  addressBus.begin(9600);
}

#include "Communication.h"
SoftwareSerial addressBus(addressBusRX, addressBusTX);

String addressMessage = "";
int seatsTaken;
int maxNumberOfSeats = 16;
int lengthOfTrain = 7;

void sendSeats() {
  Wire.write(maxNumberOfSeats);
  Wire.write(lengthOfTrain);
  Wire.write(seatsTaken);
  Wire.write(0);                                    // Single Floor
}

int readAddress(int* addressToConnect) {
  if (addressBus.available() > 0) {
    char readChar = (char) addressBus.read();
    addressMessage = addressMessage + readChar;
    addressMessage.trim();
  }
  if (addressMessage.startsWith("#") && addressMessage.endsWith("%")) {
    addressMessage = addressMessage.substring(1, addressMessage.length() - 1);
    int address = addressMessage.toInt();
    addressMessage = "";
    *addressToConnect = address;
    return address;
  }
  else{
    return -1;
  }
}

void SetSeatsTaken(int taken){
  seatsTaken = taken;
}

void sendAddress(int addressToSend){
    addressBus.print("#");
    addressBus.print(addressToSend);
    addressBus.println("%");
}

void Connect(int connectToAddress) {
  Wire.begin(connectToAddress);
  Wire.onRequest(sendSeats);
}

void SetUpCommunication(){
  addressBus.begin(9600);
  Serial.begin(9600);
}

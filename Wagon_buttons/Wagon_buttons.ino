#include <Wire.h>
#include <SoftwareSerial.h>
#include "SeatDetection.c"

#define addressBusRX 5
#define addressBusTX 6

SoftwareSerial addressBus(addressBusRX, addressBusTX);

int seatsTaken;
int address = 0;
bool isConnected = false;
String addressMessage;
int maxNumberOfSeats = 255;
int lengthOfTrain = 7;

void setup() {
  Serial.begin(9600);
  addressBus.begin(9600);
  SetUpSeatPins();
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
  CheckSeats();
  int counter = 0;
  for ( int i = 0; i < ROWS; i++)
  {
    for (int j = 0; j < SEATS_PER_ROW; j++)
    {
      if(seats[i][j] == true)
      {
        counter++;
      }
    }
  }
  seatsTaken = counter;
  Serial.println(seatsTaken);
}

void sendSeats() {
  Wire.write(seatsTaken);
  Wire.write(maxNumberOfSeats);
  Wire.write(lengthOfTrain);
  Serial.println(seatsTaken);
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

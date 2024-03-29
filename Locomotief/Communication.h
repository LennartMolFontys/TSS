#ifndef COMMUNICATION_H
#define COMMUNICATION_H

#include <arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>

#define addressBusRX 5
#define addressBusTX 6

void SetUpCommunication();
void NewMessage();
void SendAddress();
void SendFirstSeats(int totalSeats, int lengthOfTrain, int seatsTaken);
bool RequestSeats(int carriage);

#endif

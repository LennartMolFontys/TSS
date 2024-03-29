#ifndef COMMUNICATION_H
#define COMMUNICATION_H

#include <arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>

#define addressBusRX 5
#define addressBusTX 6


void SetUpCommunication();

void sendSeats();

int readAddress(int* addressToConnect);

void SetSeatsTaken(int taken);

void sendAddress(int addressToSend);

void Connect(int connectToAddress);

#endif

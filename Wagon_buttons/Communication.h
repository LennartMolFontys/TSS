#ifndef COMMUNICATION_H
#define COMMUNICATION_H

#include <arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>

#define addressBusRX 5
#define addressBusTX 6

void sendSeats();

int readAddress();

void Connect(int connectToAddress);

#endif

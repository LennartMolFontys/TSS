#ifndef SEAT_DETECTION_H
#define SEAT_DETECTION_H
#include <arduino.h>


#define TAKEN true

#define ROWS 4
#define SEATS_PER_ROW 4
///rowPins give a voltage
const int rowPins[ROWS] = {3, 4, 7, 8};
///seatPins read the voltage to check if a seat is taken
const int seatPins[SEATS_PER_ROW] = {14, 15, 16, 17};

#define THRESHHOLD 10

void SetUpSeatPins();

int GetTakenSeats();

void CheckSeats();

#endif

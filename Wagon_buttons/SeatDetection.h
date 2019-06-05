#ifndef SEAT_DETECTION_H
#define SEAT_DETECTION_H
#include <arduino.h>


#define TAKEN true
#define ROWS 4
#define SEATS_PER_ROW 4
#define THRESHHOLD 10

void SetUpSeatPins();

int GetTakenSeats();

void CheckSeats();

void getAllSeats(bool seatArray[4][4]);

#endif

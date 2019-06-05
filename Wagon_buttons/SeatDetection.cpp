#include "SeatDetection.h"

///rowPins give a voltage
const int rowPins[ROWS] = {3, 4, 7, 8};
///seatPins read the voltage to check if a seat is taken
const int seatPins[SEATS_PER_ROW] = {14, 15, 16, 17};

bool seats[ROWS][SEATS_PER_ROW];

void SetUpSeatPins() {
  for (int i = 0; i < ROWS; i++) {
    pinMode(rowPins[i], OUTPUT);
  }
  for (int i = 0; i < SEATS_PER_ROW; i++) {
    pinMode(seatPins[i], INPUT);
  }
}

int GetTakenSeats() {
  CheckSeats();
  int takenSeats = 0;
  for (int i = 0; i < ROWS; i++) {
    for (int j = 0; j < SEATS_PER_ROW; j++) {
      if (seats[i][j] == TAKEN) {
        takenSeats++;
      }
    }
  }
  return takenSeats;
}

void CheckSeats() {
  for (int i = 0; i < ROWS; i++) {
    digitalWrite(rowPins[i], HIGH);
    for (int j = 0; j < SEATS_PER_ROW; j++) {
      if (analogRead(seatPins[j]) > THRESHHOLD) {
        seats[i][j] = TAKEN;
      }
      else {
        seats[i][j] = !TAKEN;
      }
    }
    digitalWrite(rowPins[i], LOW);
  }
}

void getAllSeats(bool seatArray[4][4]) {
  for (int y = 0; y < 4; y++) {
    for (int x = 0; x < 4; x++) {
      seatArray[y][x] = seats[y][x];
    }
  }
}

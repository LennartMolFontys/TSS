#include "SeatDetection.h"

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

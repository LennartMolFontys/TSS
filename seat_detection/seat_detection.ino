#include "SeatDetection.c"

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  SetUpSeatPins();
}

void loop() {
  // put your main code here, to run repeatedly:
  CheckSeats();
  delay(2000);
  printSeats(); 
}

void printSeats() {
  for (int i = 0; i < ROWS; i++) {
    for (int j = 0; j < SEATS_PER_ROW; j++) {
      Serial.print(seats[i][j]);
      Serial.print("  ");
    }
    Serial.println();
  }
  Serial.println();
  Serial.println();
}

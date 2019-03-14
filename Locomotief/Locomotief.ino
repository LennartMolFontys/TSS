#include <Wire.h>
#include <SoftwareSerial.h>
String addressString = "#1%";


int staat = 0;
int wagonNummer = 1;

int wagon = 1;


SoftwareSerial mySerial(5, 6); // RX, TX

void setup() {
  mySerial.begin(9600);
  Wire.begin();
  Serial.begin(9600);
}

void loop() {
  mySerial.println(addressString);
  switch (staat) {
    case 0:
      if (reactieVanWagon(wagonNummer)) {
        Serial.print("Aantal wagons: ");
        Serial.println(wagonNummer);
        wagonNummer++;
        staat = 0;
      }
      else {
        wagonNummer--;
        staat = 1;
      }
      break;

    case 1:
      requestSeats(wagon);
      wagon++;
      if (wagon > wagonNummer){
        wagon = 1;
      }
      break;
  }
}



bool reactieVanWagon(int nummer) {
  Wire.requestFrom(nummer, 1);
  if (Wire.available()) {
    return true;
  }
  else {
    return false;
  }
}

void requestSeats(int f){
  Wire.requestFrom(f, 2);
      Serial.print("Wagon ");
      Serial.print(f);
      Serial.print(": ");
      if (Wire.available()) {
        int i = Wire.read() * 256 + Wire.read();
        Serial.print(i);
      }
      Serial.println("");
}

#include "Communication.h"


void SetUpSerial(){
  Serial.begin(9600);
}

String ReadSerial()
{
  static String message = "";
  if (Serial.available() > 0) {
    char readChar = (char) Serial.read();
    message = message + readChar;
    message.trim();
  }
  if (message.startsWith("#") && message.endsWith("%")) {
    message = message.substring(1, message.length() - 1);
    String temp = message;
    message = "";
    return temp;
  }
  else{
    return "";
  }
}

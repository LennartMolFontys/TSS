#include "MAX7219Matrix.h"

LedControl lc = LedControl(0, 0, 0, 0);
void setUpMatrix(int DIN, int CLK, int LOAD, int NrOfDisplays) {
  lc = LedControl(DIN, CLK, LOAD, NrOfDisplays );
  for (int matrixNr = 0; matrixNr < NrOfDisplays; matrixNr++) {
    /*
      The MAX72XX is in power-saving mode on startup,
      we have to do a wakeup call
    */
    lc.shutdown(matrixNr, false);
    /* Set the brightness to a medium values */
    lc.setIntensity(matrixNr, MEDIUM_LIGHT);
    /* and clear the display */
    lc.clearDisplay(matrixNr);
  }
}

void updateMatrix(int matrixNr, bool ledArray[4][4]) {
  for (int y = 0; y < 4; y++) {
    for (int x = 0; x < 4; x++) {
      lc.setLed(matrixNr, x*2, y*2, ledArray[y][x]);
      lc.setLed(matrixNr, x*2+1, y*2, ledArray[y][x]);
      lc.setLed(matrixNr, x*2, y*2+1, ledArray[y][x]);
      lc.setLed(matrixNr, x*2+1, y*2+1, ledArray[y][x]);
    }
  }
}

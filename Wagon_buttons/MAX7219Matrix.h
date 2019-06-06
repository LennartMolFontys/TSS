#ifndef MAX_MATRIX
#define MAX_MATRIX
#include "LedControl.h"

#define DIMMED_LIGHT 2
#define MEDIUM_LIGHT 8
#define BRIGHT_LIGHT 15

void setUpMatrix(int dIn, int clk, int load, int nrOfDisplays);
void updateMatrix(int matrixNr, bool ledArray[4][4]);

#endif

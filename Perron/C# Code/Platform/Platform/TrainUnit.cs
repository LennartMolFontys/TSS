using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class TrainUnit
    {
        public int Length { get;  private set; }
        public int SeatsTotal { get; private set; }

        public TrainUnit(int length, int seatsTotal)
        {
            Length = length;
            SeatsTotal = seatsTotal;
        }

        public int GetFreeSeats(int SeatsTaken)
        {
            int value = 0;
            if (SeatsTaken >= 0)
            {
              value = SeatsTotal - SeatsTaken;

                if (value < 0)
                {
                    return 0;
                }
                else
                {
                    return value;
                }
            }

            return value;
     
        }
    }
}

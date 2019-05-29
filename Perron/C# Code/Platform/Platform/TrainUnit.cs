using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public abstract class TrainUnit
    {
        public int Length { get;  private set; }
        public int SeatsTotal { get; private set; }

        public TrainUnit(int length, int seatsTotal)
        {
            Length = length;
            SeatsTotal = seatsTotal;
        }

        public abstract int GetFreeSeats(int[,] SeatsTaken);
        public abstract void AddSeats();

    }
}

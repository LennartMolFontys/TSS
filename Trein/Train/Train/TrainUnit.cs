using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public abstract class TrainUnit
    {
        public int Lenght { get; private set; }

        public List<string> SeatsTaken { get; private set; }

        public int SeatsTotal { get; private set; }

        public TrainUnit(int Lenght, int SeatsTotal)
        {
            SeatsTaken = new List<string>();
            this.Lenght = Lenght;
            this.SeatsTotal = SeatsTotal;
        }

        public abstract int GetFreeSeats();
        public abstract void SetSeatTaken(int[] index, List<string> TakenSeats);

    }
}

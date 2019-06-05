using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
   public  class SingleFloor : TrainUnit
   {
        public  List<Seat> Seats { get; private set; }

        private int NumberOfFloors = 0;

        public SingleFloor(int length, int seatsTotal) : base(length, seatsTotal)
        {
            Seats = new List<Seat>();
            NumberOfFloors = 1;
        }

        public override void AddSeats()
        {
           for(int i = 0; i < SeatsTotal; i ++)
           {
                Seats.Add(new Seat(i));
           }
        }

        public override int GetFreeSeats(List<int> SeatsTaken)
        {
            int freeseats = 0;
            if(SeatsTaken != null)
            {
                for(int i = 0; i < SeatsTaken.Count; i++)
                {
                   freeseats += SeatsTotal - SeatsTaken[i];
                }

                return freeseats;
            }
            return freeseats;

        }
    }
}

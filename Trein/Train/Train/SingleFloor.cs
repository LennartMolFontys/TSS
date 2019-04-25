using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class SingleFloor : TrainUnit
    {
        public List<Seat> Seats { get; private set; }
        public SingleFloor(int Lenght, int SeatsTotal) : base(Lenght, SeatsTotal)
        {
            Seats = new List<Seat>();
            AddSeats(SeatsTotal);
        }

        private void AddSeats(int Amount)
        {
            for(int i = 0; i < Amount; i++)
            {
                Seat seat = new Seat(false);
                Seats.Add(seat);
            }

        }

        public override void SetSeatTaken(int[] index, List<string> list)
        {
            for(int i = 0; i < index.Length; i++)
            {
                Seats[index[i]].SetTaken();
                list.Add(string.Format("Taken Seat: {0}", index[i].ToString()));
            }

        }

        public override int GetFreeSeats()
        {
            int count = 0;
            foreach(Seat s in Seats)
            {
                if(s.Taken == true)
                {
                    count++;
                }
            }
                   
            return SeatsTotal - count;
        }
    }
}

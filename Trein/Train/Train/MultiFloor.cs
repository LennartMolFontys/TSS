using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class MultiFloor : TrainUnit
    {
        public List<Seat>TopSeats { get; private set; }
        public List<Seat> BottomSeats { get; private set; }
        public int FreeSeatsFirstFloor { get; private set; }
        public int FreeSeatsSecondFloor { get; private set; }

        private string TakenSeat = "";

        public MultiFloor(int Lenght, int TotalSeats) : base(Lenght, TotalSeats)
        {
            TopSeats = new List<Seat>();
            BottomSeats = new List<Seat>();
            int SeatsFirstFloor = TotalSeats / 2;
            int SeatsSecondFloor = SeatsFirstFloor;
            AddSeats(SeatsFirstFloor, TopSeats);
            AddSeats(SeatsSecondFloor, BottomSeats);
        }

        private void AddSeats(int seats, List<Seat> list)
        {
            for(int i = 0; i < seats; i++)
            {
                list.Add(new Seat(false));
            }
        }

        public override void SetSeatTaken(int[] index, List<string> list)
        {
            for(int i = 0; i < index.Length; i++)
            {
                if (index[i] > 100)
                {
                    int indexer = index[i] - 100;
                    TopSeats[indexer].SetTaken();
                    list.Add(TakenSeat = string.Format("Taken Seat:  {0} on Top Floor", indexer.ToString()));
                }
                else
                {
                    BottomSeats[index[i]].SetTaken();
                    list.Add(TakenSeat = string.Format("Taken Seat:  {0} on Botton Floor", index[i].ToString()));
                }
            }
        }

        public override int GetFreeSeats()
        {
            int count = 0;
            foreach(Seat s in TopSeats)
            {
               if(s.Taken == true)
               {
                    count++;
               }
            }

            foreach(Seat x in BottomSeats)
            {
                if(x.Taken == true)
                {
                    count++;
                }
            }

            return SeatsTotal - count;
        }
    }
}

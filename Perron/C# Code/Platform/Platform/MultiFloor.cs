using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    class MultiFloor : TrainUnit
    {
        private List<Seat> BottomFloorSeats;
        private List<Seat> TopFloorSeats;
        private int NumberOfFloors = 0;
        private int[] floors;


        public MultiFloor(int length, int seatsTotal) : base(length, seatsTotal)
        {
            TopFloorSeats = new List<Seat>();
            BottomFloorSeats = new List<Seat>();
            floors[0] = SeatsTotal / 2;
            floors[1] = SeatsTotal / 2;
            NumberOfFloors = 2;
        }

        public override void AddSeats()
        {
            for(int i = 0; i < floors[0]; i++)
            {
                TopFloorSeats.Add(new Seat(i));
            }

            for(int i = 0; i < floors[1]; i++)
            {
                BottomFloorSeats.Add(new Seat(i));
            }
        }

        public override int GetFreeSeats(List<List<int>> SeatsTaken)
        {
            int freeSeats = 0;
            if(SeatsTaken != null)
            {
                for(int i = 0; i < SeatsTaken.Count; i++)
                {
                    for(int j = 0; j < SeatsTaken[i].Count; i++)
                    {
                        freeSeats += floors[i] - SeatsTaken[i][j];
                    }
                }

                return freeSeats;
                    
            }
            return freeSeats;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Train
    {
        public int TrainId { get; private set; }
        public List<TrainUnit>TrainUnits { get; private set; }

        public Train(int TrainId)
        {
            this.TrainId = TrainId;
            TrainUnits = new List<TrainUnit>();
        }

        public void AddUnit(TrainUnit trainUnit)
        {
            TrainUnits.Add(trainUnit);
        }

        public void Remove(TrainUnit trainUnit)
        {
            TrainUnits.Remove(trainUnit);
        }

        public void SetSeatTaken(TrainUnit trainUnit, int[] Seatstaken)
        {
            if(trainUnit is SingleFloor)
            {
                trainUnit = trainUnit as SingleFloor;
                trainUnit.SetSeatTaken(Seatstaken, trainUnit.SeatsTaken);
            }
            else if(trainUnit is MultiFloor)
            {
                trainUnit = trainUnit as MultiFloor;
                trainUnit.SetSeatTaken(Seatstaken, trainUnit.SeatsTaken);
            }
        }
    }
}

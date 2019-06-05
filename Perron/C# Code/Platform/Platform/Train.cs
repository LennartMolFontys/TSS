using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
   public class Train
    {
        public List<TrainUnit> trainUnits { get; private set; }
        public int TrainId { get; private set; }
        private TrainUnit unit;

        public Train(int trainId)
        {
            TrainId = trainId;
            trainUnits = new List<TrainUnit>();
        }

        public void Add(int lenght, int seatsTotal)
        {
            if(lenght > 0 && seatsTotal > 0)
            {
                if(seatsTotal > 100)
                {
                     unit = new MultiFloor(lenght, seatsTotal);
                    
                }
                else
                {
                    unit = new SingleFloor(lenght, seatsTotal);  
                }
                trainUnits.Add(unit);
            }
                     
        }
    }
}

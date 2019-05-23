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

        public Train(int trainId)
        {
            TrainId = trainId;
            trainUnits = new List<TrainUnit>();
        }

        public void Add(int lenght, int seatsTotal)
        {
            if(lenght > 0 && seatsTotal > 0)
            {
                TrainUnit unit = new TrainUnit(lenght, seatsTotal);
                trainUnits.Add(unit);
            }
                     
        }
    }
}

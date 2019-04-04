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

        public void Add(TrainUnit trainUnit)
        {
            if(trainUnit != null)
            {
                trainUnits.Add(trainUnit);
            }          
        }

        public void Remove(int Unit)
        {
            int index = Unit - 1;
            trainUnits.Remove(trainUnits[index]);
        }
    }
}

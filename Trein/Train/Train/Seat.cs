using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
     public class Seat
    {
        public int NrSeatsFirstClass { get; private set; }
        public int NrSeatsSecondClass { get; private set; }
        public bool Taken { get; private set; }

        public Seat(bool taken)
        {
            Taken = taken;
        }

        public void SetTaken()
        {
            Taken = true;
        }

    }
}

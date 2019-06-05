using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class Seat
    {
        public int SeatID { get; private set; }
        public Seat(int id)
        {
            SeatID = id;
        }
    }
}

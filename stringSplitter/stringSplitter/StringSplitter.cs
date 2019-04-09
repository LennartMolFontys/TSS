using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringSplitter
{
    static class StringSplitter
    {

        public static int GetTrainId(string initialiseString)
        {
            string id = "ID:";
            int startPoint = initialiseString.IndexOf(id) + id.Length;
            int length = initialiseString.IndexOf("UnitAmount") - startPoint;
            int trainId = Convert.ToInt32(initialiseString.Substring(startPoint, length));
            return trainId;
        }
        
        public static int GetUnitAmount(string initialiseString)
        {
            string unit = "UnitAmount:";
            int startPoint = initialiseString.IndexOf(unit) + unit.Length;
            int length = initialiseString.IndexOf("Length") - startPoint;
            int unitAmount = Convert.ToInt32(initialiseString.Substring(startPoint, length));
            return unitAmount;
        }

        public static List<int[]> GetUnitInfo(string initialiseString, int unitAmount)
        {
            string lengthString = "Length:";
            string seatsString = "TotalSeats:";
            int searchStartPoint = 0;
            List<int[]> unitInfo = new List<int[]>();
            for(int i = 0; i < unitAmount; i++)
            {
                int startPoint = initialiseString.IndexOf(lengthString, searchStartPoint) + lengthString.Length;
                searchStartPoint = startPoint;
                int length = initialiseString.IndexOf(seatsString, searchStartPoint) - startPoint;
                int unitLength = Convert.ToInt32(initialiseString.Substring(startPoint, length));

                startPoint = initialiseString.IndexOf(seatsString, searchStartPoint) + seatsString.Length;
                searchStartPoint = startPoint;
                length = initialiseString.IndexOf(lengthString, searchStartPoint) - startPoint;
                if(length < 0)
                {
                    length = initialiseString.Length - startPoint;
                }
                int seatAmount = Convert.ToInt32(initialiseString.Substring(startPoint, length));
                unitInfo.Add(new int[2] { unitLength, seatAmount });
            }
            return unitInfo;
        }
    }
}

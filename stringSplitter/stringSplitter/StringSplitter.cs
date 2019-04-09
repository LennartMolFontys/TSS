using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringSplitter
{
    static class StringSplitter
    {
        public static string InitialiseFormat { get; } = "ID:<value>UnitAmount:<value>Length:<value>TotalSeats:<value><value>Length:<value>TotalSeats:<value>...";
        public static string SeatInfoFormat { get; } = "SeatsTaken:<value>SeatsTaken:<value>...";
        private static string[] splitStrings = new string[] { "Length:", "TotalSeats:", "SeatsTaken:" };


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

        

        private static int[] getValuesFromString(string someString)
        {
            if (someString.Contains("Length"))
            {
                someString = someString.Substring(someString.IndexOf("Length:"));
            }            
            string[] stringValues = someString.Split(splitStrings, StringSplitOptions.RemoveEmptyEntries);
            int[] intvalues = new int[stringValues.Count()];
            for (int i = 0; i < stringValues.Count(); i++)
            {
                intvalues[i] = Convert.ToInt32(stringValues[i]);
            }
            return intvalues;
        }

        public static int[] GetSeatsTaken(string someString)
        {
            return getValuesFromString(someString);
        }

        public static int[,] GetUnitInfo(string someString)
        {
            int[] values = getValuesFromString(someString);
            int[,] unitInfo = new int[values.Count() / 2, 2];
            for (int i = 0; i < values.Count()/2 ; i++)
            {
                for (int ii = 0; ii < 2; ii++)
                {
                    unitInfo[i, ii] = values[2 * i + ii];
                }
            }
            return unitInfo;
        }
    }
}

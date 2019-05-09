using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    static class StringSplitter
    {
        public static string InitializeFormat { get; } = "ID:<value>UnitAmount:<value>Length:<value>TotalSeats:<value><value>Length:<value>TotalSeats:<value>...";
        public static string SeatOccupationFormat { get; } = "SeatsTaken:<value>SeatsTaken:<value>...";
        private static string[] splitStrings = new string[] { "Length:", "TotalSeats:", "SeatsTaken:" };


        public static int GetTrainId(string initialiseString)
        {
            int id = 0;
            if(!string.IsNullOrEmpty(initialiseString))
            {
                try
                {
                    id = getValueBetweenStrings(initialiseString, "ID:", "UnitAmount:");
                }
                catch (FormatException)
                {
                    throw new FormatException("Expected: " + InitializeFormat + "\ngot: " + initialiseString);
                }
            }
            return id;
        }
        
        public static int GetUnitAmount(string initialiseString)
        {
            int unitAmount = 0;
            if (!string.IsNullOrEmpty(initialiseString))
            {
                try
                {
                     unitAmount = getValueBetweenStrings(initialiseString, "UnitAmount:", "Length:");
                }
                catch (FormatException)
                {
                    throw new FormatException("Expected: " + InitializeFormat + "\ngot: " + initialiseString);
                }
            }

            return unitAmount;

        }

        private static int getValueBetweenStrings(string someString, string header, string footer)
        {
            int startPoint = someString.IndexOf(header) + header.Length;
            int length = someString.IndexOf(footer) - startPoint;
            if(!someString.Contains(header) || !someString.Contains(footer))
            {
                throw new FormatException();
            }
            return Convert.ToInt32(someString.Substring(startPoint, length));
        }

        
        public static int[] GetSeatsTaken(string someString)
        {
            try
            {
                return getValuesFromString(someString, splitStrings);
            }
            catch(FormatException)
            {
                throw new FormatException("Expected: " + SeatOccupationFormat + "\ngot: " + someString);
            }
        }

        public static int[,] GetUnitInfo(string someString)
        {
            someString = someString.Substring(someString.IndexOf("Length:"));
            int[] values;
            try
            {
                values = getValuesFromString(someString, splitStrings);
            }
            catch(FormatException)
            {
                throw new FormatException("Expected: " + InitializeFormat + "\ngot: " + someString);
            }
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

        private static int[] getValuesFromString(string someString, string[] headerStrings)
        {
            try
            {
                string[] stringValues = someString.Split(headerStrings, StringSplitOptions.RemoveEmptyEntries);
                int[] intvalues = new int[stringValues.Count()];
                for (int i = 0; i < stringValues.Count(); i++)
                {
                    intvalues[i] = Convert.ToInt32(stringValues[i]);
                }
                return intvalues;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new FormatException();
            }
            catch (OverflowException)
            {
                throw new FormatException();
            }
            catch (FormatException e)
            {
                throw e;
            }
        }
    }
}

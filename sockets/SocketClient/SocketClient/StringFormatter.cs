using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    static class StringFormatter
    {
        public static string InitializeFormat { get; } = "ID:<value>UnitAmount:<value>Length:<value>TotalSeats:<value>Length:<value>TotalSeats:<value>...";
        private static string[] initializeHeaders = { "ID:", "UnitAmount:", "Length:", "TotalSeats:" };
        public static string SeatOccupationFormat { get; } = "SeatsTaken:<value>SeatsTaken:<value>...";
        private static string[] seatOccupationHeaders = { "SeatsTaken:" };


        private static char[] serialSplitCharacter = { '|' };
        private static int amountOfTrainUnitVariables = 4;
        private static int lengthPosition = 2;
        private static int totalSeatPosition = 3;
        private static int seatsTakenPosition = 4;

        public static string BuildSeatInfoString(string serialString)
        {
            if (string.IsNullOrEmpty(serialString))
            {
                throw new ArgumentNullException(nameof(serialString));
            }
            string[] trainUnitValues = serialString.Split(serialSplitCharacter, StringSplitOptions.RemoveEmptyEntries);
            int unitAmount = trainUnitValues.Count() / amountOfTrainUnitVariables;

            string seatInfo = "";
            for (int unitNr = 0; unitNr < unitAmount; unitNr++)
            {
                seatInfo = seatInfo + "SeatsTaken:" + trainUnitValues[unitNr * amountOfTrainUnitVariables + seatsTakenPosition];
            }
            return seatInfo;
        }

        public static string BuildInitializeString(string serialString, int trainID)
        {
            if (string.IsNullOrEmpty(serialString))
            {
                throw new ArgumentNullException(nameof(serialString));
            }
            string[] trainUnitValues = serialString.Split(serialSplitCharacter, StringSplitOptions.RemoveEmptyEntries);
            int unitAmount = trainUnitValues.Count() / amountOfTrainUnitVariables;

            string initializeInfo = "ID:" + trainID.ToString() + "UnitAmount:" + unitAmount.ToString();
            for (int unitNr = 0; unitNr < unitAmount; unitNr++)
            {
                initializeInfo = initializeInfo + "Length:" + trainUnitValues[unitNr * amountOfTrainUnitVariables + lengthPosition]
                                                + "TotalSeats:" + trainUnitValues[unitNr * amountOfTrainUnitVariables + totalSeatPosition];
            }
            return initializeInfo;
        }

        public static int GetTrainId(string initialiseString)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(initialiseString))
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


        public static int[] GetSeatsTaken(string someString)
        {
            try
            {
                return getValuesFromString(someString, seatOccupationHeaders);
            }
            catch (FormatException)
            {
                throw new FormatException("Expected: " + SeatOccupationFormat + "\ngot: " + someString);
            }
        }

        public static int[,] GetUnitInfo(string someString)
        {
            int amountOfVariables = 2;
            someString = someString.Substring(someString.IndexOf("Length:"));
            int[] values;
            try
            {
                values = getValuesFromString(someString, initializeHeaders);
            }
            catch (FormatException)
            {
                throw new FormatException("Expected: " + InitializeFormat + "\ngot: " + someString);
            }
            int amountOfUnits = values.Count() / amountOfVariables;
            int[,] unitInfo = new int[amountOfUnits, amountOfVariables];
            for (int unit = 0; unit < amountOfUnits; unit++)
            {
                for (int variableNr = 0; variableNr < amountOfVariables; variableNr++)
                {
                    unitInfo[unit, variableNr] = values[amountOfVariables * unit + variableNr];
                }
            }
            return unitInfo;
        }

        private static int getValueBetweenStrings(string someString, string header, string footer)
        {
            int startPoint = someString.IndexOf(header) + header.Length;
            int length = someString.IndexOf(footer) - startPoint;
            if (!someString.Contains(header) || !someString.Contains(footer))
            {
                throw new FormatException();
            }
            return Convert.ToInt32(someString.Substring(startPoint, length));
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

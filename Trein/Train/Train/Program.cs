using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainUnit test1 = new SingleFloor(100, 100);
            TrainUnit test2 = new MultiFloor(100, 200);
            int[] Unit2 = { 9, 8, 110, 198 };
            int[] unit1 = { 55, 77, 66, 88 };
            Train test = new Train(1);
            Console.WriteLine("Creating Units");
            test.AddUnit(test1);
            test.AddUnit(test2);

            Console.WriteLine("Setting seats to taken");
            test.TrainUnits[0].SetSeatTaken(unit1, test.TrainUnits[0].SeatsTaken);
            test.TrainUnits[1].SetSeatTaken(Unit2, test.TrainUnits[1].SeatsTaken);

            Console.WriteLine("Calculating seats free");
            int x=  test.TrainUnits[0].GetFreeSeats();
            int j = test.TrainUnits[0].GetFreeSeats();
            Console.WriteLine("Number of free seats Unit 1:  {0}", x.ToString());
            Console.WriteLine("Number of free seats Unit 2:  {0}", j.ToString());


            foreach(string s in test.TrainUnits[0].SeatsTaken)
            {
                Console.WriteLine(s);
            }

            foreach(string s in test.TrainUnits[1].SeatsTaken)
            {
                Console.WriteLine(s);
            }
            Console.Read();





        }
    }
}

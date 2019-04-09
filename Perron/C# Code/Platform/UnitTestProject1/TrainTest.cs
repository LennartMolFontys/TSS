using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void TestConstrutor()
        {
            // arrange
            Train test;

            // set
            test = new Train(1);

            // assert
            Assert.AreEqual(1, test.TrainId);
        }

        [TestMethod]
        public void AddTrainUnit()
        {
            // arrange
            Train test = test = new Train(1);
            int lenght = 5;
            int TotalSeats = 10;

            // set
            test.Add(new TrainUnit(lenght, TotalSeats));

            // assert
            Assert.AreEqual(1, test.trainUnits.Count);
            Assert.AreEqual(5, test.trainUnits[0].Length);
            Assert.AreEqual(10, test.trainUnits[0].SeatsTotal);
        }

        [TestMethod]
        public void RemoveUnit()
        {
            // arrange
            Train test = test = new Train(1);
            int lenght = 5;
            int TotalSeats = 10;
            test.Add(new TrainUnit(lenght, TotalSeats));
            test.Add(new TrainUnit(lenght, 11));

            // set
            test.Remove(1);

            // assert
            Assert.AreEqual(1, test.trainUnits.Count);
            Assert.AreEqual(11, test.trainUnits[0].SeatsTotal);
        }
    }
}

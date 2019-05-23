using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class TrainTest
    {
        private Train test;

        [TestInitialize]
        public void init()
        {
            test = new Train(1);
        }

        [TestMethod]
        public void TestConstrutor()
        {
            // assert
            Assert.AreEqual(1, test.TrainId);
        }

        [TestMethod]
        public void AddTrainUnit()
        {
            // arrange
            int lenght = 5;
            int TotalSeats = 10;

            // set
            test.Add(lenght, TotalSeats);

            // assert
            Assert.AreEqual(1, test.trainUnits.Count);
            Assert.AreEqual(5, test.trainUnits[0].Length);
            Assert.AreEqual(10, test.trainUnits[0].SeatsTotal);
        }
    }
}

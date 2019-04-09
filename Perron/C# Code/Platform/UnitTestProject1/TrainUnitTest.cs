using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class TrainUnitTest
    {
        [TestMethod]
        public void ContructorTest()
        {
            // arrange
            TrainUnit unit;

            // set
            unit = new TrainUnit(5, 30);

            // Assert
            Assert.AreEqual(5, unit.Length);
            Assert.AreEqual(30, unit.SeatsTotal);
        }

        [TestMethod]
        public void TestGetFreeSeats()
        {
            // arrange
            TrainUnit unit = new TrainUnit(4, 20);

            // set
            int Seats = unit.GetFreeSeats(15);

            // Assert
            Assert.AreEqual(5, Seats);
        }

        [TestMethod]
        public void TestGetFreeSeatsLowerThenZero()
        {
            // arrange
            TrainUnit unit = new TrainUnit(4, 20);

            // set
            int Seats = unit.GetFreeSeats(25);

            // Assert
            Assert.AreEqual(0, Seats);
        }
    }
}

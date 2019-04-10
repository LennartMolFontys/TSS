using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class PlatFormTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            // arrange
            PlatForm platform;

            // set
            platform = new PlatForm();

            // Assert
            Assert.AreEqual(0, platform.TrainID);
            Assert.AreEqual(string.Empty, platform.trainInfo);     
        }

        [TestMethod]// << see Comments at Method
        public void TestGetTrainInfo()
        {
            // arrange
            PlatForm platform = new PlatForm();
            string test = "ID:5UnitAmount:2Length:4TotalSeats:5Length:3TotalSeats:9";

            // set
            platform.GetTrainInfo(test);

            // Assert
            Assert.AreEqual(5, platform.train.TrainId);
            Assert.AreEqual(2, platform.train.trainUnits.Count);
            Assert.AreEqual(4, platform.train.trainUnits[0].Length);
            Assert.AreEqual(5, platform.train.trainUnits[0].SeatsTotal);
        }
    }
}

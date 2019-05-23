using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    [TestClass]
    public class PlatFormTest
    {
        private PlatForm platForm;
        private string TestInitString;
        private string TestTaken;

        [TestInitialize]
        public void init()
        {
            platForm = new PlatForm();
            TestInitString = "ID:5UnitAmount:2Length:4TotalSeats:5Length:3TotalSeats:9";
            TestTaken = "SeatsTaken:3SeatsTaken:6";
        }

        [TestMethod]
        public void TestConstructorCorrect()
        {
            // Assert
            Assert.AreEqual(0, platForm.TrainID);
            Assert.AreEqual(string.Empty, platForm.trainInfo);
        }

        [TestMethod]
        public void TestConstructorInCorrect()
        {
            // Assert
            Assert.AreNotEqual(1, platForm.TrainID);
            Assert.AreNotEqual("HALLO", platForm.trainInfo);
        }

        [TestMethod]
        public void TestGetTrainInfoSucces()
        {
            // set
            platForm.GetTrainInfo(TestInitString);

            // Assert
            Assert.AreEqual(5, platForm.TrainID);
            Assert.AreEqual(2, platForm.train.trainUnits.Count);
            Assert.AreEqual(4, platForm.train.trainUnits[0].Length);
            Assert.AreEqual(5, platForm.train.trainUnits[0].SeatsTotal);
        }

        [TestMethod]
        public void TestGetTrainInfoFail()
        {
            // set
            platForm.GetTrainInfo("");

            // Assert
            Assert.AreEqual(0, platForm.TrainID);
            Assert.AreEqual(0, platForm.trainUnits);
        }

        [TestMethod]
        public void TestGetSeatInfo()
        {
            //arrange
            platForm.GetTrainInfo(TestInitString);
           
               
            // set
            platForm.GetSeatInfo(TestTaken);

            //
            Assert.AreEqual(2, platForm.freeSeats[0]);
            Assert.AreEqual(3, platForm.freeSeats[1]);
        }

        [TestMethod]
        public void TestGetSeatInfoFail()
        {
            // set
            platForm.GetSeatInfo("");

            // Assert
            Assert.AreEqual(string.Empty, platForm.trainInfo);
        }


        [TestMethod]
        public void SentToArduinoString()
        {
            //arrange
            platForm.GetTrainInfo(TestInitString);
            platForm.GetSeatInfo(TestTaken);

            //set
            string test = platForm.send();

            Assert.AreEqual("00020003", test);
        }
    }
}

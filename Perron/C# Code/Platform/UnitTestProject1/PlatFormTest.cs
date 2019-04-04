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
            Assert.AreEqual(string.Empty, platform.TrainInfo);     
        }

        [TestMethod]
        public void TestAddTrain()
        {
            // arrange
            PlatForm platform = new PlatForm();
            int trainid = 1;
            // set
            platform.Add(trainid);

            // Assert
            Assert.AreEqual(1, platform.train.TrainId);
        }
    }
}

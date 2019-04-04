using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform;

namespace UnitTestProject1
{
    // kan alleen aan gesloten worden als arduino is aangesloten

    [TestClass]
    public class DisplayTest
    {
        // verander dit naar de juiste comport
        private int comport = 4;

        [TestMethod]
        public void TestConcstructor()
        {
            // arrange
            Display display;

            // set
            display = new Display(comport);

            // assert
            Assert.AreEqual(4, display.COM_Port);
        }

        [TestMethod]
        public void TestConnection()
        {
            // arrange
            Display display = display = new Display(comport);

            // set
            display.Connect();

            // assert
            Assert.AreEqual(true, display.connected);
        }

        [TestMethod]
        public void TestCloseConnection()
        {
            // arrange
            Display display = display = new Display(comport);
            display.Connect();

            // set
            display.CloseSerialPort();

            // assert
            Assert.AreEqual(false, display.connected);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankSolutions.CatsAndMouse
{
    [TestClass]
    public class CatsAndMouse_Test
    {
        [TestMethod]
        public void SampleInput_0()
        {
            Assert.AreEqual("Cat B", CatsAndMouse.Catcher(1, 2, 3));
            Assert.AreEqual("Mouse C", CatsAndMouse.Catcher(1, 3, 2));
            Assert.AreEqual("Cat A", CatsAndMouse.Catcher(2, 1, 3));
        }

        [TestMethod]
        public void AllZeros()
        {
            Assert.AreEqual("Mouse C", CatsAndMouse.Catcher(0, 0, 0));
        }

        [TestMethod]
        public void MiscInput_0()
        {
            Assert.AreEqual("Cat A", CatsAndMouse.Catcher(0, 1, 0));
        }

        [TestMethod]
        public void MiscInput_1()
        {
            Assert.AreEqual("Cat B", CatsAndMouse.Catcher(1, 0, 0));
        }

        [TestMethod]
        public void MiscInput_2()
        {
            Assert.AreEqual("Mouse C", CatsAndMouse.Catcher(1, 1, 1));
        }

        [TestMethod]
        public void MiscInput_3()
        {
            Assert.AreEqual("Mouse C", CatsAndMouse.Catcher(0, 0, 1));
        }

        [TestMethod]
        public void MiscInput_4()
        {
            Assert.AreEqual("Cat A", CatsAndMouse.Catcher(1, 2, 0));
        }

        [TestMethod]
        public void MiscInput_5()
        {
            Assert.AreEqual("Cat B", CatsAndMouse.Catcher(2, 1, 0));
        }

        [TestMethod]
        public void MiscInput_6()
        {
            Assert.AreEqual("Cat A", CatsAndMouse.Catcher(2, 1, 2));
        }

        [TestMethod]
        public void MiscInput_7()
        {
            Assert.AreEqual("Cat B", CatsAndMouse.Catcher(2, 4, 5));
        }

        [TestMethod]
        public void MiscInput_8()
        {
            Assert.AreEqual("Cat B", CatsAndMouse.Catcher(2, 4, 6));
        }
    }
}

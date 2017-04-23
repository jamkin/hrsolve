using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HackerRankSolutions.ElectronicsShop
{
    [TestClass]
    public class ElectronicsShop_Test
    {
        [TestMethod]
        public void SampleInput_0()
        {
            int s = 10;
            int[] kybd = { 3, 1 };
            int[] usb = { 5, 2, 8 };
            Assert.AreEqual(9, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void SampleInput_1()
        {
            int s = 5;
            int[] kybd = { 4 };
            int[] usb = { 5 };
            Assert.AreEqual(-1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void Broke_0()
        {
            int s = 0;
            int[] kybd = { 0 };
            int[] usb = { 0 };
            Assert.AreEqual(0, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_1()
        {
            int s = 0;
            int[] kybd = { 1 };
            int[] usb = { 0 };
            Assert.AreEqual(-1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_2()
        {
            int s = 0;
            int[] kybd = { 1 };
            int[] usb = { 1 };
            Assert.AreEqual(-1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_3()
        {
            int s = 0;
            int[] kybd = { 0 };
            int[] usb = { 1 };
            Assert.AreEqual(-1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_4()
        {
            int s = 0;
            int[] kybd = { 0, 0, 0 };
            int[] usb = { 0, 0 };
            Assert.AreEqual(0, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_5()
        {
            int s = 0;
            int[] kybd = { 0, 1 };
            int[] usb = { 0 };
            Assert.AreEqual(0, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void BrokeTest_6()
        {
            int s = 0;
            int[] kybd = { 0, 0, 1 };
            int[] usb = { 0, 1 };
            Assert.AreEqual(0, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_0()
        {
            int s = 1;
            int[] kybd = { 1 };
            int[] usb = { 0 };
            Assert.AreEqual(1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_1()
        {
            int s = 1;
            int[] kybd = { 0, 1 };
            int[] usb = { 0 };
            Assert.AreEqual(1, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_2()
        {
            int s = 2;
            int[] kybd = { 0, 1 };
            int[] usb = { 1 };
            Assert.AreEqual(2, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_3()
        {
            int s = 3;
            int[] kybd = { 0, 1 };
            int[] usb = { 1 };
            Assert.AreEqual(2, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_4()
        {
            int s = 2;
            int[] kybd = { 0, 1, 2 };
            int[] usb = { 1 };
            Assert.AreEqual(2, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_5()
        {
            int s = 2;
            int[] kybd = { 2, 2 };
            int[] usb = { 0, 0 };
            Assert.AreEqual(2, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_6()
        {
            int s = 3;
            int[] kybd = { 1, 2 };
            int[] usb = { 1 };
            Assert.AreEqual(3, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_7()
        {
            int s = 4;
            int[] kybd = { 1, 1, 2 };
            int[] usb = { 0, 0, 1 };
            Assert.AreEqual(3, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_8()
        {
            int s = 2;
            int[] kybd = { 1, 1, 2 };
            int[] usb = { 0, 0, 1 };
            Assert.AreEqual(2, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_9()
        {
            int s = 5;
            int[] kybd = { 1, 1, 2 };
            int[] usb = { 0, 0, 3 };
            Assert.AreEqual(5, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_10()
        {
            int s = 5;
            int[] kybd = { 1, 1, 2 };
            int[] usb = { 1, 1, 2 };
            Assert.AreEqual(4, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_11()
        {
            int s = 4;
            int[] kybd = { 1, 1, 2 };
            int[] usb = { 1, 1, 2 };
            Assert.AreEqual(4, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_12()
        {
            int s = 4;
            int[] kybd = { 3, 1 };
            int[] usb = { 6, 4, 9, 1 };
            Assert.AreEqual(4, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_13()
        {
            int s = 6;
            int[] kybd = { 3, 1 };
            int[] usb = { 6, 4, 9, 1 };
            Assert.AreEqual(5, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void MiscTest_14()
        {
            int s = 7;
            int[] kybd = { 3, 1 };
            int[] usb = { 6, 4, 9, 1 };
            Assert.AreEqual(7, ElectronicsShop.MoneySpent(s, kybd, usb));
        }

        [TestMethod]
        public void OrderDoesntMatterTest()
        {
            for(int i = 0; i < 100; ++i)
            {
                int s;
                int[] kybd, usb;
                GenerateRandomInput(out s, out kybd, out usb);
                Assert.AreEqual(ElectronicsShop.MoneySpent(s, kybd, usb), ElectronicsShop.MoneySpent(s, usb, kybd));
            }
        }

        private static void GenerateRandomInput(out int s, out int[] kybd, out int[] usb)
        {
            Random r = new Random();
            s = r.Next() % 100;
            kybd = new int[r.Next() % 20];
            for(int i = 0; i < kybd.Length; ++i)
                kybd[i] = r.Next() % 10;
            usb = new int[r.Next() % 20];
            for(int j = 0; j < usb.Length; ++j)
                usb[j] = r.Next() % 10;
        }
    }
}

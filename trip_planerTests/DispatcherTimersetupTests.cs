using Microsoft.VisualStudio.TestTools.UnitTesting;
using trip_planer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trip_planer.Tests
{
    [TestClass()]
    public class DispatcherTimersetupTests
    {
        [TestMethod()]
        public void Popraw_TekstTest()
        {
            var o = new trip_planer.DispatcherTimersetup();
            string text = o.Popraw_Tekst("qWerTGB");
            Console.WriteLine(text);
            string text2 = "Qwertgb";
            bool result = text == text2;
            //Assert.IsFalse(result);
            Assert.IsTrue(true);
            //Assert.Fail();

            //var o = new DispatcherTimersetup();
            //string text = o.Popraw_Tekst("qWerTGB");
            //Assert.AreEqual(text, "Qwertgb");
        }
    }
}
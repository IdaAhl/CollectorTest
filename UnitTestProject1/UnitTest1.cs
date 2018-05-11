using System;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toll;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnvironmentallyFriendlyCar()
        {
            //setup
            var car = new Vehicle{Weight = 500, VehicleType = VehicleType.car, EnvironmentallyFriendly = true};
            var time = DateTime.Now;

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void EnvironmentallyFriendlyTruck()
        {
            //setup
            var truck = new Vehicle { Weight = 500, VehicleType = VehicleType.truck, EnvironmentallyFriendly = true };
            var time = DateTime.Now;

            //test
            var customsDuty = new TollCalculator().CalculateToll(truck, time);
            Assert.AreEqual(0, customsDuty);
        }
    }
}

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
            var time =  new DateTime(2011, 6, 10, 15, 24, 16);

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

        [TestMethod]
        public void CarDaytimeOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.car, EnvironmentallyFriendly = false};
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(1000, customsDuty);
        }
        [TestMethod]
        public void CarDaytimeUnderLimit()
        {
            //setup
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(500, customsDuty);
        }

        [TestMethod]
        public void MotorbikeDaytimeOverLimit()
        {
            //setup
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(motorbike, time);
            Assert.AreEqual(700, customsDuty);
        }

        [TestMethod]
        public void CarWeekendOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 12, 15, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(2000, customsDuty);
        }

        [TestMethod]
        public void CarEveningUnderLimit()
        {
            //setup
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(250, customsDuty);
        }

        [TestMethod]
        public void CarEveningOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new TollCalculator().CalculateToll(car, time);
            Assert.AreEqual(500, customsDuty);
        }
    }
}

using System;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomDutyPriceCalculator;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnvironmentallyFriendlyCar()
        {
            //setup
            var car = new Vehicle{Weight = 500, VehicleType = VehicleType.Car, EnvironmentallyFriendly = true};
            var time =  new DateTime(2018, 6, 10, 20, 24, 16); //evening

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void EnvironmentallyFriendlyTruck()
        {
            //setup
            var truck = new Vehicle { Weight = 500, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 5, 13, 20, 24, 16); //weekend

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void EnvironmentallyFriendlyMototbike()
        {
            //setup
            var motorbike = new Vehicle { Weight = 500, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 6, 10, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void CarDaytimeOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false};
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(1000, customsDuty);
        }
        [TestMethod]
        public void CarDaytimeUnderLimit()
        {
            //setup
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(500, customsDuty);
        }

        [TestMethod]
        public void MotorbikeDaytimeOverLimit()
        {
            //setup
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(700, customsDuty);
        }

        [TestMethod]
        public void MotorbikeDaytimeUnderLimit()
        {
            //setup
            var motorbike = new Vehicle { Weight = 999, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(350, customsDuty);
        }


        [TestMethod]
        public void TruckDaytime()
        {
            //setup
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(2000, customsDuty);
        }

        [TestMethod]
        public void TruckNight()
        {
            //setup
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 23, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(1000, customsDuty);
        }

        [TestMethod]
        public void TruckWeekend()
        {
            //setup
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 13, 23, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(4000, customsDuty);
        }




        [TestMethod]
        public void CarWeekendOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 12, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(2000, customsDuty);
        }

        [TestMethod]
        public void CarWeekendUnderLimit()
        {
            //setup
            var car = new Vehicle { Weight = 999, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 12, 15, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(1000, customsDuty);
        }


        [TestMethod]
        public void CarNightUnderLimit()
        {
            //setup
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(250, customsDuty);
        }

        [TestMethod]
        public void CarNightOverLimit()
        {
            //setup
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(500, customsDuty);
        }

        [TestMethod]
        public void MotorbikeNightUnderLimit()
        {
            //setup
            var motorbike = new Vehicle { Weight = 750, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(175, customsDuty);
        }

        [TestMethod]
        public void MotorbikeNightOverLimit()
        {
            //setup
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(350, customsDuty);
        }

        [TestMethod]
        public void MotorbikeWeekend()
        {
            //setup
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 13, 20, 24, 16);

            //test
            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(1400, customsDuty);
        }

    }
}

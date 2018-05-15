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
            var car = new Vehicle{Weight = 500, VehicleType = VehicleType.Car, EnvironmentallyFriendly = true};
            var time =  new DateTime(2018, 6, 10, 20, 24, 16); //evening

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void EnvironmentallyFriendlyTruck()
        {
            var truck = new Vehicle { Weight = 500, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 5, 13, 20, 24, 16); //weekend

            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void EnvironmentallyFriendlyMototbike()
        {
            var motorbike = new Vehicle { Weight = 500, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 6, 13, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void CarDaytimeOverLimit()
        {
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false};
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(1000, customsDuty);
        }
        [TestMethod]
        public void CarDaytimeUnderLimit()
        {
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(500, customsDuty);
        }

        [TestMethod]
        public void MotorbikeDaytimeOverLimit()
        {
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(700, customsDuty);
        }

        [TestMethod]
        public void MotorbikeDaytimeUnderLimit()
        {
            var motorbike = new Vehicle { Weight = 999, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(350, customsDuty);
        }


        [TestMethod]
        public void TruckDaytime()
        {
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(2000, customsDuty);
        }

        [TestMethod]
        public void TruckNight()
        {
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 11, 23, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(1000, customsDuty);
        }

        [TestMethod]
        public void TruckWeekend()
        {
            var truck = new Vehicle { Weight = 1250, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 13, 23, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(4000, customsDuty);
        }
        [TestMethod]
        public void CarWeekendOverLimit()
        {
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 12, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(2000, customsDuty);
        }
        [TestMethod]
        public void CarMiddsummerOverLimit()
        {
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 6, 6, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(2000, customsDuty);
        }

        [TestMethod]
        public void CarWeekendUnderLimit()
        {
            var car = new Vehicle { Weight = 999, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 12, 15, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(1000, customsDuty);
        }


        [TestMethod]
        public void CarNightUnderLimit()
        {
            var car = new Vehicle { Weight = 750, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(250, customsDuty);
        }

        [TestMethod]
        public void CarNightOverLimit()
        {
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 18, 01, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(500, customsDuty);
        }

        [TestMethod]
        public void MotorbikeNightUnderLimit()
        {
            var motorbike = new Vehicle { Weight = 750, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(175, customsDuty);
        }

        [TestMethod]
        public void MotorbikeNightOverLimit()
        {
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(350, customsDuty);
        }

        [TestMethod]
        public void MotorbikeWeekend()
        {
            var motorbike = new Vehicle { Weight = 1250, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = false };
            var time = new DateTime(2018, 5, 13, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(1400, customsDuty);
        }

    }
}

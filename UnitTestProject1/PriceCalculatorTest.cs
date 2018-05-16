using System;
using Collector.CustomDutyPriceCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collector.CustomDutyPriceCalculatorTest
{
    [TestClass]
    public class PriceCalculatorTest
    {
        [TestMethod]
        public void When_EnvironmentallyFriendly_Car_Passes_Through_Toll_Price_Should_Be_0()
        {
            var car = new Vehicle{Weight = 500, VehicleType = VehicleType.Car, EnvironmentallyFriendly = true};
            var time =  new DateTime(2018, 6, 10, 20, 24, 16); //evening

            
            var price = new PriceCalculator().CalculatePrice(car, time);
            var expectedPrice = 0;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void When_EnvironmentallyFriendly_Truck_Passes_Through_Toll_Price_Should_Be_0()
        {
            var truck = new Vehicle { Weight = 500, VehicleType = VehicleType.Truck, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 5, 13, 20, 24, 16); //weekend

            var expectedPrice = 0;
            var customsDuty = new PriceCalculator().CalculatePrice(truck, time);
            Assert.AreEqual(expectedPrice, customsDuty);
        }

        [TestMethod]
        public void When_EnvironmentallyFriendly_Motorbike_Passes_Through_Toll_Price_Should_Be_0()
        {
            var motorbike = new Vehicle { Weight = 500, VehicleType = VehicleType.Motorbike, EnvironmentallyFriendly = true };
            var time = new DateTime(2018, 6, 10, 20, 24, 16);

            var customsDuty = new PriceCalculator().CalculatePrice(motorbike, time);
            Assert.AreEqual(0, customsDuty);
        }

        [TestMethod]
        public void When_Car_With_Weight_Over_Limit_Passes_Through_Toll_Daytime_On_Weeddays_Price_Should_Be_1000()
        {
            var car = new Vehicle { Weight = 1250, VehicleType = VehicleType.Car, EnvironmentallyFriendly = false};
            var time = new DateTime(2018, 5, 11, 15, 24, 16);

            var expectedPrice = 1000;
            var customsDuty = new PriceCalculator().CalculatePrice(car, time);
            Assert.AreEqual(expectedPrice, customsDuty);
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
            var time = new DateTime(2018, 5, 7, 20, 24, 16);

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

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Collector.CustomDutyPriceCalculator
{
    public class PriceCalculator
    {
        private readonly Prices _prices;
        private readonly Limits _limits;

        public PriceCalculator()
        {
            _prices = ParsePrices();
            _limits = ParseLimits();
        }

        public double CalculatePrice(Vehicle vehicle, DateTime passThroughTime)
        {
            if (vehicle.EnvironmentallyFriendly)
                return _prices.PriceEnvironmentallyFriendly;

            var weekdayDaytimePrice = CalculateWeekdayDaytimePrice(vehicle);
            var adjustedPriceWeekEnd = AdjustPriceWeekEnd(passThroughTime, weekdayDaytimePrice);
            var adjustedPriceNightWeekday = AdjustPriceNightWeekday(passThroughTime, adjustedPriceWeekEnd);

            return adjustedPriceNightWeekday;
        }

        private double CalculateWeekdayDaytimePrice(Vehicle vehicle)
        {
            double price = (vehicle.Weight >= _limits.WeightLimit) ? _prices.PriceOverLimit : _prices.PriceUnderLimit;

            switch (vehicle.VehicleType)
            {
                case VehicleType.Motorbike:
                    return price * _prices.MotorbikeMultiplyer;
                case VehicleType.Truck:
                    return _prices.TruckPrice;
                default:
                    return price;
            }

        }

        private double AdjustPriceWeekEnd(DateTime time, double price)
        {
            return (ItIsWeedend(time)) ? price * _prices.WeekendMultiplyer : price;
        }

        private bool ItIsWeedend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday);
        }

        private double AdjustPriceNightWeekday(DateTime dateTime, double price)
        {
            if (ItIsWeedend(dateTime))
                return price;
            else if (dateTime.Hour >= _limits.NightLimitEvening)
                return price * _prices.NightMultiplyer;
            else if (dateTime.Hour < _limits.NightLimitMoring)
                return price * _prices.NightMultiplyer;
            else
                return price;
        }

        private Limits ParseLimits()
        {
            using (StreamReader r = new StreamReader(@"C:\Project\CollectorTest\CollectorTest\ClassLibrary1\Limits.json"))
            {
                string json = r.ReadToEnd();
                var constantObject = JsonConvert.DeserializeObject<Limits>(json);
                return constantObject;
            }
        }

        private Prices ParsePrices()
        {
            using (StreamReader r = new StreamReader(@"C:\Project\CollectorTest\CollectorTest\ClassLibrary1\Prices.json"))
            {
                string json = r.ReadToEnd();
                var constantObject = JsonConvert.DeserializeObject<Prices>(json);
                return constantObject;
            }
        }
    }
}

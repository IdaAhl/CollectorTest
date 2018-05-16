﻿using System;

namespace Collector.CustomDutyPriceCalculator
{
    public class PriceCalculator
    {
        private const double PriceEnvironmentallyFriendly = 0;
        private const double PriceOverLimit = 1000;
        private const double PriceUnderLimit = 500;
        private const double WeightLimit = 1000;
        private const double TruckPrice = 2000;
        
        private const int NightLimitEvening = 18;
        private const int NightLimitMoring = 6;

        private const double WeekendMultiplyer = 2 ;
        private const double MotorbikeMultiplyer = 0.7;
        private const double NightMultiplyer = 0.5;


        public double CalculatePrice(Vehicle vehicle, DateTime passThroughTime)
        {
            if(vehicle.EnvironmentallyFriendly)
            return PriceEnvironmentallyFriendly;

            var weekdayDaytimePrice = CalculateWeekdayDaytimePrice(vehicle);
            var adjustedPriceWeekEnd = AdjustPriceWeekEnd(passThroughTime, weekdayDaytimePrice);
            var adjustedPriceNightWeekday = AdjustPriceNightWeekday(passThroughTime, adjustedPriceWeekEnd);

            return adjustedPriceNightWeekday;
        }

        private double CalculateWeekdayDaytimePrice(Vehicle vehicle)
        {
            double price = (vehicle.Weight >= WeightLimit) ? PriceOverLimit : PriceUnderLimit;

            switch (vehicle.VehicleType)
            {
                case VehicleType.Motorbike:
                    return price * MotorbikeMultiplyer;
                case VehicleType.Truck:
                    return TruckPrice;
                default:
                    return price;
            }

        }

        private double AdjustPriceWeekEnd(DateTime time, double price)
        {
            return (ItIsWeedend(time)) ? price * WeekendMultiplyer : price;
        }

        private bool ItIsWeedend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday);
        }

        private double AdjustPriceNightWeekday(DateTime dateTime, double price)
        {
            if (ItIsWeedend(dateTime))
                return price;
            else if (dateTime.Hour >= NightLimitEvening)
                return price * NightMultiplyer;
            else if (dateTime.Hour < NightLimitMoring)
                return price * NightMultiplyer;
            else
                return price;
        }
    }
}

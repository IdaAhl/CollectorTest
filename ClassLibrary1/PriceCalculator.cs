using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CustomDutyPriceCalculator
{
    public class PriceCalculator
    {
        private const double PriceCarOverLimit = 1000;
        private const double PriceCarUnderLimit = 500;
        private const double WeightLimit = 1000;

        private const double TruckPrice = 2000;
        private const double MotorbikeDiscount = 30;
        private const double NightDiscount = 50;
        private const int NightLimitEvening = 17;
        private const int NightLimitMoring = 6;

        private const double WeedendMultiplyer = 2 ;


        public double CalculatePrice(Vehicle vehicle, DateTime dateTime)
        {
            if(vehicle.EnvironmentallyFriendly == true)
            return 0;

            var basePrice = CalculateBasePrice(vehicle);
            var adjustedPriceWeekEnd = AdjustPriceWeekEnd(dateTime, basePrice);
            var adjustedPriceNightWeekday = AdjustPriceNightWeekday(dateTime, adjustedPriceWeekEnd);

            return adjustedPriceNightWeekday;
        }

        private double CalculateBasePrice(Vehicle vehicle)
        {
            if (vehicle.VehicleType == VehicleType.Car && vehicle.Weight >= WeightLimit)
                return PriceCarOverLimit;
            else if (vehicle.VehicleType == VehicleType.Car && vehicle.Weight < WeightLimit)
                return PriceCarUnderLimit;
            else if (vehicle.VehicleType == VehicleType.Motorbike && vehicle.Weight >= WeightLimit)
                return PriceCarOverLimit * (100 - MotorbikeDiscount) / 100;
            else if (vehicle.VehicleType == VehicleType.Motorbike && vehicle.Weight < WeightLimit)
                return PriceCarUnderLimit * (100 - MotorbikeDiscount) / 100;
            else
                return TruckPrice;
        }

        private double AdjustPriceWeekEnd(DateTime time, double price)
        {
            return (ItIsWeedend(time)) ? price * WeedendMultiplyer : price;
        }
        private bool ItIsWeedend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday) ? true : false;
        }

        private double AdjustPriceNightWeekday(DateTime dateTime, double price)
        {
            if (ItIsWeedend(dateTime))
                return price;
            else if (dateTime.Hour > NightLimitEvening)
                return (price * NightDiscount / 100);
            else if (dateTime.Hour < NightLimitMoring)
                return (price * NightDiscount / 100);
            else
                return price;
        }
    }
}

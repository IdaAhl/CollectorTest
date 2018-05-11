using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CustomDutyPriceCalculator
{
    public class PriceCalculator
    {
        private const int PriceCarOverLimit = 1000;
        private const int PriceCarUnderLimit = 500;
        private const int WeightLimit = 1000;

        private const int TruckPrice = 2000;
        private const int MotorbikeDiscount = 30;
        private const int NightDiscount = 50;
        private const int NightLimitEvening = 17;
        private const int NightLimitMoring = 6;

        private const int WeedendMultiplyer = 2 ;


        public int CalculatePrice(Vehicle vehicle, DateTime dateTime)
        {
            if(vehicle.EnvironmentallyFriendly == true)
            return 0;

            var basePrice = CalculateBasePrice(vehicle);
            var adjustedPriceWeekEnd = AdjustPriceWeekEnd(dateTime, basePrice);
            var adjustedPriceNightWeekday = AdjustPriceNightWeekday(dateTime, adjustedPriceWeekEnd);

            return adjustedPriceNightWeekday;
        }

        private int CalculateBasePrice(Vehicle vehicle)
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

        private int AdjustPriceWeekEnd(DateTime time, int price)
        {
            return (ItIsWeedend(time)) ? price * WeedendMultiplyer : price;
        }
        private bool ItIsWeedend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday) ? true : false;
        }

        private int AdjustPriceNightWeekday(DateTime dateTime, int price)
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

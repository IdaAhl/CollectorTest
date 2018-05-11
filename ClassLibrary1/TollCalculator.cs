using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Toll
{
    public class TollCalculator
    {
        private const int CustomFeeCarOverLimit = 1000;
        private const int CustomFooCarUnderLimit = 500;

        private const int WeightLimit = 1000;

        private const int MotorbikeDiscount = 30;
        private const int TruckFee = 2000;
        private const int NightFeeDiscount = 50;
        private const int WeedendFeeExtraMultiplyer = 2 ;


        public int CalculateToll(Vehicle vehicle, DateTime dateTime)
        {
            if(vehicle.EnvironmentallyFriendly == true)
            return 0;

            var basePrice = CalculateBasePrice(vehicle);
            var adjustedPriceEvening = AdjustPriceEvening(dateTime, basePrice);
            var adjustedPriceWeekEnd = AdjustPriceWeekEnd(dateTime, adjustedPriceEvening);
            return adjustedPriceWeekEnd;
        }

        private int AdjustPriceEvening(DateTime dateTime, int basePrice)
        {
            if (!(IsItWeedend(dateTime) && dateTime.Hour > 17 && dateTime.Hour < 6))
            return (basePrice * NightFeeDiscount / 100 );
            else
                return basePrice;
        }

        private int AdjustPriceWeekEnd(DateTime time, int adjustedPriceEvening)
        {
            if (IsItWeedend(time))
            return (adjustedPriceEvening * WeedendFeeExtraMultiplyer);
            else
                return adjustedPriceEvening;
        }

        private int CalculateBasePrice(Vehicle vehicle)
        {
            if (vehicle.VehicleType == VehicleType.car && vehicle.Weight >= WeightLimit)
                return CustomFeeCarOverLimit;
            else if (vehicle.VehicleType == VehicleType.car && vehicle.Weight < WeightLimit)
                return CustomFooCarUnderLimit;
            else if (vehicle.VehicleType == VehicleType.motorbike && vehicle.Weight >= WeightLimit)
                return CustomFeeCarOverLimit * MotorbikeDiscount / 100;
            else if (vehicle.VehicleType == VehicleType.motorbike && vehicle.Weight < WeightLimit)
                return CustomFeeCarOverLimit * MotorbikeDiscount / 100;
            else
                return TruckFee;
        }

        private bool IsItWeedend(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday)
                return true;
            else
                return false;
        }
    }
}

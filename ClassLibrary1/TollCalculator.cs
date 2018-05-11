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

        private const int TruckFee = 2000;
        private const int MotorbikeDiscount = 30;
        private const int NightFeeDiscount = 50;
        private const int NightLimitEvening = 17;
        private const int NightLimitMoring = 6;

        private const int WeedendFeeExtraMultiplyer = 2 ;


        public int CalculateToll(Vehicle vehicle, DateTime dateTime)
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
            if (vehicle.VehicleType == VehicleType.car && vehicle.Weight >= WeightLimit)
                return CustomFeeCarOverLimit;
            else if (vehicle.VehicleType == VehicleType.car && vehicle.Weight < WeightLimit)
                return CustomFooCarUnderLimit;
            else if (vehicle.VehicleType == VehicleType.motorbike && vehicle.Weight >= WeightLimit)
                return CustomFeeCarOverLimit * (100 - MotorbikeDiscount) / 100;
            else if (vehicle.VehicleType == VehicleType.motorbike && vehicle.Weight < WeightLimit)
                return CustomFeeCarOverLimit * (100 - MotorbikeDiscount) / 100;
            else
                return TruckFee;
        }

        private int AdjustPriceWeekEnd(DateTime time, int price)
        {
            return (ItIsWeedend(time)) ? price * WeedendFeeExtraMultiplyer : price;
            //if (ItIsWeedend(time)) 
            //    return (price * WeedendFeeExtraMultiplyer);
            //else
            //    return price;
        }


        private int AdjustPriceNightWeekday(DateTime dateTime, int price)
        {
            if (ItIsWeedend(dateTime))
                return price;
            else if (dateTime.Hour > NightLimitEvening)
                return (price * NightFeeDiscount / 100);
            else if (dateTime.Hour < NightLimitMoring)
                return (price * NightFeeDiscount / 100);
            else
                return price;
        }

      
        

        private bool ItIsWeedend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday) ? true : false;
        }
    }
}

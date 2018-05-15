using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using PublicHoliday;

namespace CustomDutyPriceCalculator
{
    public class PriceCalculator
    {
        private const double PriceEnvironmentallyFriendly = 0;
        private const double PriceTruck = 2000;
        private const double PriceCarOverOrEqualLimit = 1000;
        private const double PriceCarUnderLimit = 500;

        private const double MotorbikeMultiplyer = 0.7;
        private const double WeedendMultiplyer = 2;
        private const double NightMultiplyer = 0.5;

        private const double WeightLimit = 1000;
        private const int NightLimitEvening = 18;
        private const int NightLimitMoring = 6;

        public double CalculatePrice(Vehicle vehicle, DateTime dateTime)
        {
            var weightPrice = CalculateWeightPrice(vehicle);
            var adjustedPriceMotorbike = AdjustedPriceMotorbike(vehicle, weightPrice);
            var adjustedPriceTruck = AdjustedPriceTruck(vehicle, adjustedPriceMotorbike);
            var adjustedPriceWeekendAndPublicHoliday = AdjustPriceWeekendAndPublicHoliday(dateTime, adjustedPriceTruck);
            var adjustPriceNightWeekdays = AdjustPriceNightWeekdays(dateTime, adjustedPriceWeekendAndPublicHoliday);
            var adjustedPriceEnvironmentallyFriendly = AdjustPriceEnvironmentallyFriendly(vehicle, adjustPriceNightWeekdays);
            return adjustedPriceEnvironmentallyFriendly;
        }
        private double CalculateWeightPrice(Vehicle vehicle)
        {
            return (vehicle.Weight >= WeightLimit) ? PriceCarOverOrEqualLimit : PriceCarUnderLimit;
        }
        private double AdjustedPriceMotorbike(Vehicle vehicle, double price)
        {
            return (vehicle.VehicleType == VehicleType.Motorbike) ? price * MotorbikeMultiplyer : price;
        }
        private double AdjustedPriceTruck(Vehicle vehicle, double price)
        {
            return (vehicle.VehicleType == VehicleType.Truck) ? PriceTruck : price;
        }
        private double AdjustPriceWeekendAndPublicHoliday(DateTime time, double price)
        {
            return (ItIsWeedendOrPublicHoliday(time)) ? price * WeedendMultiplyer : price;
        }
        private bool ItIsWeedendOrPublicHoliday(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday)
                return true;

            var holiday = new SwedenPublicHoliday();
            return (holiday.IsPublicHoliday(time)) ? true : false;
        }
        private double AdjustPriceNightWeekdays(DateTime dateTime, double price)
        {
            if (ItIsWeedendOrPublicHoliday(dateTime))
                return price;
            else if (dateTime.Hour >= NightLimitEvening)
                return price * NightMultiplyer;
            else if (dateTime.Hour < NightLimitMoring)
                return price * NightMultiplyer;
            else
                return price;
        }
        private double AdjustPriceEnvironmentallyFriendly(Vehicle vehicle, double price)
        {
            return (vehicle.EnvironmentallyFriendly == true && PriceEnvironmentallyFriendly < price) ? PriceEnvironmentallyFriendly : price;
        }
    }
}
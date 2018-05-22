using System;
using System.Collections.Generic;
using System.Text;

namespace Collector.CustomDutyPriceCalculator
{
    public class Prices
    {
        public double PriceEnvironmentallyFriendly { get; set; }
        public double PriceOverLimit { get; set; }
        public double PriceUnderLimit { get; set; }
        public double TruckPrice { get; set; }
        public double WeekendMultiplyer { get; set; }
        public double MotorbikeMultiplyer { get; set; }
        public double NightMultiplyer { get; set; }
    }
}

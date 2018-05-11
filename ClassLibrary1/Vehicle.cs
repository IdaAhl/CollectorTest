using System;
using System.Collections.Generic;
using System.Text;

namespace Toll
{
    public enum VehicleType
    {
        car,
        motorbike,
        truck
    }

    public class Vehicle
    {
        public int Weight { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool EnvironmentallyFriendly { get; set; }
    }
}

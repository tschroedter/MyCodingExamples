using System;
using JetBrains.Annotations;

namespace ParkIQ.SecureParking
{
    public class CarParkIsFullException : Exception
    {
        public CarParkIsFullException([NotNull] IVehicle vehicle)
            :
                base("Car park is full!")
        {
            Vehicle = vehicle;
        }

        public IVehicle Vehicle { get; private set; }
    }
}
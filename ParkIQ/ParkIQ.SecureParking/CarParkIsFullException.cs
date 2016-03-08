using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class CarParkIsFullException : Exception
    {
        public CarParkIsFullException([NotNull] INewVehicle vehicle)
            :
                base("Car park is full!")
        {
            Vehicle = vehicle;
        }

        public INewVehicle Vehicle { get; private set; }
    }
}
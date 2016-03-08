using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class CarDidNotPayFeeException : Exception
    {
        public CarDidNotPayFeeException([NotNull] INewVehicle vehicle)
            :
                base("Car didn't pay the fee!")
        {
            Vehicle = vehicle;
        }

        public INewVehicle Vehicle { get; private set; }
    }
}
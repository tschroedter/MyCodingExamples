using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class NoVehicleFoundInBaysException : Exception
    {
        public NoVehicleFoundInBaysException([NotNull] INewVehicle vehicle)
            :
                base("There is no bay with the car in the car park!")
        {
            Vehicle = vehicle;
        }

        public INewVehicle Vehicle { get; private set; }
    }
}
using System;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class NoEmptyBayException : Exception
    {
        public NoEmptyBayException([NotNull] INewVehicle vehicle)
            :
                base("There is no empty bay!")
        {
            Vehicle = vehicle;
        }

        public INewVehicle Vehicle { get; private set; }
    }
}
using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public interface IBaysManager
    {
        [NotNull]
        IEnumerable <IBay> Bays { get; }

        int NumberOfBays { get; }
        int NumberOfEmptyBays { get; }
        int NumberOfOccupiedBays { get; }
        bool IsFull { get; }

        [NotNull]
        IEnumerable<INewVehicle> Vehicles { get; }

        void AssignBay([NotNull] INewVehicle vehicle);
        void ReleaseBay([NotNull] INewVehicle vehicle);
        int FindVehicleBayId([NotNull] INewVehicle vehicle);
    }
}
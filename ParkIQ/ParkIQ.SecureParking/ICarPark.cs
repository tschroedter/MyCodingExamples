using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public interface ICarPark
    {
        string Name { get; }
        IEnumerable <IBay> Bays { get; }
        IEnumerable<INewVehicle> Vehicles { get; }
        int NumberOfBays { get; }
        int NumberOfOccupiedBays { get; }
        bool IsFull { get; }
        void Enter([NotNull] INewVehicle vehicle);
        void Exit([NotNull] INewVehicle vehicle);
    }
}
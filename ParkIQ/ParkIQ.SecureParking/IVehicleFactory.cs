using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public interface IVehicleFactory
    {
        IVehicle Create(VehicleFactory.VehicleType vehicleType,
                        int weightInKilogram);

        void Release([NotNull] IVehicle fee);
    }
}
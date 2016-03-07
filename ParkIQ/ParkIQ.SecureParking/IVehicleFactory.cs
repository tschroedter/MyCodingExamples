using JetBrains.Annotations;

namespace ParkIQ.SecureParking
{
    public interface IVehicleFactory
    {
        IVehicle Create(VehicleFactory.VehicleType vehicleType,
                        int weightInKilogram);

        void Release([NotNull] IVehicle fee);
    }
}
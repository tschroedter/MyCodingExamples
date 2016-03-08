using JetBrains.Annotations;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public class Truck : BaseVehicle
    {
        public Truck([NotNull] IVehicleFees vehicleFees,
                     int id,
                     int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "Truck";
        }
    }
}
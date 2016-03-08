using JetBrains.Annotations;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public class Motorbike : BaseVehicle
    {
        public Motorbike([NotNull] IVehicleFees vehicleFees,
                         int id,
                         int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "Motorbike";
        }
    }
}
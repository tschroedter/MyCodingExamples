using JetBrains.Annotations;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public class StandardCar
        : BaseVehicle,
          IStandardCar
    {
        public StandardCar([NotNull] IVehicleFees vehicleFees,
                           int id,
                           int weightInKilogram)
            : base(vehicleFees,
                   id,
                   weightInKilogram)
        {
            ShortDescription = "StandardCar";
        }
    }
}
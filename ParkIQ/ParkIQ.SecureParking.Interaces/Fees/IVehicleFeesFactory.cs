using JetBrains.Annotations;
using ParkIQ.SecureParking.Interaces.Fees;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    public interface IVehicleFeesFactory : ITypedFactory
    {
        IVehicleFees Create();
        void Release([NotNull] IVehicleFees vehicleFees);
    }
}
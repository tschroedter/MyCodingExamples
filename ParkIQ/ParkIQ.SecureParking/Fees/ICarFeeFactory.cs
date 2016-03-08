using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Fees
{
    public interface ICarFeeFactory
    {
        IFee Create([NotNull] IVehicle vehicle);
        void Release([NotNull] IFee fee);
    }
}
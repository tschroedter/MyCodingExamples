using JetBrains.Annotations;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Fees
{
    public interface ICarFeeFactory
    {
        IFee Create([NotNull] INewVehicle vehicle);
        void Release([NotNull] IFee fee);
    }
}
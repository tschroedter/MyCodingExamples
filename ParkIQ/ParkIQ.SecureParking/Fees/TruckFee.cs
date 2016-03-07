using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class TruckFee : BaseCarFee
    {
        public TruckFee([NotNull] IVehicle vehicle)
            : base(vehicle)
        {
        }

        internal override int CalculateCharge()
        {
            return VehicleFee + 10;
        }
    }
}
using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class MotorbikeFee : BaseCarFee
    {
        public MotorbikeFee([NotNull] IVehicle vehicle)
            : base(vehicle)
        {
        }

        internal override int CalculateCharge()
        {
            return VehicleFee + 2;
        }
    }
}
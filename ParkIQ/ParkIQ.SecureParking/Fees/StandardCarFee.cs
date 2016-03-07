using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class StandardCarFee : BaseCarFee
    {
        public StandardCarFee([NotNull] IVehicle vehicle)
            : base(vehicle)
        {
        }

        internal override int CalculateCharge()
        {
            return VehicleFee + 5;
        }
    }
}
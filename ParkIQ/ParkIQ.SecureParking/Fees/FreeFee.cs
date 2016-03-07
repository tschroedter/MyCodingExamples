using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class FreeFee : BaseCarFee
    {
        public FreeFee([NotNull] IVehicle vehicle)
            : base(vehicle)
        {
        }

        public override int Calculate()
        {
            return 0;
        }

        internal override int CalculateCharge()
        {
            return 0;
        }
    }
}
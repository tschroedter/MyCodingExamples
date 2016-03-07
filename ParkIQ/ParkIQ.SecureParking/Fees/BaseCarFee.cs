using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public abstract class BaseCarFee : IFee
    {
        protected const int ThreeDollars = 3;
        protected const int ZeroDollars = 0;
        protected const int VehicleFee = 2;
        protected const int MinimumWeightForExtraChargeInKilogram = 100;

        protected BaseCarFee([NotNull] IVehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public IVehicle Vehicle { get; set; }

        public bool IsPaid { get; private set; }

        public virtual int Calculate()
        {
            int charge = CalculateCharge();
            int extraCharge = CalculateExtraCharge();

            return charge + extraCharge;
        }

        public void FeeIsPaid()
        {
            IsPaid = true;
        }

        protected int CalculateExtraCharge()
        {
            if ( Vehicle.WeightInKilogram > MinimumWeightForExtraChargeInKilogram )
            {
                return ThreeDollars;
            }

            return ZeroDollars; // todo IExtraCarFee
        }

        internal abstract int CalculateCharge();
    }
}
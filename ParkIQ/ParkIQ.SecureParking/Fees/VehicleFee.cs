namespace ParkIQ.SecureParking.Fees
{
    public class VehicleFee : IFee
    {
        private const int TwoDollars = 2;

        public int Calculate()
        {
            return TwoDollars;
        }
    }
}
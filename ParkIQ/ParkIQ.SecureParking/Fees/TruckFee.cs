namespace ParkIQ.SecureParking.Fees
{
    public class TruckFee : IFee
    {
        private const int TenDollars = 10;

        public int Calculate()
        {
            return TenDollars;
        }
    }
}
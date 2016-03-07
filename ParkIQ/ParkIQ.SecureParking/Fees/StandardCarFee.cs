namespace ParkIQ.SecureParking.Fees
{
    public class StandardCarFee : IFee
    {
        private const int FiveDollars = 5;

        public int Calculate()
        {
            return FiveDollars;
        }
    }
}
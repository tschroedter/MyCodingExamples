namespace ParkIQ.SecureParking.Fees
{
    public class WeightFee : IFee
    {
        private const int ThreeDollars = 3;

        public int Calculate()
        {
            return ThreeDollars;
        }
    }
}
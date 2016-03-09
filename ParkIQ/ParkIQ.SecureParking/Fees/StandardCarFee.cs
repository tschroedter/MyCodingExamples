using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class StandardCarFee : IStandardCarFee
    {
        private const int FiveDollars = 5;

        public int Calculate()
        {
            return FiveDollars;
        }
    }
}
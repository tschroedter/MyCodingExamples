using System.Collections.Generic;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class FeeCalculator : IFeeCalculator
    {
        public int Calulate(IEnumerable <IFee> fees)
        {
            var sum = 0;

            foreach ( IFee fee in fees )
            {
                sum += fee.Calculate();
            }

            return sum;
        }
    }
}
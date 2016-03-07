using System.Collections.Generic;

namespace ParkIQ.SecureParking.Fees
{
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
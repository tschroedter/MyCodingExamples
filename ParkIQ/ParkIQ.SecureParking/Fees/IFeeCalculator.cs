using System.Collections.Generic;
using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public interface IFeeCalculator
    {
        int Calulate([NotNull] IEnumerable <IFee> fees);
    }
}
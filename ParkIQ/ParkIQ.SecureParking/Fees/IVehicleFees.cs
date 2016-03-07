using System.Collections.Generic;
using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public interface IVehicleFees
    {
        IEnumerable <IFee> Fees { get; }
        bool IsPaid { get; }
        void AddFee(IFee fee);
        void RemoveFee(IFee fee);
        bool ContainsFee(IFee fee);
        void FeeIsPaid();
        int Calulate();
    }
}
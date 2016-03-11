using System.Collections.Generic;

namespace ParkIQ.SecureParking.Interaces.Fees
{
    public interface IVehicleFees
    {
        IEnumerable <IFee> Fees { get; }
        bool IsFeePaid { get; }
        void AddFee(IFee fee);
        void RemoveFee(IFee fee);
        bool ContainsFee(IFee fee);
        void FeeIsPaid();
        int Calulate();
    }
}
namespace ParkIQ.SecureParking.Fees
{
    public interface IFee
    {
        bool IsPaid { get; }
        int Calculate();
        void FeeIsPaid();
    }
}
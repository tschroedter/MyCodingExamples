using JetBrains.Annotations;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking
{
    public interface IVehicle
    {
        VehicleFactory.VehicleType VehicleType { get; }
        int WeightInKilogram { get; }

        [NotNull]
        IFee Fee { get; }

        bool IsFeePaid { get; }
        int Id { get; }

        void SetFee([NotNull] IFee fee); // todo remove
        void PaysFee();

        void AddFee([NotNull] IFee fee);
    }
}
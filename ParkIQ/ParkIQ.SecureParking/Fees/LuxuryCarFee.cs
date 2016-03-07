using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class LuxuryCarFee : BaseCarFee
    {
        private readonly StandardCarFee m_StandardCar; // todo not nice

        public LuxuryCarFee([NotNull] IVehicle vehicle)
            : base(vehicle)
        {
            m_StandardCar = new StandardCarFee(vehicle);
        }

        internal override int CalculateCharge()
        {
            return m_StandardCar.CalculateCharge() + 3;
        }
    }
}
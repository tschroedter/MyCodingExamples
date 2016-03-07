using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class LuxuryCarFee : IFee
    {
        private const int ThreeDollars = 3;

        private readonly StandardCarFee m_StandardCar;

        public LuxuryCarFee([NotNull] StandardCarFee standardCarFee)
        {
            m_StandardCar = standardCarFee;
        }

        public int Calculate()
        {
            return m_StandardCar.Calculate() + ThreeDollars;
        }
    }
}
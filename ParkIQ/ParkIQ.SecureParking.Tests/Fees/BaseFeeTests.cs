using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    internal class BaseFeeTests <T>
        where T : IFee
    {
        private CarFeeFactory <T> m_Factory;

        private IVehicle m_Vehicle;

        [SetUp]
        public void Setup()
        {
            m_Factory = new CarFeeFactory <T>();
            m_Vehicle = Substitute.For <IVehicle>();
        }

        internal IFee CreateSutWithNoExtraCharge()
        {
            m_Vehicle.WeightInKilogram.Returns(100);

            IFee sut = m_Factory.Create(m_Vehicle);
            return sut;
        }

        internal IFee CreateSutWithExtraCharge()
        {
            m_Vehicle.WeightInKilogram.Returns(101);

            IFee sut = m_Factory.Create(m_Vehicle);
            return sut;
        }
    }
}
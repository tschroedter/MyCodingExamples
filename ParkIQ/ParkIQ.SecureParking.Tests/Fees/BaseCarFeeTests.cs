using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class BaseCarFeeTests
    {
        [SetUp]
        public void Setup()
        {
            m_Vehicle = Substitute.For <IVehicle>();
        }

        private IVehicle m_Vehicle;

        private class TestBaseCarFee : BaseCarFee
        {
            public TestBaseCarFee([NotNull] IVehicle vehicle)
                : base(vehicle)
            {
            }

            internal override int CalculateCharge()
            {
                return VehicleFee;
            }
        }

        private TestBaseCarFee CreateSutWithNoExtraCharge()
        {
            m_Vehicle.WeightInKilogram.Returns(100);

            var sut = new TestBaseCarFee(m_Vehicle);
            return sut;
        }

        private TestBaseCarFee CreateSutWithExtraCharge()
        {
            m_Vehicle.WeightInKilogram.Returns(101);

            var sut = new TestBaseCarFee(m_Vehicle);
            return sut;
        }

        [Test]
        public void Calculate_ReturnsCorrectCharge_ForExtraCharges()
        {
            // Arrange
            TestBaseCarFee sut = CreateSutWithExtraCharge();

            // Act
            int actual = sut.CalculateCharge();

            // Assert
            Assert.AreEqual(2,
                            actual);
        }

        [Test]
        public void Calculate_ReturnsCorrectCharge_ForNoExtraCharges()
        {
            // Arrange
            TestBaseCarFee sut = CreateSutWithNoExtraCharge();

            // Act
            int actual = sut.CalculateCharge();

            // Assert
            Assert.AreEqual(2,
                            actual);
        }

        [Test]
        public void Calculate_ReturnsFee_ForFeeIsNotPaid()
        {
            // Arrange
            TestBaseCarFee sut = CreateSutWithNoExtraCharge();

            // Act
            int actual = sut.Calculate();

            // Assert
            Assert.AreEqual(2,
                            actual);
        }

        [Test]
        public void CalculateCharge_ReturnsVehicleFeeOnly_WhenCalled()
        {
            // Arrange
            TestBaseCarFee sut = CreateSutWithNoExtraCharge();

            // Act
            int actual = sut.CalculateCharge();

            // Assert
            Assert.AreEqual(2,
                            actual);
        }

        [Test]
        public void IsPaid_ReturnsFalseByDefault_WhenCalled()
        {
            // Arrange
            // Act
            TestBaseCarFee sut = CreateSutWithExtraCharge();

            // Assert
            Assert.False(sut.IsPaid);
        }

        [Test]
        public void IsPaid_ReturnsTrue_ForFeeIsPaid()
        {
            // Arrange
            TestBaseCarFee sut = CreateSutWithExtraCharge();

            // Act
            sut.FeeIsPaid();

            // Assert
            Assert.True(sut.IsPaid);
        }
    }
}
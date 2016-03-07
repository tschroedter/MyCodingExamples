using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class FreeFeeTests : BaseFeeTests <FreeFee>
    {
        [Test]
        public void Calculate_ReturnsCorrectCharge_ForExtraCharges()
        {
            // Arrange
            IFee sut = CreateSutWithExtraCharge();

            // Act
            int actual = sut.Calculate();

            // Assert
            Assert.AreEqual(0,
                            actual);
        }

        [Test]
        public void Calculate_ReturnsCorrectCharge_ForNoExtraCharges()
        {
            // Arrange
            IFee sut = CreateSutWithNoExtraCharge();

            // Act
            int actual = sut.Calculate();

            // Assert
            Assert.AreEqual(0,
                            actual);
        }
    }
}
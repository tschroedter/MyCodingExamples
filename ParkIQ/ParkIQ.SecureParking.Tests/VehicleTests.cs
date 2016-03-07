using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
// using VehicleType = ParkIQ.SecureParking.VehicleFactory.VehicleType; // todo figure out why ReSharper remove using when doing Code Clean-Up

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class VehicleTests
    {
        private IVehicleFees m_VehicleFees;

        [SetUp]
        public void Setup()
        {
            m_VehicleFees = Substitute.For <IVehicleFees>();
        }

        private Vehicle CreateSut()
        {
            var sut = new Vehicle(m_VehicleFees,
                                  1,
                                  100,
                                  VehicleFactory.VehicleType.StandardCar);
            return sut;
        }

        [Test]
        public void Constructor_SetsId_WhenCalled()
        {
            // Arrange
            Vehicle sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(1,
                            sut.Id);
        }

        [Test]
        public void Constructor_SetsVehicleType_WhenCalled()
        {
            // Arrange
            // Act
            Vehicle sut = CreateSut();

            // Assert
            Assert.AreEqual(VehicleFactory.VehicleType.StandardCar,
                            sut.VehicleType);
        }

        [Test]
        public void Constructor_SetsWeightInKilogram_WhenCalled()
        {
            // Arrange
            // Act
            Vehicle sut = CreateSut();

            // Assert
            Assert.AreEqual(100,
                            sut.WeightInKilogram);
        }

        [Test]
        public void IsFeePaid_CallsFee_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            fee.IsPaid.Returns(true);
            Vehicle sut = CreateSut();
            sut.SetFee(fee);

            // Act
            // Assert
            Assert.True(sut.IsFeePaid);
        }

        [Test]
        public void PaysFee_CallsFeeIsPaid_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            Vehicle sut = CreateSut();
            sut.SetFee(fee);

            // Act
            sut.PaysFee();

            // Assert
            fee.Received().FeeIsPaid();
        }

        [Test]
        public void SetFee_SetsFee_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            Vehicle sut = CreateSut();

            // Act
            sut.SetFee(fee);

            // Assert
            Assert.AreEqual(fee,
                            sut.Fee);
        }

        [Test]
        public void ToString_ReturnsString_WhenCalled()
        {
            // Arrange
            Vehicle sut = CreateSut();

            // Act
            string actual = sut.ToString();

            // Assert
            Assert.AreEqual("Id: 1 VehicleType: StandardCar Fees: 0 IsFeePaid: False",
                            actual);
        }

        [Test]
        public void AddFee_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For<IFee>();
            Vehicle sut = CreateSut();

            // Act
            sut.AddFee(fee);

            // Assert
            m_VehicleFees.Received().AddFee(fee);
        }

    }
}
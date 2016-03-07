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
        [SetUp]
        public void Setup()
        {
            m_VehicleFees = Substitute.For <IVehicleFees>();
        }

        private IVehicleFees m_VehicleFees;

        private Vehicle CreateSut()
        {
            var sut = new Vehicle(m_VehicleFees,
                                  1,
                                  100,
                                  VehicleFactory.VehicleType.StandardCar);
            return sut;
        }

        [Test]
        public void AddFee_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            Vehicle sut = CreateSut();

            // Act
            sut.AddFee(fee);

            // Assert
            m_VehicleFees.Received().AddFee(fee);
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
        public void ContainsFee_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            var fee = Substitute.For <IFee>();
            Vehicle sut = CreateSut();

            // Act
            sut.ContainsFee(fee);

            // Assert
            m_VehicleFees.Received().ContainsFee(fee);
        }

        [Test]
        public void Fees_ReturnsFees_WhenCalled()
        {
            // Arrange
            var expected = new IFee[0];
            m_VehicleFees.Fees.Returns(expected);
            Vehicle sut = CreateSut();

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.Fees);
        }

        [Test]
        public void IsFeePaid_CallsFee_WhenCalled()
        {
            // Arrange
            m_VehicleFees.IsPaid.Returns(true);
            Vehicle sut = CreateSut();

            // Act
            // Assert
            Assert.True(sut.IsFeePaid);
        }

        [Test]
        public void PaysFee_CallsVehicleFees_WhenCalled()
        {
            // Arrange
            Vehicle sut = CreateSut();

            // Act
            sut.PaysFee();

            // Assert
            m_VehicleFees.Received().FeeIsPaid();
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
    }
}
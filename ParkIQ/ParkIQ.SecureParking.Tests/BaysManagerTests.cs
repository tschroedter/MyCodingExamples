using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class BaysManagerTests
    {
        [Test]
        public void AssignBay_AssignsVehiclesToDifferetBays_ForVehicles()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var vehicleTwo = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);

            // Act
            sut.AssignBay(vehicleOne);
            sut.AssignBay(vehicleTwo);

            // Assert
            Assert.AreEqual(0,
                            sut.FindVehicleBayId(vehicleOne),
                            "vehicleOne");

            Assert.AreEqual(1,
                            sut.FindVehicleBayId(vehicleTwo),
                            "vehicleTwo");
        }

        [Test]
        public void AssignBay_AssignsVehicleToBay_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);

            // Act
            sut.AssignBay(vehicle);

            // Assert
            Assert.AreEqual(0,
                            sut.FindVehicleBayId(vehicle));
        }

        [Test]
        public void AssignBay_DecreasesNumberOfEmptyBays_ForVehicle()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);

            // Act
            sut.AssignBay(vehicleOne);

            // Assert
            Assert.AreEqual(2,
                            sut.NumberOfEmptyBays);
        }

        [Test]
        public void AssignBay_IncreasedNumberOfOccupiedBays_ForVehicle()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);

            // Act
            sut.AssignBay(vehicleOne);

            // Assert
            Assert.AreEqual(1,
                            sut.NumberOfOccupiedBays);
        }

        [Test]
        public void AssignBay_ThrowsException_ForNoEmptyBayLeft()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var vehicleTwo = Substitute.For <IVehicle>();
            var sut = new BaysManager(1);
            sut.AssignBay(vehicleOne);

            // Act
            // Assert
            Assert.Throws <NoEmptyBayException>(() => sut.AssignBay(vehicleTwo));
        }

        [Test]
        public void Constructor_CreatesBays_WhenCalled()
        {
            // Arrange
            // Act
            var sut = new BaysManager(3);

            // Assert
            Assert.AreEqual(3,
                            sut.NumberOfBays);
        }

        [Test]
        public void Constructor_CreatesEmptyBays_WhenCalled()
        {
            // Arrange
            // Act
            var sut = new BaysManager(3);

            // Assert
            Assert.AreEqual(3,
                            sut.NumberOfEmptyBays);
        }

        [Test]
        public void IsFull_ReturnsFalse_WhenEmptyBaysAreAvailable()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var sut = new BaysManager(2);
            sut.AssignBay(vehicleOne);

            // Act
            // Assert
            Assert.False(sut.IsFull);
        }

        [Test]
        public void IsFull_ReturnsTrue_WhenAllBaysAreOccupied()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var sut = new BaysManager(1);
            sut.AssignBay(vehicleOne);

            // Act
            // Assert
            Assert.True(sut.IsFull);
        }

        [Test]
        public void ReleaseBay_MarksBayAsEmpty_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);
            sut.AssignBay(vehicle);

            // Act
            sut.ReleaseBay(vehicle);

            // Assert
            Assert.AreEqual(3,
                            sut.NumberOfEmptyBays);
        }

        [Test]
        public void ReleaseBay_ReleasesBayFromVehicle_ForVehicle()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);
            sut.AssignBay(vehicle);

            // Act
            sut.ReleaseBay(vehicle);

            // Assert
            Assert.Throws <NoVehicleFoundInBaysException>(() => sut.FindVehicleBayId(vehicle));
        }

        [Test]
        public void ReleaseBay_ThrowsException_ForVehicleIsNotInCarPark()
        {
            // Arrange
            var vehicle = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);

            // Act
            // Assert
            Assert.Throws <NoVehicleFoundInBaysException>(() => sut.ReleaseBay(vehicle));
        }

        [Test]
        public void Vehicles_ReturnsVehiclesInBays_WhenCalled()
        {
            // Arrange
            var vehicleOne = Substitute.For <IVehicle>();
            var vehicleTwo = Substitute.For <IVehicle>();
            var sut = new BaysManager(3);
            sut.AssignBay(vehicleOne);
            sut.AssignBay(vehicleTwo);

            // Act
            IVehicle[] actual = sut.Vehicles.ToArray();

            // Assert
            Assert.AreEqual(2,
                            actual.Length,
                            "Length");
            Assert.AreEqual(vehicleOne,
                            actual.First(),
                            "vehicleOne");
            Assert.AreEqual(vehicleTwo,
                            actual.Last(),
                            "vehicleTwo");
        }
    }
}
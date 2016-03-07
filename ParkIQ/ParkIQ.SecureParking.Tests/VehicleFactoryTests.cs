using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class VehicleFactoryTests
    {
        private const int DoesNotMatterWeight = 100;

        [Test]
        public void Create_ReturnsVehicleWithCorrectWeight_ForGivenWeight()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.StandardCar,
                                         DoesNotMatterWeight);

            // Assert
            Assert.AreEqual(DoesNotMatterWeight,
                            actual.WeightInKilogram);
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForSameVehicleType()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle one = sut.Create(VehicleFactory.VehicleType.Truck,
                                      DoesNotMatterWeight);
            IVehicle two = sut.Create(VehicleFactory.VehicleType.Truck,
                                      DoesNotMatterWeight);

            // Assert
            Assert.AreNotEqual(one.Id,
                               two.Id);
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForVehicles()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle one = sut.Create(VehicleFactory.VehicleType.StandardCar,
                                      DoesNotMatterWeight);
            IVehicle two = sut.Create(VehicleFactory.VehicleType.LuxuryCar,
                                      DoesNotMatterWeight);
            IVehicle three = sut.Create(VehicleFactory.VehicleType.Motorbike,
                                        DoesNotMatterWeight);
            IVehicle four = sut.Create(VehicleFactory.VehicleType.Truck,
                                       DoesNotMatterWeight);

            // Assert
            Assert.AreEqual(1,
                            one.Id,
                            "one.Id");
            Assert.AreEqual(2,
                            two.Id,
                            "two.Id");
            Assert.AreEqual(3,
                            three.Id,
                            "three.Id");
            Assert.AreEqual(4,
                            four.Id,
                            "four.Id");
        }

        [Test]
        public void Create_ReturnsVehicleWithLuxuryCarFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.LuxuryCar,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fee is LuxuryCarFee);
        }

        [Test]
        public void Create_ReturnsVehicleWithMotorbikeFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.Motorbike,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fee is MotorbikeFee);
        }

        [Test]
        public void Create_ReturnsVehicleWithStandardCarFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.StandardCar,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fee is StandardCarFee);
        }

        [Test]
        public void Create_ReturnsVehicleWithTruckFee_ForVehicleTypeTruck()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.Truck,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fee is TruckFee);
        }
    }
}
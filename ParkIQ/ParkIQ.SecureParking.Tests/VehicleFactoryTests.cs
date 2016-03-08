using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class VehicleFactoryTests
    {
        private const int DoesNotMatterWeight = 100;
        private const int MinWeightInKilogramToForceWeightFee = 101;


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
            Assert.True(actual.Fees.Any(x => x is LuxuryCarFee));
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
            Assert.True(actual.Fees.Any(x => x is MotorbikeFee));
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
            Assert.True(actual.Fees.Any(x => x is StandardCarFee));
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
            Assert.True(actual.Fees.Any(x => x is TruckFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.LuxuryCar,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.Motorbike,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.StandardCar,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeTruck()
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(VehicleFactory.VehicleType.Truck,
                                         DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        [TestCase(VehicleFactory.VehicleType.StandardCar)]
        [TestCase(VehicleFactory.VehicleType.LuxuryCar)]
        [TestCase(VehicleFactory.VehicleType.Motorbike)]
        [TestCase(VehicleFactory.VehicleType.Truck)]
        public void Create_ReturnsVehicleWithWeightFee_ForHeavyVehicle(VehicleFactory.VehicleType vehicleType)
        {
            // Arrange
            var sut = new VehicleFactory();

            // Act
            IVehicle actual = sut.Create(vehicleType,
                                         MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is WeightFee));
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Tests.Vehicles
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class NewVehicleFactoryTests
    {
        private const int DoesNotMatterWeight = 100;
        private const int MinWeightInKilogramToForceWeightFee = 101;


        [Test]
        public void Create_ReturnsVehicleWithCorrectWeight_ForGivenWeight()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <StandardCar>(DoesNotMatterWeight);

            // Assert
            Assert.AreEqual(DoesNotMatterWeight,
                            actual.WeightInKilogram);
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForSameVehicleType()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var one = sut.Create <Truck>(DoesNotMatterWeight);
            var two = sut.Create <Truck>(DoesNotMatterWeight);

            // Assert
            Assert.AreNotEqual(one.Id,
                               two.Id);
        }

        [Test]
        public void Create_ReturnsVehicleWithDifferentIds_ForVehicles()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var one = sut.Create <StandardCar>(DoesNotMatterWeight);
            var two = sut.Create <LuxuryCar>(DoesNotMatterWeight);
            var three = sut.Create <Motorbike>(DoesNotMatterWeight);
            var four = sut.Create <Truck>(DoesNotMatterWeight);

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
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <LuxuryCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is LuxuryCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithMotorbikeFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Motorbike>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is MotorbikeFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithStandardCarFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <StandardCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is StandardCarFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithTruckFee_ForVehicleTypeTruck()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Truck>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is TruckFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeLuxuryCar()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <LuxuryCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeMotorbike()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Motorbike>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeStandardCar()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <StandardCar>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithVehicleFee_ForVehicleTypeTruck()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Truck>(DoesNotMatterWeight);

            // Assert
            Assert.True(actual.Fees.Any(x => x is VehicleFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForLuxuryCarAndHeavyVehicle()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <LuxuryCar>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is WeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForMotorbikeAndHeavyVehicle()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Motorbike>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is WeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForStandardCarAndHeavyVehicle()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <StandardCar>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is WeightFee));
        }

        [Test]
        public void Create_ReturnsVehicleWithWeightFee_ForTruckAndHeavyVehicle()
        {
            // Arrange
            var sut = new NewVehicleFactory();

            // Act
            var actual = sut.Create <Truck>(MinWeightInKilogramToForceWeightFee);

            // Assert
            Assert.True(actual.Fees.Any(x => x is WeightFee));
        }
    }
}
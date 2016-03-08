using System;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class VehicleFactory : IVehicleFactory
    {
        public enum VehicleType // todo replace with classes
        {
            StandardCar,
            LuxuryCar,
            Motorbike,
            Truck
        }

        private int m_NextId = 1;

        public IVehicle Create(VehicleType vehicleType,
                               int weightInKilogram)
        {
            switch ( vehicleType )
            {
                case VehicleType.StandardCar:
                    return CreateStandardCar(weightInKilogram);

                case VehicleType.LuxuryCar:
                    return CreateLuxuryCar(weightInKilogram);

                case VehicleType.Motorbike:
                    return CreateMotorbike(weightInKilogram);

                case VehicleType.Truck:
                    return CreateTruck(weightInKilogram);

                default:
                    throw new ArgumentException("Unknown vehicle type '{0}'!".Inject(vehicleType));
            }
        }

        public void Release(IVehicle fee)
        {
            // nothing to do at the moment
        }

        private IVehicle CreateStandardCar(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.StandardCar);

            AddCommonFees(weightInKilogram,
                          vehicle);

            vehicle.AddFee(new StandardCarFee());

            return vehicle;
        }

        private IVehicle CreateLuxuryCar(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.LuxuryCar);

            AddCommonFees(weightInKilogram,
                          vehicle);

            vehicle.AddFee(new LuxuryCarFee(new StandardCarFee()));

            return vehicle;
        }

        private IVehicle CreateMotorbike(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.Motorbike);

            AddCommonFees(weightInKilogram,
                          vehicle);

            vehicle.AddFee(new MotorbikeFee());

            return vehicle;
        }

        private IVehicle CreateTruck(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.Truck);

            AddCommonFees(weightInKilogram,
                          vehicle);

            vehicle.AddFee(new TruckFee());

            return vehicle;
        }

        private static void AddCommonFees(int weightInKilogram,
                                          IVehicle vehicle)
        {
            AddWeightFeeIfRequired(weightInKilogram,
                                   vehicle);

            vehicle.AddFee(new VehicleFee());
        }

        private IVehicleFees CreateVehicleFees()
        {
            return new VehicleFees(new FeeCalculator());
        }

        private static void AddWeightFeeIfRequired(int weightInKilogram,
                                                   IVehicle vehicle)
        {
            if ( weightInKilogram > 100 )
            {
                vehicle.AddFee(new WeightFee());
            }
        }

        private int GetNextId()
        {
            return m_NextId++;
        }
    }

    public interface INewVehicleFactory
    {
    }
}
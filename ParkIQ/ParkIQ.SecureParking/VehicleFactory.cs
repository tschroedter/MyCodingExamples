using System;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking
{
    public class VehicleFactory : IVehicleFactory
    {
        public enum VehicleType
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
            IFee fee = new StandardCarFee(vehicle);
            vehicle.SetFee(fee);
            return vehicle;
        }

        private IVehicle CreateLuxuryCar(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.LuxuryCar);
            IFee fee = new LuxuryCarFee(vehicle);
            vehicle.SetFee(fee);
            return vehicle;
        }

        private IVehicle CreateMotorbike(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.Motorbike);
            IFee fee = new MotorbikeFee(vehicle);
            vehicle.SetFee(fee);
            return vehicle;
        }

        private IVehicle CreateTruck(int weightInKilogram)
        {
            IVehicle vehicle = new Vehicle(CreateVehicleFees(),
                                           GetNextId(),
                                           weightInKilogram,
                                           VehicleType.Truck);
            IFee fee = new TruckFee(vehicle);
            vehicle.SetFee(fee);
            return vehicle;
        }

        private IVehicleFees CreateVehicleFees()
        {
            return new VehicleFees(new FeeCalculator());
        }

        private int GetNextId()
        {
            return m_NextId++;
        }
    }
}
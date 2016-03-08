using System;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public class VehicleFactory : IVehicleFactory
    {
        private int m_NextId = 1;

        public T Create <T>(int weightInKilogram) where T : IVehicle
        {
            // todo castle windsor factory
            if ( typeof ( T ) == typeof ( StandardCar ) )
            {
                return ( T ) CreateStandardCar(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( LuxuryCar ) )
            {
                return ( T ) CreateLuxuryCar(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( Motorbike ) )
            {
                return ( T ) CreateMotorbike(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( Truck ) )
            {
                return ( T ) CreateTruck(weightInKilogram);
            }

            throw new ArgumentException("Can't create vehicle for type '{0}'!".Inject(typeof ( T )));
        }

        private IVehicle CreateStandardCar(int weightInKilogram)
        {
            IVehicle vehicle = new StandardCar(CreateVehicleFees(),
                                               GetNextId(),
                                               weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(new StandardCarFee());

            return vehicle;
        }

        private IVehicle CreateLuxuryCar(int weightInKilogram)
        {
            IVehicle vehicle = new LuxuryCar(CreateVehicleFees(),
                                             GetNextId(),
                                             weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(new LuxuryCarFee(new StandardCarFee()));

            return vehicle;
        }

        private IVehicle CreateMotorbike(int weightInKilogram)
        {
            IVehicle vehicle = new Motorbike(CreateVehicleFees(),
                                             GetNextId(),
                                             weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(new MotorbikeFee());

            return vehicle;
        }

        private IVehicle CreateTruck(int weightInKilogram)
        {
            IVehicle vehicle = new Truck(CreateVehicleFees(),
                                         GetNextId(),
                                         weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(new TruckFee());

            return vehicle;
        }

        private static void AddCommonFees([NotNull] IVehicle vehicle)
        {
            AddWeightFeeIfRequired(vehicle);

            vehicle.AddFee(new VehicleFee());
        }

        private IVehicleFees CreateVehicleFees()
        {
            return new VehicleFees(new FeeCalculator());
        }

        private static void AddWeightFeeIfRequired([NotNull] IVehicle vehicle)
        {
            if ( vehicle.WeightInKilogram > 100 )
            {
                vehicle.AddFee(new WeightFee());
            }
        }

        private int GetNextId()
        {
            return m_NextId++;
        }
    }
}
using System;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public class NewVehicleFactory : INewVehicleFactory
    {
        private int m_NextId = 1;

        public T Create<T>(int weightInKilogram) where T : INewVehicle
        {
            // todo castle windsor factory
            if ( typeof(T) == typeof(StandardCar) )
            {
                return (T) CreateStandardCar(weightInKilogram);
            }

            if (typeof(T) == typeof(LuxuryCar))
            {
                return (T)CreateLuxuryCar(weightInKilogram);
            }

            if (typeof(T) == typeof(Motorbike))
            {
                return (T)CreateMotorbike(weightInKilogram);
            }

            if (typeof(T) == typeof(Truck))
            {
                return (T)CreateTruck(weightInKilogram);
            }

            throw new ArgumentException("Can't create vehicle for type '{0}'!".Inject(typeof(T)));
        }

        private INewVehicle CreateStandardCar(int weightInKilogram)
        {
            INewVehicle vehicle = new StandardCar(CreateVehicleFees(),
                                                  GetNextId(),
                                                  weightInKilogram);

            AddCommonFees(weightInKilogram,
                          vehicle);
            vehicle.AddFee(new StandardCarFee());

            return vehicle;
        }

        private INewVehicle CreateLuxuryCar(int weightInKilogram)
        {
            INewVehicle vehicle = new LuxuryCar(CreateVehicleFees(),
                                                GetNextId(),
                                                weightInKilogram);

            AddCommonFees(weightInKilogram,
                          vehicle);
            vehicle.AddFee(new LuxuryCarFee(new StandardCarFee()));

            return vehicle;
        }

        private INewVehicle CreateMotorbike(int weightInKilogram)
        {
            INewVehicle vehicle = new Motorbike(CreateVehicleFees(),
                                                GetNextId(),
                                                weightInKilogram);

            AddCommonFees(weightInKilogram,
                          vehicle);
            vehicle.AddFee(new MotorbikeFee());

            return vehicle;
        }

        private INewVehicle CreateTruck(int weightInKilogram)
        {
            INewVehicle vehicle = new Truck(CreateVehicleFees(),
                                            GetNextId(),
                                            weightInKilogram);

            AddCommonFees(weightInKilogram,
                          vehicle);
            vehicle.AddFee(new TruckFee());

            return vehicle;
        }

        private static void AddCommonFees(int weightInKilogram,
                                          [NotNull] INewVehicle vehicle)
        {
            AddWeightFeeIfRequired(weightInKilogram,
                                   vehicle);

            vehicle.AddFee(new VehicleFee());
        }

        private IVehicleFees CreateVehicleFees()
        {
            return new VehicleFees(new FeeCalculator());
        }

        // todo why kilo and vehicle
        private static void AddWeightFeeIfRequired(int weightInKilogram,
                                                   [NotNull] INewVehicle vehicle)
        {
            if (weightInKilogram > 100)
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
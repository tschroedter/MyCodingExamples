using System;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Interaces.Fees;
using ParkIQ.SecureParking.Interaces.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Vehicles
{
    // todo check tests
    [ProjectComponent(Lifestyle.Transient)]
    public class VehicleAndFeeFactory : IVehicleAndFeeFactory
    {
        private int m_NextId = 1;

        public VehicleAndFeeFactory([NotNull] IVehicleFactory vehicleFactory,
                                    [NotNull] IFeeFactory feeFactory)
        {
            VehicleFactory = vehicleFactory;
            FeeFactory = feeFactory;
        }

        public IVehicleFactory VehicleFactory { get; set; }
        public IFeeFactory FeeFactory { get; set; }

        public T Create <T>(int weightInKilogram) where T : IVehicle
        {
            // todo castle windsor factory
            if ( typeof ( T ) == typeof ( IStandardCar ) )
            {
                return ( T ) CreateStandardCar(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( ILuxuryCar ) )
            {
                return ( T ) CreateLuxuryCar(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( IMotorbike ) )
            {
                return ( T ) CreateMotorbike(weightInKilogram);
            }

            if ( typeof ( T ) == typeof ( ITruck ) )
            {
                return ( T ) CreateTruck(weightInKilogram);
            }

            throw new ArgumentException("Can't create vehicle for type '{0}'!".Inject(typeof ( T )));
        }

        public void Release(IVehicle vehicle)
        {
        }

        private IVehicle CreateStandardCar(int weightInKilogram)
        {
            IVehicle vehicle = VehicleFactory.Create <IStandardCar>(GetNextId(),
                                                                       weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(FeeFactory.Create <IStandardCarFee>());

            return vehicle;
        }

        private IVehicle CreateLuxuryCar(int weightInKilogram)
        {
            IVehicle vehicle = VehicleFactory.Create <ILuxuryCar>(GetNextId(),
                                                                     weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(FeeFactory.Create <ILuxuryCarFee>());

            return vehicle;
        }

        private IVehicle CreateMotorbike(int weightInKilogram)
        {
            IVehicle vehicle = VehicleFactory.Create <IMotorbike>(GetNextId(),
                                                                     weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(FeeFactory.Create <IMotorbikeFee>());

            return vehicle;
        }

        private IVehicle CreateTruck(int weightInKilogram)
        {
            IVehicle vehicle = VehicleFactory.Create <ITruck>(GetNextId(),
                                                                 weightInKilogram);

            AddCommonFees(vehicle);
            vehicle.AddFee(FeeFactory.Create <ITruckFee>());

            return vehicle;
        }

        private void AddCommonFees([NotNull] IVehicle vehicle)
        {
            AddWeightFeeIfRequired(vehicle);

            vehicle.AddFee(FeeFactory.Create <IVehicleFee>());
        }

        private void AddWeightFeeIfRequired([NotNull] IVehicle vehicle)
        {
            if ( vehicle.WeightInKilogram > 100 )
            {
                vehicle.AddFee(FeeFactory.Create <IWeightFee>());
            }
        }

        private int GetNextId()
        {
            return m_NextId++;
        }
    }
}
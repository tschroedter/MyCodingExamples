using System;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Vehicles;
using TechTalk.SpecFlow;

namespace ParkIQ.SecureParking.SpecFlow.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected IVehicleFactory VehicleFactory
        {
            get
            {
                if ( !ScenarioContext.Current.ContainsKey("VehicleFactory") )
                {
                    ScenarioContext.Current [ "VehicleFactory" ] = new VehicleFactory();
                }

                return ( IVehicleFactory ) ScenarioContext.Current [ "VehicleFactory" ];
            }
        }

        protected ICarPark CarPark
        {
            get
            {
                return ( ICarPark ) ScenarioContext.Current [ "CarPark" ];
            }
            set
            {
                ScenarioContext.Current [ "CarPark" ] = value;
            }
        }

        protected IVehicle CreateVehicle([NotNull] string vehicleTypeString,
                                         int weightInKilogram)
        {
            switch ( vehicleTypeString )
            {
                case "StandardCar":
                    return VehicleFactory.Create<StandardCar>(weightInKilogram);

                case "LuxuryCar":
                    return VehicleFactory.Create<LuxuryCar>(weightInKilogram);

                case "Motorbike":
                    return VehicleFactory.Create<Motorbike>(weightInKilogram);

                case "Truck":
                    return VehicleFactory.Create<Truck>(weightInKilogram);

                default:
                    throw new ArgumentException("Unknown vehivle type '{0}'!".Inject(vehicleTypeString));
            }

        }
    }
}
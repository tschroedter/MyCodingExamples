using System;
using Castle.Windsor;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Vehicles;
using TechTalk.SpecFlow;

namespace ParkIQ.SecureParking.SpecFlow.Steps.Common
{
    [Binding]
    public abstract class BaseStep
    {
        protected IWindsorContainer Container
        {
            get
            {
                return (IWindsorContainer)ScenarioContext.Current["WindsorContainer"];
            }
            set
            {
                ScenarioContext.Current["WindsorContainer"] = value;
            }
        }

        protected IVehicleAndFeeFactory VehicleAndFeeFactory
        {
            get
            {
                if ( !ScenarioContext.Current.ContainsKey("VehicleAndFeeFactory") )
                {
                    ScenarioContext.Current [ "VehicleAndFeeFactory" ] = Container.Resolve<IVehicleAndFeeFactory>();
                }

                return ( IVehicleAndFeeFactory ) ScenarioContext.Current [ "VehicleAndFeeFactory" ];
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
                    return VehicleAndFeeFactory.Create<StandardCar>(weightInKilogram);

                case "LuxuryCar":
                    return VehicleAndFeeFactory.Create<LuxuryCar>(weightInKilogram);

                case "Motorbike":
                    return VehicleAndFeeFactory.Create<Motorbike>(weightInKilogram);

                case "Truck":
                    return VehicleAndFeeFactory.Create<Truck>(weightInKilogram);

                default:
                    throw new ArgumentException("Unknown vehivle type '{0}'!".Inject(vehicleTypeString));
            }

        }
    }
}
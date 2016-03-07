using System;
using JetBrains.Annotations;
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
            var vehicleType = ( VehicleFactory.VehicleType ) Enum.Parse(typeof ( VehicleFactory.VehicleType ),
                                                                        vehicleTypeString);

            IVehicle vehicle = VehicleFactory.Create(vehicleType,
                                                     weightInKilogram);

            return vehicle;
        }
    }
}
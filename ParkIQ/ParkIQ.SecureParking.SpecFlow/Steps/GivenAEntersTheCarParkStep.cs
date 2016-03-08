using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenAEntersTheCarParkStep : BaseStep
    {
        private const int DoesNotMatterWeight = 1;

        [Given(@"a ""(.*)"" enters the car park")]
        public void GivenAEntersTheCarPark(string vehicleTypeString)
        {
            INewVehicle vehicle = CreateVehicle(vehicleTypeString,
                                             DoesNotMatterWeight);

            ScenarioContext.Current [ vehicleTypeString ] = vehicle;

            CarPark.Enter(vehicle);
        }
    }
}
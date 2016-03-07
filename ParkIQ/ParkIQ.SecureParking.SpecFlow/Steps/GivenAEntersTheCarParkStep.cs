using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenAEntersTheCarParkStep : BaseStep
    {
        private const int DoesNotMatterWeight = 1;

        [Given(@"a ""(.*)"" enters the car park")]
        public void GivenAEntersTheCarPark(string vehicleTypeString)
        {
            IVehicle vehicle = CreateVehicle(vehicleTypeString,
                                             DoesNotMatterWeight);

            ScenarioContext.Current [ vehicleTypeString ] = vehicle;

            CarPark.Enter(vehicle);
        }
    }
}
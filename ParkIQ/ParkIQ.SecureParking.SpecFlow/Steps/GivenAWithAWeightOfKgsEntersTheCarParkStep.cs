using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenAWithAWeightOfKgsEntersTheCarParkStep : BaseStep
    {
        [Given(@"a ""(.*)"" with a weight of (.*) kgs enters the car park")]
        public void GivenAWithAWeightOfKgsEntersTheCarPark(string vehicleTypeString,
                                                           int weightInKilogram)
        {
            IVehicle vehicle = CreateVehicle(vehicleTypeString,
                                             weightInKilogram);

            ScenarioContext.Current [ vehicleTypeString ] = vehicle;

            CarPark.Enter(vehicle);
        }
    }
}
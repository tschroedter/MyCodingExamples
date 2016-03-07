using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenACarParkWithBaysAndANameOfStep : BaseStep
    {
        [Given(@"a car park with (.*) bays and a name of ""(.*)""")]
        public void GivenACarParkWithBaysAndANameOf(int numberOfBays,
                                                    string name)
        {
            IBaysManager baysManager = new BaysManager(numberOfBays);

            CarPark = new CarPark(baysManager,
                                  name);
        }
    }
}
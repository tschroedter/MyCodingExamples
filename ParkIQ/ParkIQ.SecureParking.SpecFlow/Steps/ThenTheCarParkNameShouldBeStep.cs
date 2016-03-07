using TechTalk.SpecFlow;
using NUnit.Framework;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class ThenTheCarParkNameShouldBeStep : BaseStep
    {
        [Then(@"the car park name should be ""(.*)""")]
        public void ThenTheCarParkNameShouldBe(string name)
        {
            Assert.AreEqual(name,
                            CarPark.Name);
        }
    }
}
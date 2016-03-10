using Castle.Windsor;
using Castle.Windsor.Installer;
using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenACarParkWithBaysAndANameOfStep : BaseStep
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Container.Dispose();
        }

        [Given(@"a car park with (.*) bays and a name of ""(.*)""")]
        public void GivenACarParkWithBaysAndANameOf(int numberOfBays,
                                                    string name)
        {
            var factory = Container.Resolve <ICarParkFactory>();

            CarPark = factory.Create("name",
                                     numberOfBays);
        }
    }
}
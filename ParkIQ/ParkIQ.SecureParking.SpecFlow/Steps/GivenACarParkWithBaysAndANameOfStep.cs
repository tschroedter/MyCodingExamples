using Castle.Windsor;
using ParkIQ.SecureParking.Interaces;
using TechTalk.SpecFlow;
using ParkIQ.SecureParking.SpecFlow.Steps.Common;

namespace ParkIQ.SecureParking.SpecFlow.Steps
{
    public class GivenACarParkWithBaysAndANameOfStep : BaseStep
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var windsorContainer = new WindsorContainer();
            var installer = new Installer();
            windsorContainer.Install(installer);

            Container = windsorContainer;
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
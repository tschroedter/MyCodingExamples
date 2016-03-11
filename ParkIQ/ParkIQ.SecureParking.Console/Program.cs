using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ParkIQ.SecureParking.Interaces.Fees;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            var container = new WindsorContainer();
            var installer = new Installer();
            container.Install(installer);

            var demo = new CarParkDemo(container);
            demo.Run();

            System.Console.WriteLine("Press 'Return' to exit...");
            System.Console.ReadLine();
        }
    }
}
using System.Diagnostics.CodeAnalysis;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        private static void Main()
        {
            // todo use Castle Windsor
            var demo = new CarParkDemo();

            demo.Run();

            System.Console.WriteLine("Press 'Return' to exit...");
            System.Console.ReadLine();
        }
    }
}
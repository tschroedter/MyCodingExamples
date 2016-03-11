using ParkIQ.SecureParking.Interaces;

namespace ParkIQ.SecureParking.Tests
{
    internal sealed class TestIBaysManagerFactory : IBaysManagerFactory
    {
        public IBaysManager Create(int numberOfBays)
        {
            return new BaysManager(new TestBayFactory(),
                                   numberOfBays);
        }

        public void Release(IBaysManager baysManager)
        {
        }
    }
}
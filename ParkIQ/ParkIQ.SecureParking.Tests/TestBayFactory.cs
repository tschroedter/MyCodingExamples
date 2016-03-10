namespace ParkIQ.SecureParking.Tests
{
    internal sealed class TestBayFactory : IBayFactory
    {
        public IBay Create(int id)
        {
            return new Bay(id);
        }

        public void Release(IBay bay)
        {
        }
    }
}
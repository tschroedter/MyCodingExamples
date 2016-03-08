namespace ParkIQ.SecureParking.Vehicles
{
    public interface INewVehicleFactory
    {
        T Create<T>(int weightInKilogram) where T : INewVehicle;
    }
}
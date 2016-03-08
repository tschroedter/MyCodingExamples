namespace ParkIQ.SecureParking.Vehicles
{
    public interface IVehicleFactory
    {
        T Create <T>(int weightInKilogram) where T : IVehicle;
    }
}
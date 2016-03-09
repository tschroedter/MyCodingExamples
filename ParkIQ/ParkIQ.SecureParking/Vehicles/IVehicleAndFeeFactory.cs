namespace ParkIQ.SecureParking.Vehicles
{
    public interface IVehicleAndFeeFactory
    {
        T Create <T>(int weightInKilogram) where T : IVehicle;
    }
}
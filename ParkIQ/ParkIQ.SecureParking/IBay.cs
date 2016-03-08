using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public interface IBay
    {
        bool IsEmpty { get; }
        INewVehicle Vehicle { get; set; }
        int Id { get; }
    }
}
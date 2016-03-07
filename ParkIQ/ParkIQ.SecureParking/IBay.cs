namespace ParkIQ.SecureParking
{
    public interface IBay
    {
        bool IsEmpty { get; }
        IVehicle Vehicle { get; set; }
        int Id { get; }
    }
}
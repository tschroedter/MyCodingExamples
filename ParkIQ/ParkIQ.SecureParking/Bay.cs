namespace ParkIQ.SecureParking
{
    public class Bay : IBay
    {
        public Bay(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return Vehicle == null;
            }
        }

        public IVehicle Vehicle { get; set; }
    }
}
using ParkIQ.SecureParking.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ProjectComponent(Lifestyle.Transient)]
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
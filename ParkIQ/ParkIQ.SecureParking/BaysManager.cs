using System.Collections.Generic;
using System.Linq;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class BaysManager : IBaysManager
    {
        private readonly IBay[] m_Bays;

        public BaysManager(int numberOfBays)
        {
            m_Bays = new IBay[numberOfBays];

            for ( var i = 0 ; i < m_Bays.Length ; i++ )
            {
                m_Bays [ i ] = new Bay(i);
            }
        }

        public IEnumerable <IBay> Bays
        {
            get
            {
                return m_Bays;
            }
        }

        public int NumberOfBays
        {
            get
            {
                return m_Bays.Length;
            }
        }

        public int NumberOfEmptyBays
        {
            get
            {
                return m_Bays.Count(x => x.IsEmpty);
            }
        }

        public int NumberOfOccupiedBays
        {
            get
            {
                return NumberOfBays - NumberOfEmptyBays;
            }
        }

        public bool IsFull
        {
            get
            {
                return NumberOfBays == NumberOfOccupiedBays;
            }
        }

        public IEnumerable<INewVehicle> Vehicles
        {
            get
            {
                return m_Bays.Select(x => x.Vehicle).Where(x => x != null);
            }
        }

        public void AssignBay(INewVehicle vehicle)
        {
            IBay emptyBay = m_Bays.FirstOrDefault(x => x.IsEmpty);

            if ( emptyBay == null )
            {
                throw new NoEmptyBayException(vehicle);
            }

            emptyBay.Vehicle = vehicle;
        }

        public void ReleaseBay(INewVehicle vehicle)
        {
            IBay assignedBay = m_Bays.FirstOrDefault(x => x.Vehicle == vehicle);

            if ( assignedBay == null )
            {
                throw new NoVehicleFoundInBaysException(vehicle);
            }

            assignedBay.Vehicle = null;
        }

        public int FindVehicleBayId(INewVehicle vehicle)
        {
            IBay assignedBay = m_Bays.FirstOrDefault(x => x.Vehicle == vehicle);

            if ( assignedBay == null )
            {
                throw new NoVehicleFoundInBaysException(vehicle);
            }

            return assignedBay.Id;
        }
    }
}
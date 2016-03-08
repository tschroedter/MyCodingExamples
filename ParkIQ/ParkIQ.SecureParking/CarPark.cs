using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking
{
    public class CarPark : ICarPark
    {
        private readonly IBaysManager m_BaysManager;

        public CarPark([NotNull] IBaysManager baysManager,
                       [NotNull] string name)
        {
            Name = name;
            m_BaysManager = baysManager;
        }

        private IBaysManager BaysManager
        {
            get
            {
                return m_BaysManager;
            }
        }

        public string Name { get; private set; }

        public IEnumerable <IBay> Bays
        {
            get
            {
                return BaysManager.Bays;
            }
        }

        public IEnumerable<INewVehicle> Vehicles
        {
            get
            {
                return m_BaysManager.Vehicles;
            }
        }

        public int NumberOfBays
        {
            get
            {
                return BaysManager.NumberOfBays;
            }
        }

        public int NumberOfOccupiedBays
        {
            get
            {
                return BaysManager.NumberOfOccupiedBays;
            }
        }

        public bool IsFull
        {
            get
            {
                return BaysManager.IsFull;
            }
        }

        public void Enter(INewVehicle vehicle)
        {
            if ( m_BaysManager.IsFull )
            {
                throw new CarParkIsFullException(vehicle);
            }

            m_BaysManager.AssignBay(vehicle);

            Console.WriteLine("Vehicle '{0}' entered car park!".Inject(vehicle.Id));
        }

        public void Exit(INewVehicle vehicle)
        {
            if ( !vehicle.IsFeePaid )
            {
                throw new CarDidNotPayFeeException(vehicle);
            }

            m_BaysManager.ReleaseBay(vehicle);

            Console.WriteLine("Vehicle '{0}' exited car park!".Inject(vehicle.Id));
        }
    }
}
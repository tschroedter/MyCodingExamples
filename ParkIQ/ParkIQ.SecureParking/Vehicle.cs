using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking
{
    public class Vehicle : IVehicle
    {
        private readonly IVehicleFees m_VehicleFees;

        public Vehicle([NotNull] IVehicleFees vehicleFees,
                       int id,
                       int weightInKilogram,
                       VehicleFactory.VehicleType vehicleType)
        {
            Id = id;
            WeightInKilogram = weightInKilogram;
            VehicleType = vehicleType;
            Fee = new FreeFee(this);
            m_VehicleFees = vehicleFees;
        }

        public IFee Fee { get; private set; }

        public VehicleFactory.VehicleType VehicleType { get; private set; }

        public int WeightInKilogram { get; set; }

        public int Id { get; private set; }

        public void PaysFee()
        {
            m_VehicleFees.FeeIsPaid();

            Console.WriteLine("Vehicle '{0}' paid the fees!".Inject(Id));
        }

        public void AddFee(IFee fee)
        {
            m_VehicleFees.AddFee(fee);
        }

        public bool IsFeePaid
        {
            get
            {
                return m_VehicleFees.IsPaid;
            }
        }

        public bool ContainsFee(IFee fee)
        {
            return m_VehicleFees.ContainsFee(fee);
        }

        public IEnumerable <IFee> Fees
        {
            get
            {
                return m_VehicleFees.Fees;
            }
        }

        public override string ToString()
        {
            return "Id: {0} VehicleType: {1} Fees: {2} IsFeePaid: {3}".Inject(Id,
                                                                              VehicleType,
                                                                              m_VehicleFees.Calulate(),
                                                                              IsFeePaid);
        }
    }
}
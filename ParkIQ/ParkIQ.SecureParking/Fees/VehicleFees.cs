﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace ParkIQ.SecureParking.Fees
{
    public class VehicleFees : IVehicleFees
    {
        private readonly IFeeCalculator m_Calculator;
        private readonly List <IFee> m_Fees = new List <IFee>();

        public VehicleFees([NotNull] IFeeCalculator calculator)
        {
            m_Calculator = calculator;
        }

        public IEnumerable <IFee> Fees
        {
            get
            {
                return m_Fees;
            }
        }

        public int Calulate()
        {
            return m_Calculator.Calulate(m_Fees);
        }

        public void AddFee(IFee fee)
        {
            if ( m_Fees.Contains(fee) )
            {
                throw new FeeAlreadyAddedException(fee);
            }

            m_Fees.Add(fee);
        }

        public void RemoveFee(IFee fee)
        {
            m_Fees.Remove(fee);
        }

        public bool ContainsFee(IFee fee)
        {
            return m_Fees.Contains(fee);
        }

        public bool IsPaid { get; private set; }

        public void FeeIsPaid()
        {
            IsPaid = true;
        }
    }
}
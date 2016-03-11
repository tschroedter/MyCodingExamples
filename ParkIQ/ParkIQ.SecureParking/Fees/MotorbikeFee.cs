﻿using ParkIQ.SecureParking.Interaces.Fees;
using Selkie.Windsor;

namespace ParkIQ.SecureParking.Fees
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MotorbikeFee : IMotorbikeFee
    {
        private const int TwoDollars = 2;

        public int Calculate()
        {
            return TwoDollars;
        }
    }
}
﻿using System.Collections.Generic;
using JetBrains.Annotations;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Vehicles
{
    public interface INewVehicle
    {
        int WeightInKilogram { get; }

        int Id { get; }

        bool IsFeePaid { get; }

        [NotNull]
        IEnumerable<IFee> Fees { get; }

        void PaysFee();

        void AddFee([NotNull] IFee fee);
        bool ContainsFee([NotNull] IFee fee);
        [NotNull]
        string ShortDescription { get; }
    }
}
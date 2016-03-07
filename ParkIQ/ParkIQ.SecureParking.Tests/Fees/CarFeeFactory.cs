using System;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Fees;

namespace ParkIQ.SecureParking.Tests.Fees
{
    // todo seperate testing?
    public class CarFeeFactory <T> : ICarFeeFactory
        where T : IFee
    {
        public IFee Create(IVehicle vehicle)
        {
            if ( typeof ( T ) == typeof ( StandardCarFee ) )
            {
                return new StandardCarFee(vehicle);
            }

            if ( typeof ( T ) == typeof ( LuxuryCarFee ) )
            {
                return new LuxuryCarFee(vehicle);
            }

            if ( typeof ( T ) == typeof ( MotorbikeFee ) )
            {
                return new MotorbikeFee(vehicle);
            }

            if ( typeof ( T ) == typeof ( TruckFee ) )
            {
                return new TruckFee(vehicle);
            }

            if ( typeof ( T ) == typeof ( FreeFee ) )
            {
                return new FreeFee(vehicle);
            }

            throw new ArgumentException("Unknown fee '{0}'!".Inject(typeof ( T )));
        }

        public void Release(IFee fee)
        {
            // nothing to do at the moment
        }
    }
}
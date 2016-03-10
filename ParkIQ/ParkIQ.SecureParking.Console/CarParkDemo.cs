using System;
using System.Diagnostics.CodeAnalysis;
using Castle.Windsor;
using JetBrains.Annotations;
using ParkIQ.Extensions;
using ParkIQ.SecureParking.Vehicles;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    public class CarParkDemo : IDisposable
    {
        private readonly IWindsorContainer m_Container;
        private const int DoesNotMatterWeightInKilogram = 1;

        public CarParkDemo([NotNull] IWindsorContainer container)
        {
            m_Container = container;

            VehicleAndFeeFactory = container.Resolve<IVehicleAndFeeFactory>();
            CreateVehicles();

            // 1.	Initialise the car park with 10 bays and a name of “Test carpark”
            var factory = container.Resolve<ICarParkFactory>();
            CarPark = factory.Create("Test carpark",
                                     10);
        }

        public IVehicleFactory Factory { get; set; }

        private IVehicleAndFeeFactory VehicleAndFeeFactory { get; set; }
        private IVehicle StandardCar { get; set; }
        private IVehicle LuxuryCar { get; set; }
        private IVehicle Motorbike { get; set; }
        private IVehicle MotorbikeOther { get; set; }
        private IVehicle Truck { get; set; }
        private ICarPark CarPark { get; set; }

        private void CreateVehicles()
        {
            StandardCar = VehicleAndFeeFactory.Create <IStandardCar>(DoesNotMatterWeightInKilogram);
            LuxuryCar = VehicleAndFeeFactory.Create <ILuxuryCar>(DoesNotMatterWeightInKilogram);
            Motorbike = VehicleAndFeeFactory.Create <IMotorbike>(DoesNotMatterWeightInKilogram);
            Truck = VehicleAndFeeFactory.Create <ITruck>(101);
            MotorbikeOther = VehicleAndFeeFactory.Create <IMotorbike>(DoesNotMatterWeightInKilogram);
        }

        public void Run()
        {
            try
            {
                CarsOfEachTypeEntering();
                ListVehicleDetails();
                LuxuryCarPaysFee();
                ListVehicleDetails();
                LuxuryCarExits();
                ListVehicleDetails();
                PayFeesForAllOtherCars();
                AllOtherCarsExits();
                ListVehicleDetails();
                MotorbikeEntering();
                MotorbikeExits();
                ListVehicleDetails();
            }
            catch ( Exception ex )
            {
                System.Console.WriteLine("Exception: {0}".Inject(ex.Message));
            }
        }

        private void CarsOfEachTypeEntering()
        {
            // 2.	Have one of each type of vehicles enter the car park. The truck should have a weight of 101 kg.
            CarPark.Enter(StandardCar);
            CarPark.Enter(LuxuryCar);
            CarPark.Enter(Motorbike);
            CarPark.Enter(Truck);
        }

        private void ListVehicleDetails()
        {
            // 3.	List the details of all the vehicles in the car park including their type and outstanding fees.
            System.Console.WriteLine("\r\n\t\tVehicle Details");

            foreach ( IVehicle vehicle in CarPark.Vehicles )
            {
                System.Console.WriteLine("\t\t{0}".Inject(vehicle));
            }

            System.Console.WriteLine("");
        }

        private void LuxuryCarPaysFee()
        {
            // 4.	Pay the outstanding fee for the luxury car
            LuxuryCar.PaysFee();
        }

        private void LuxuryCarExits()
        {
            // 6.	Have the luxury car exit the car park
            CarPark.Exit(LuxuryCar);
        }

        private void PayFeesForAllOtherCars()
        {
            // 8.	Pay the outstanding fees for the remaining cars
            StandardCar.PaysFee();
            Motorbike.PaysFee();
            Truck.PaysFee();
        }

        private void AllOtherCarsExits()
        {
            // 9.	Have the remaining cars exit the car park
            CarPark.Exit(StandardCar);
            CarPark.Exit(Motorbike);
            CarPark.Exit(Truck);
        }

        private void MotorbikeEntering()
        {
            // 11.	Have a motorbike enter the car park
            CarPark.Enter(MotorbikeOther);
        }

        private void MotorbikeExits()
        {
            // 11.	Have a motorbike enter the car park
            CarPark.Exit(MotorbikeOther);
        }

        public void Dispose()
        {
            m_Container.Dispose();
        }
    }
}
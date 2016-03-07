using System;
using System.Diagnostics.CodeAnalysis;
using ParkIQ.Extensions;

namespace ParkIQ.SecureParking.Console
{
    [ExcludeFromCodeCoverage]
    public class CarParkDemo
    {
        private const int DoesNotMatterWeightInKilogram = 1;

        public CarParkDemo()
        {
            Factory = new VehicleFactory();
            CreateVehicles();

            // 1.	Initialise the car park with 10 bays and a name of “Test carpark”
            var manager = new BaysManager(10);
            CarPark = new CarPark(manager,
                                  "Test carpark");
        }

        private VehicleFactory Factory { get; set; }
        private IVehicle StandardCar { get; set; }
        private IVehicle LuxuryCar { get; set; }
        private IVehicle Motorbike { get; set; }
        private IVehicle MotorbikeOther { get; set; }
        private IVehicle Truck { get; set; }
        private CarPark CarPark { get; set; }

        private void CreateVehicles()
        {
            StandardCar = Factory.Create(VehicleFactory.VehicleType.StandardCar,
                                         DoesNotMatterWeightInKilogram);
            LuxuryCar = Factory.Create(VehicleFactory.VehicleType.LuxuryCar,
                                       DoesNotMatterWeightInKilogram);
            Motorbike = Factory.Create(VehicleFactory.VehicleType.Motorbike,
                                       DoesNotMatterWeightInKilogram);
            Truck = Factory.Create(VehicleFactory.VehicleType.Truck,
                                   101);
            MotorbikeOther = Factory.Create(VehicleFactory.VehicleType.Motorbike,
                                            DoesNotMatterWeightInKilogram);
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
    }
}
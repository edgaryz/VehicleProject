using VehicleProject.Contracts;
using VehicleProject.Models;
using VehicleProject.Repositories;
using VehicleProject.Services;

namespace VehicleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IVehicleService vehicleService = SetupDependencies();

            while (true)
            {
                Console.WriteLine("1. Cars Menu");
                Console.WriteLine("2. Trucks Menu");
                Console.WriteLine("0. Exit Program");
                string mainMenu = Console.ReadLine();
                switch (mainMenu)
                {
                    case "0":
                        //Exit Program
                        return;
                    case "1":
                        Console.WriteLine("1. Cars List");
                        Console.WriteLine("2. Add Car");
                        string choiceCars = Console.ReadLine();
                        switch (choiceCars)
                        {
                            case "0":
                                //Main Menu
                                break;
                            case "1":
                                //GetAllCars
                                var carList = vehicleService.GetAllCars();
                                foreach (Car car in carList.Result)
                                {
                                    Console.WriteLine(car);
                                }
                                break;
                            case "2":
                                //InsertCar
                                Car newCar = new Car();
                                Console.WriteLine("Enter car brand");
                                string brand = Console.ReadLine();
                                Console.WriteLine("Enter car model");
                                string model = Console.ReadLine();
                                Console.WriteLine("Enter car release date");
                                DateTime releaseYear = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter car door count");
                                int doorCount = int.Parse(Console.ReadLine());
                                newCar = new Car(brand, model, releaseYear, doorCount);
                                vehicleService.InsertCar(newCar);
                                Console.WriteLine("Car creation successful!");
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("1. Truck List");
                        Console.WriteLine("2. Add Truck");
                        string choiceTrucks = Console.ReadLine();
                        switch (choiceTrucks)
                        {
                            case "0":
                                //Main Menu
                                break;
                            case "1":
                                //GetAllTrucks
                                var truckList = vehicleService.GetAllTrucks();
                                foreach (Truck truck in truckList.Result)
                                {
                                    Console.WriteLine(truck);
                                }
                                break;
                            case "2":
                                //InsertTruck
                                Truck newTruck = new Truck();
                                Console.WriteLine("Enter truck brand");
                                string brand = Console.ReadLine();
                                Console.WriteLine("Enter truck model");
                                string model = Console.ReadLine();
                                Console.WriteLine("Enter truck release date");
                                DateTime releaseYear = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter truck maxLoadWeight");
                                int maxLoadWeight = int.Parse(Console.ReadLine());
                                newTruck = new Truck(brand, model, releaseYear, maxLoadWeight);
                                vehicleService.InsertTruck(newTruck);
                                Console.WriteLine("Truck creation successful!");
                                break;
                        }
                        break;
                }
            }


        }

        public static IVehicleService SetupDependencies()
        {
            IVehicleDbRepository vehicleDbRepository = new VehicleDbRepository("Server=localhost;Database=tasks_db;Trusted_Connection=True;");
            return new VehicleService(vehicleDbRepository);
        }
    }
}
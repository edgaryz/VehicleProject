using VehicleProject.Models;

namespace VehicleProject.Contracts
{
    public interface IVehicleDbRepository
    {
        Task<List<Car>> GetAllCars();
        Task InsertCar(Car car);
        Task<List<Truck>> GetAllTrucks();
        Task InsertTruck(Truck truck);
    }
}

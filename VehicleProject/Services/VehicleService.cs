using VehicleProject.Contracts;
using VehicleProject.Models;

namespace VehicleProject.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDbRepository _vehicleDbRepository;
        public VehicleService (IVehicleDbRepository vehicleDbRepository)
        {
            _vehicleDbRepository = vehicleDbRepository;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _vehicleDbRepository.GetAllCars();
        }

        public async Task InsertCar(Car car)
        {
            _vehicleDbRepository.InsertCar(car);
        }

        public async Task<List<Truck>> GetAllTrucks()
        {
            return await _vehicleDbRepository.GetAllTrucks();
        }

        public async Task InsertTruck(Truck truck)
        {
            _vehicleDbRepository.InsertTruck(truck);
        }
    }
}

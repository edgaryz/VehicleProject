using Dapper;
using System.Data;
using System.Data.SqlClient;
using VehicleProject.Contracts;
using VehicleProject.Models;

namespace VehicleProject.Repositories
{
    public class VehicleDbRepository : IVehicleDbRepository
    {
        private readonly string _dbConnectionString;
        public VehicleDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        //Cars
        public async Task<List<Car>> GetAllCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<Car>(@"SELECT id, brand, model, release_year AS ReleaseYear, door_count AS DoorCount FROM cars");
            dbConnection.Close();
            return result.ToList();
        }

        public async Task InsertCar(Car car)
        {
            string sqlCommand = "INSERT INTO cars (brand, model, release_year, door_count)" +
                " VALUES (@Brand, @Model, @ReleaseYear, @DoorCount)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                try
                { await connection.ExecuteAsync(sqlCommand, 
                    new { Brand = car.Brand, 
                        Model = car.Model, 
                        ReleaseYear = car.ReleaseYear.ToString(""), 
                        DoorCount = car.DoorCount }); }
                catch (Exception ex)
                {
                    ex = ex;
                }



            }
        }

        //Trucks
        public async Task<List<Truck>> GetAllTrucks()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<Truck>(@"SELECT id, brand, model, release_year AS ReleaseYear, max_load_weight AS MaxLoadWeight FROM trucks");
            dbConnection.Close();
            return result.ToList();
        }

        public async Task InsertTruck(Truck truck)
        {
            string sqlCommand = "INSERT INTO trucks (brand, model, release_year, max_load_weight)" +
                " VALUES (@Brand, @Model, @ReleaseYear, @MaxLoadWeight)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, truck);
            }
        }
    }
}

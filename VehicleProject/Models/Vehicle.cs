namespace VehicleProject.Models
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ReleaseYear { get; set; }

        public Vehicle() { }

        public Vehicle(string brand, string model, DateTime releaseYear)
        {
            Brand = brand;
            Model = model;
            ReleaseYear = releaseYear;
        }
    }
}

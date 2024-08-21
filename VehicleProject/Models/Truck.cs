namespace VehicleProject.Models
{
    public class Truck : Vehicle
    {
        public int MaxLoadWeight { get; set; }

        public Truck() { }

        public Truck(string brand, string model, DateTime releaseYear, int maxLoadWeight) : base(brand, model, releaseYear)
        {
            MaxLoadWeight = maxLoadWeight;
        }

        public override string ToString()
        {
            return $"{Brand} {Model}, Release Date: {ReleaseYear}, Max Load Weight: {MaxLoadWeight}.";
        }
    }
}

namespace VehicleProject.Models
{
    public class Car : Vehicle
    {
        public int DoorCount { get; set; }

        public Car() { }

        public Car(string brand, string model, DateTime releaseYear, int doorCount) : base(brand, model, releaseYear)
        {
            DoorCount = doorCount;
        }

        public override string ToString()
        {
            return $"{Brand} {Model}, Release Date: {ReleaseYear}, Door count: {DoorCount}.";
        }
    }
}

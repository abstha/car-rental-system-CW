namespace car_system.Models.DTO
{
    public class CarCreateDTO
    {
        public string Model { get; set; }
        public string Picture { get; set; }
        public string Condition { get; set; }
        public bool Availability { get; set; }
        public int RentPrice { get; set; }
    }
}

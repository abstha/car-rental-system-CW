namespace car_system.Models.DTO
{
    public class RentalRequestDTO
    {
        public int RentalId { get; set; }
        public string UserId { get; set; }
        public int CarRented { get; set; }
        public DateTime RentalDate { get; set; }
        public string RentalStatus { get; set; }
    }
}

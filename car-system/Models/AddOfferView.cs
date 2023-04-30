namespace car_system.Models
{
    public class AddOfferView
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public string OfferDescription { get; set; }
        public string CreatedByUserID { get; set; }
    }
}

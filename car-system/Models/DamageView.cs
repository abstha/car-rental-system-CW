namespace car_system.Models
{
    public class DamageView
    {
        public int DamageID  { get; set; }
        public string UserID{ get; set; }

        public string VerifiedBy { get; set; }  

        public int CarId { get; set; }

        public int Amount { get; set; }
    }
}

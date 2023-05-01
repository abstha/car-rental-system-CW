using System.ComponentModel.DataAnnotations;

namespace car_system.Models
{
	public class CreateOfferView
	{
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public string OfferDescription { get; set; }

        [Required]
        public string CreatedByUserID { get; set; }
    }
}

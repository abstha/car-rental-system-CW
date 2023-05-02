using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_system.Models.Entities
{
    public class Offers
    {
        [Key]
        public int OfferID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public string OfferDescription { get; set; }
        public string CreatedByUserID { get; set; } // Updated property name

        [ForeignKey("CreatedByUserID")]
        public virtual Users CreatedByUser { get; set; }
    }
}

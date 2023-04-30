using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace car_system.Models.Entities
{
    public class RentalRequest
    {
        [Key]
        public int RentalId { get; set; }

        public string UserId { get; set; }
        public int CarRented { get; set; }
        public DateTime RentalDate { get; set; }
        public string RentalStatus { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("CarRented")]
        public virtual Cars Car { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace car_system.Models.Entities
{
    public class RentalRequest
    {
        [Key]
        public int RentalId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [ForeignKey("CarRented")]
        public int CarRented { get; set; }

        public DateTime RentalDate { get; set; }
        public string RentalStatus { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedByStaffId { get; set; } // New field for the approving staff member

        [ForeignKey("UserId")]
        [InverseProperty("RentalRequests")]
        public virtual Users User { get; set; }

        public virtual Cars Car { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace car_system.Models.Entities
{
    public class Damages
    {
        [Key]
        public int DamageID { get; set; }

        [ForeignKey("UserID")]
        public string UserID { get; set; }

        public string VerifiedBy { get; set; }

        [ForeignKey("CarID")]
        public int CarID { get; set; }

        public int Amount { get; set; }

        public virtual Users User { get; set; }
        public virtual Cars Car { get; set; }
    }
}

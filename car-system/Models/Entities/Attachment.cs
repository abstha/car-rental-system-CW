using System.ComponentModel.DataAnnotations.Schema;

namespace car_system.Models.Entities
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public string DrivingLicense { get; set; }
        public string Citizenship { get; set; }
        public int NumberOfRents { get; set; }
        public bool ActivityStatus { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
    }
}

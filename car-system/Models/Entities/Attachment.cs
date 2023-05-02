using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_system.Models.Entities
{
    public class Attachment
    {
        public int AttachmentID { get; set; }

        [DrivingLicenseOrCitizenshipRequired(ErrorMessage = "Please provide a driving license or citizenship paper.")]
        public string DrivingLicense { get; set; }

        [DrivingLicenseOrCitizenshipRequired(ErrorMessage = "Please provide a driving license or citizenship paper.")]
        public string Citizenship { get; set; }

        public int NumberOfRents { get; set; }
        public bool ActivityStatus { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
    }

    public class DrivingLicenseOrCitizenshipRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var attachment = (Attachment)validationContext.ObjectInstance;

            // Check if either driving license or citizenship is provided
            if (string.IsNullOrEmpty(attachment.DrivingLicense) && string.IsNullOrEmpty(attachment.Citizenship))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}

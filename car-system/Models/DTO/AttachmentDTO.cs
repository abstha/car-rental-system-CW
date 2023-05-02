using System.ComponentModel.DataAnnotations;

namespace car_system.Models.DTO
{
    public class AttachmentDTO
    {
        [Required(ErrorMessage = "Please provide either a citizenship image or a license image.")]
        public string CitizenshipImage { get; set; }

        [Required(ErrorMessage = "Please provide the user ID.")]
        public string UserID { get; set; }
    }

}
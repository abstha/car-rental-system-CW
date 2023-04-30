using Microsoft.AspNetCore.Identity;

namespace car_system.Models.Entities
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Navigation properties
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Offers> Offers { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}

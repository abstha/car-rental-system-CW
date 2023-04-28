using Microsoft.AspNetCore.Identity;

namespace car_system.Models.Entities
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

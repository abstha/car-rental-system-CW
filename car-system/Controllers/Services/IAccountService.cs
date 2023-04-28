using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IAccountService
    {

        Task RegisterUser(Users user);

        Task<Users> LoginUser(string email, string password);

        Task ChangePassword(Users user, string currentPassword, string newPassword);
    }
}

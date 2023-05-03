using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public interface IDamageService
    {
        void CreateDamage(Damages damage);
        void UpdateDamage(Damages damage);
        void DeleteDamage(int damageId);
        Damages GetDamageById(int damageId);
        List<Damages> GetAllDamages();

    }
}

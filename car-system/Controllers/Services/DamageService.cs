using car_system.Controllers.Data;
using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
    public class DamageService : IDamageService
    {
        private readonly ApplicationDbContext _dbContext;

        public DamageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateDamage(Damages damage)
        {
            _dbContext.Damages.Add(damage);
            _dbContext.SaveChanges();
        }

        public void UpdateDamage(Damages damage)
        {
            _dbContext.Damages.Update(damage);
            _dbContext.SaveChanges();
        }

        public void DeleteDamage(int damageId)
        {
            var damage = _dbContext.Damages.Find(damageId);
            if (damage != null)
            {
                _dbContext.Damages.Remove(damage);
                _dbContext.SaveChanges();
            }
        }

        public Damages GetDamageById(int damageId)
        {
            return _dbContext.Damages.Find(damageId);
        }

        public List<Damages> GetAllDamages()
        {
            return _dbContext.Damages.ToList();
        }

    }
}

using RpgAPI.Data;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Repository
{
    public class WeaponRepository: Repository<Weapon>, IWeaponRepository
    {
        private readonly ApplicationDbContext _db;
        public WeaponRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}

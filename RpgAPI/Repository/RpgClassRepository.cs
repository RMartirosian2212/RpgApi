using RpgAPI.Data;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Repository
{
    public class RpgClassRepository: Repository<RpgClass>, IRpgClassRepository
    {
        private readonly ApplicationDbContext _userRepository;
        public RpgClassRepository(ApplicationDbContext db)
            :base(db) 
        {
            _userRepository = db;
        }
    }
}

using RpgAPI.Data;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _userRepository;
        public UserRepository(ApplicationDbContext db)
            :base(db)
        {
            _userRepository = db;
        }
    }
}

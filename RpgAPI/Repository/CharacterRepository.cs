using RpgAPI.Data;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Repository
{
    public class CharacterRepository: Repository<Character>, ICharacterRepository
    {
        private readonly ApplicationDbContext _userRepository;
        public CharacterRepository(ApplicationDbContext db)
            :base(db)
        {
            _userRepository = db;
        }
    }
}

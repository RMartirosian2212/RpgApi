using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgAPI.Data;
using RpgAPI.Models;
using RpgAPI.Models.Dto.User;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICharacterRepository _characterRepository;
        public UserController(IUserRepository userRepository, ICharacterRepository characterRepository)
        {
            _userRepository = userRepository;
            _characterRepository = characterRepository;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAll(include:x => x.Include(x => x.Characters).ThenInclude(x => x.RpgClass).Include(x => x.Characters).ThenInclude(x => x.Weapon));
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<User> AddNewUser(CreateUserDto request)
        {
            List<Character> characters = new List<Character>();
            foreach (var item in request.CharactersIds)
            {
                if (_characterRepository.GetById(item) is null)
                {
                    return NotFound();
                }
                characters.Add(_characterRepository.GetById(item));
            }
            var user = new User()
            {
                Username = request.UserName,
                Characters = characters
            };
            _userRepository.Add(user);
            _userRepository.Save();
            return Ok(user);
        }
        [HttpPut]
        public ActionResult UpdateUser(EditUserDto request)
        {
            List<Character> characters = new List<Character>();
            foreach (var item in request.CharactersIds)
            {
                if (_characterRepository.GetById(item) is null)
                {
                    return NotFound();
                }
                characters.Add(_characterRepository.GetById(item));
            }
            var user = new User()
            {
                Id = request.Id,
                Username = request.UserName,
                Characters = characters
            };
            _userRepository.Update(user);
            _userRepository.Save();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            _userRepository.Delete(user);
            _userRepository.Save();
            return Ok(_userRepository.GetAll());
        }
    }
}

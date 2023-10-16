using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgAPI.Models;
using RpgAPI.Models.Dto.Character;
using RpgAPI.Repository;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IRpgClassRepository _rpgClassRepository;
        private readonly IWeaponRepository _weaponRepository;
        public CharacterController(ICharacterRepository characterRepository, IRpgClassRepository rpgClassRepository, IWeaponRepository weaponRepository)
        {
            _characterRepository = characterRepository;
            _rpgClassRepository = rpgClassRepository;
            _weaponRepository = weaponRepository;
        }
        [HttpGet]
        public ActionResult GetAllCharacters() 
        {
            var characters = _characterRepository.GetAll(
                include: x => x.Include(x => x.RpgClass)
                .Include(x => x.Weapon)
            );
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult GetCharacterById(int id) 
        {
            var character = _characterRepository.GetById(id);
            if (character is null)
            {
                return NotFound();
            }
            return Ok(character);
        }
        [HttpPost]
        public ActionResult AddNewCharacter(CreateCharacterDto request)
        {
            var rpgClass = _rpgClassRepository.GetById(request.RpgClassId);
            var weapon = _weaponRepository.GetById(request.WeaponId);

            if (rpgClass is null)
            {
                return NotFound();
            }
            if (weapon is null)
            {
                return NotFound();
            }
            var character = new Character()
            {
                Name = request.Name,
                RpgClass = rpgClass,
                Weapon = weapon,
                UserId = request.UserId
            };
            _characterRepository.Add(character);
            _characterRepository.Save();
            return Ok(character);
        }
        [HttpPut]
        public ActionResult EditCharacter(EditCharacterDto request) 
        {
            var rpgClass = _rpgClassRepository.GetById(request.RpgClassId);
            var weapon = _weaponRepository.GetById(request.WeaponId);
            if (rpgClass is null)
            {
                return NotFound();
            }
            if (weapon is null)
            {
                return NotFound();
            }
            var character = new Character()
            {
                Id = request.Id,
                Name = request.Name,
                RpgClass = rpgClass,
                Weapon = weapon,
                UserId = request.UserId
            };
            _characterRepository.Update(character);
            _characterRepository.Save();
            return Ok(character);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCharacter(int id)
        {
            var character = _characterRepository.GetById(id);
            if (character is null)
            {
                return NotFound();
            }
            _characterRepository.Delete(character);
            _characterRepository.Save();
            return Ok(character);
        }
    }
}

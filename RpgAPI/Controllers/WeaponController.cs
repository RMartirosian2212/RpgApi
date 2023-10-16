using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponRepository _weaponRepository;
        public WeaponController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        [HttpGet]
        public IActionResult GetAllWeapons()
        {
            var weapons = _weaponRepository.GetAll();
            return Ok(weapons);
        }
        [HttpGet("{id}")]
        public IActionResult GetWeaponById(int id)
        {
            var weapon = _weaponRepository.GetById(id);
            if (weapon is null)
            {
                return NotFound();
            }
            return Ok(weapon);
        }
        [HttpPost]
        public ActionResult AddNewWeapon(Weapon weapon)
        {
            _weaponRepository.Add(weapon);
            _weaponRepository.Save();
            return Ok(weapon);
        }
        [HttpPut]
        public ActionResult EditWeapon(Weapon weapon)
        {
            var existingWeapon = _weaponRepository.GetById(weapon.Id);
            if (existingWeapon == null)
            {
                return NotFound();
            }

            existingWeapon.Name = weapon.Name;
            existingWeapon.Damage = weapon.Damage;

            _weaponRepository.Save();
            return Ok(existingWeapon);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteWeapon(int id) 
        {
            var weapon = _weaponRepository.GetById(id);
            if (weapon is null)
            {
                return NotFound();
            }
            _weaponRepository.Delete(weapon);
            _weaponRepository.Save();
            return Ok(weapon);
        }
    }
}

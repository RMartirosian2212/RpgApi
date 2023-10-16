using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpgAPI.Models;
using RpgAPI.Repository.IRepository;

namespace RpgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgClassController : ControllerBase
    {
        private readonly IRpgClassRepository _rpgClassRepository;
        public RpgClassController(IRpgClassRepository rpgClassRepository)
        {
            _rpgClassRepository = rpgClassRepository;
        }
        [HttpGet]
        public ActionResult GetAllRpgClasses() 
        {
            var rpgClasses = _rpgClassRepository.GetAll();
            return Ok(rpgClasses);
        }
        [HttpGet("{id}")]
        public ActionResult GetRpgClassById(int id) 
        {
            var rpgClass = _rpgClassRepository.GetById(id);
            if (rpgClass is null)
            {
                return NotFound();
            }
            return Ok(rpgClass);
        }
        [HttpPost]
        public ActionResult CreateNewRpgClass(RpgClass rpgClass)
        {
            _rpgClassRepository.Add(rpgClass);
            _rpgClassRepository.Save();
            return Ok(rpgClass);
        }
        [HttpPut]
        public ActionResult EditRpgClass(RpgClass rpgClass)
        {
            _rpgClassRepository.Update(rpgClass);
            _rpgClassRepository.Save();
            return Ok(rpgClass);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteRpgClass(int id)
        {
            var rpgClass = _rpgClassRepository.GetById(id);
            if (rpgClass is null)
            {
                return NotFound();
            }
            _rpgClassRepository.Delete(rpgClass);
            _rpgClassRepository.Save();
            return Ok(_rpgClassRepository.GetAll());
        }
    }
}

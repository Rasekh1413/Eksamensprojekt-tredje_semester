using Microsoft.AspNetCore.Mvc;
using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LagerStatusEksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageTypeController : ControllerBase
    {
        private IServicePackageType _db;
        public PackageTypeController(IServicePackageType db)
        {
            _db = db;
        }

        // GET: api/<PackageTypeController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<PackageType>> GetAll()
        {
            var content = _db.GetAll();
            if (content.Count == 0) return NoContent();
            else return Ok(content);
        }

        // GET api/<PackageTypeController>/5
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PackageType> Get(string name)
        {
            var type = _db.GetByName(name);
            if (type == null) return NotFound();
            else return Ok(type);
        }

        // POST api/<PackageTypeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PackageType> Post([FromBody] PackageType value)
        {
            if (!IsValid(value)) return BadRequest();

            var result = _db.Add(value.Name, value);
            string uri = Url.RouteUrl(RouteData.Values) + "/" + result.Name;
            return Created(uri, result);
        }

        // PUT api/<PackageTypeController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PackageType> Put([FromBody] PackageType value)
        {
            if (!IsValid(value)) return BadRequest();

            var result = _db.Update(value.Name, value.Description);
            if (result == null) return NotFound();
            else return Ok(result);
        }

        // DELETE api/<PackageTypeController>/5
        [HttpDelete("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PackageType> Delete(string name)
        {
            var delete = _db.Delete(name);
            if (delete == null) return NotFound();
            else return Ok(delete);
        }

        private bool IsValid(PackageType packageType)
        {
            if (packageType.Name == null) return false;
            if (packageType.Name.Length > 15) return false;
            if (packageType.Description == null) return false;
            if (packageType.Description.Length > 255) return false;

            return true;
        }
    }
}

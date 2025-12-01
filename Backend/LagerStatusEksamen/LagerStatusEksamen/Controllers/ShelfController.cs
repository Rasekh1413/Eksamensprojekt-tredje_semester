using Microsoft.AspNetCore.Mvc;
using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LagerStatusEksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private IServiceShelf _db;
        private IServicePackageType _dbPT;
        public ShelfController(IServiceShelf db, IServicePackageType dbPT)
        {
            _db = db;
            _dbPT = dbPT;
        }

        // GET: api/<ShelfController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Shelf>> Get()
        {
            var content = _db.GetAll();
            if (content.Count == 0) return NoContent();
            else return Ok(content);
        }

        // GET api/<ShelfController>/5
        [HttpGet("{mac}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shelf> Get(string mac)
        {
            var type = _db.GetByMAC(mac);
            if (type == null) return NotFound();
            else return Ok(type);
        }

        // POST api/<ShelfController>
        [HttpPost]//This Post is weird and can also function as a Put
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Shelf> Post([FromBody] DataPackage value)
        {
            bool preExisting = _db.GetByMAC(value.MAC) != null;
            Shelf? shelf;
            if (preExisting)
            {
                shelf = _db.UpdateStatus(value.MAC, value.Status);
            }
            else
            {
                if (value.MAC.Length != 17) return BadRequest();
                shelf = new Shelf(value.MAC, null, value.Status);
                shelf = _db.Add(shelf);
            }
            if (preExisting)
            {
                return Ok(shelf);
            }
            else
            {
                string uri = Url.RouteUrl(RouteData.Values) + "/" + shelf.MAC;
                return Created(uri, shelf);
            }
        }

        // PUT api/<ShelfController>/5
        [HttpPut("{mac}/{type}")]//This Put only updates the PackageType
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shelf> Put(string mac, string type)
        {
            Shelf? shelf = _db.GetByMAC(mac);

            if (shelf == null) return NotFound();
            if (type.Length > 15 || _dbPT.GetByName(type) == null) return BadRequest();

            var result = _db.UpdatePackageType(mac, type);
            return Ok(result);
        }

        // DELETE api/<ShelfController>/5
        [HttpDelete("{mac}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shelf> Delete(string mac)
        {
            var delete = _db.Delete(mac);
            if (delete == null) return NotFound();
            else return Ok(delete);
        }
    }
}

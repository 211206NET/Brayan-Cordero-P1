using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IBL _bl;
        public StoreController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StoreController>
        [HttpGet]
        public List<StoreAddressOnly>  Get()
        {
            return _bl.GetAllStoresAddress();
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public ActionResult<Storefront> Get(int id)
        {
            Storefront storeFound =  _bl.GetStoreById(id);
            if(storeFound.ID != 0)
            {
                return Ok(storeFound);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        public ActionResult Post([FromBody] Storefront storeToAdd)
        {
            try
            {
                _bl.AddStore(storeToAdd);
                return Created("Successfully added", storeToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

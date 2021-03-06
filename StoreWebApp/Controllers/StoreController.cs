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
        [HttpGet("[action]/{id}")]
        [ActionName("GetInventory")]
        public ActionResult<List<Inventory>> Get(int id)
        {
            
            List<Inventory> inv = _bl.StoreInventory(id);
            if(id != 0)
            {
                return Ok(inv);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("[action]/{id}")]
        [ActionName("GetStoreById")]
        public ActionResult<StoreAddressOnly> GetStoreById(int id)
        {

            StoreAddressOnly inv = _bl.GetStoresAddressById(id);
            if (id != 0)
            {
                return Ok(inv);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<StoreController>/5
        [HttpGet("[action]/{StoreId}")]
        [ActionName("GetOrders")]
        public ActionResult<List<StoreOrders>> GetOrders(int StoreId)
        {

            List<StoreOrders> inv = _bl.AllStoreOrders(StoreId);
            if (StoreId != 0)
            {
                return Ok(inv);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        public ActionResult AddnewStore([FromBody] StoreAddressOnly storeToAdd)
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
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.DeleteStore(id);

        }
    }
}

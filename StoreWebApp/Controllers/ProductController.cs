using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return _bl.AllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {

            Product product = _bl.GetProductById(id);
            if (id != 0)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }
        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product newProduct)
        {
            try
            {
                _bl.AddProduct(newProduct);
                return Created("Successfully added", newProduct);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.DeleteProduct(id);
        }
    }
}

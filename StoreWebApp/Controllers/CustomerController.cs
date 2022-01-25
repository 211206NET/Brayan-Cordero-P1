using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using CustomExceptions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            return _bl.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("[action]/{id}")]
        [ActionName("GetCustomer")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customerFound = _bl.GetCustomerById(id);
            if (customerFound.Id != 0)
            {
                return Ok(customerFound);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<StoreController>/5
        [HttpGet("[action]/{StoreId}")]
        [ActionName("GetOrders")]
        public ActionResult<List<Order>> GetOrders(int StoreId)
        {

            List<Order> order = _bl.AllOrders(StoreId);
            if (StoreId != 0)
            {
                return Ok(order);
            }
            else
            {
                return NoContent();
            }
        }

      

        // POST api/<CustomerController>
        [HttpPost("[action]")]
        [ActionName("CreateAccount")]
        public ActionResult CreateAccount([FromBody] Customer customerToAdd)
        {
            try
            {
                _bl.AddCustomer(customerToAdd);
                return Created("Successfully added", customerToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // POST api/<CustomerController>
        [HttpPost("[action]")]
        [ActionName("AddToCart")]
        public ActionResult AddToCart([FromBody] Cart AddToCart)
        {
           
                _bl.AddToCart(AddToCart);
                return Created("Successfully added", AddToCart);
            
        }

        // GET api/<StoreController>/5
        [HttpGet("[action]")]
        [ActionName("SeeCart")]
        public ActionResult<List<CustomerCart>> GetCart()
        {

            return _bl.GetCart();

        }

        // POST api/<CustomerController>
        [HttpPost("[action]")]
        [ActionName("Checkout")]
        public ActionResult Chechout([FromBody] InfoForCheckout infoForCheckout)
        {
            string OrderDate = DateOnly.FromDateTime(DateTime.Now).ToString();
            List<CustomerCart> cart = _bl.GetCart();
            Checkout checkout = new Checkout();
            checkout.cart = cart;
            checkout.CalculateTotal();

            if (checkout.cartTotal != 0)
            {
                _bl.AddToOrders(checkout.cartTotal, infoForCheckout.StoreId, infoForCheckout.CustomerId, OrderDate);
                _bl.ClearCart();

                return Content($"Successfully Checkout \n Total: {checkout.cartTotal} \n, Thank you for your purchase :)");
            }
            else 
            {
                return Content("You have no items in your cart.");
            }
           
        }

        // PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.DeleteCustomer(id);

        }
    }
}

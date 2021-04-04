using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        // POST api/customers
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        //POST api/customers/1
        [HttpPost("{id}")]
        public IActionResult Post(int id)
        {
            return Ok();
        }

        //GET api/customers/1/orders/1
        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetAction(int id, int orderId)
        {
            return Ok();
        }
    }
}
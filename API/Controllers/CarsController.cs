using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // Post api/cars
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        // PUT api/cars/1
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        // DELETE api/cars/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
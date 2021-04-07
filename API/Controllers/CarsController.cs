
using System.Linq;
using API.Entities;
using API.InputModels;
using API.Persistence;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        public CarsController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _dbContext.Cars;
            var carsViewModel = cars
                .Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model, c.Price))
                .ToList();
            return Ok(carsViewModel);
        }

        // GET api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if(car == null)
            {
                return NotFound();
            }

            var carDetailsViewModel = new CarDetailsViewModel(
                car.Id,
                car.Brand,
                car.Model,
                car.VinCode,
                car.Year,
                car.Price,
                car.Color,
                car.ProductionDate
            );

            return Ok(carDetailsViewModel);
            // IF the id's car don't exists, return NOTFOUND
            // ELSE, OK
        }

        // Post api/cars
        [HttpPost]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            // IF the register works out, return CREATED(201)
            // IF Data in is incorrect, Return BAD REQUEST (400)
            // IF Register works out, but there is a Consult API, Return NOCONTENT
            if(model.Model.Length > 50)
            {
                return BadRequest("Model can not have more than 50 characters");
            }
            var car = new Car(model.VinCode, model.Brand, model.Model, model.Year, model.Price, model.Color, model.ProductionData);
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id},
                model
            );
        }

        // PUT api/cars/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);
            if(car == null)
            {
                return NotFound();
            }

            car.Update(model.Color, model.Price);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE api/cars/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);
            if(car == null)
            {
                return NotFound();
            }
            car.SetAsSuspended();
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
using System.Linq;
using API.Entities;
using API.InputModels;
using API.Persistence;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        public CustomersController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel model)
        {
            var customer = new Customer(model.FullName, model.Document, model.BirthDate);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return NoContent();
        }

        //POST api/customers/1
        [HttpPost("{id}/orders")]
        public IActionResult Post(int id, [FromBody] AddOrderInputModel model)
        {
            var extraItems = model.ExtraItems.Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == model.IdCar);
            var order = new Order(model.IdCar, model.IdCustomer, car.Price, extraItems);
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return CreatedAtAction(
                nameof(GetOrder),
                new {id = order.IdCustomer, orderId = order.Id},
                model
            );
        }

        //GET api/customers/1/orders/1
        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            var order = _dbContext.Orders
            .Include(o => o.ExtraItems)
            .SingleOrDefault(o => o.Id == orderId);
            
            if(order == null)
            {
                return NotFound();
            }

            var extraItems = order
            .ExtraItems
            .Select(e => e.Description)
            .ToList();
            
            var orderViewModel = new OrderDetailsViewModel(order.IdCar, order.IdCustomer, order.TotalCost, extraItems);
            return Ok(orderViewModel);
        }
    }
}
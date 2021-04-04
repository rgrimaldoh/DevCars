using System.Collections.Generic;
using API.Entities;

namespace API.Persistence
{
    public class DevCarsDbContext
    {
        public DevCarsDbContext()
        {
            Cars = new List<Car>
            {
                new Car(1,"123ABC", "HONDA","CIVIC",2021, 10000, "Red", new System.DateTime(2021, 1, 1)),
                new Car(2,"345ABC", "VW","JETTA",2021, 20000, "White", new System.DateTime(2021, 4, 2)),
                new Car(3,"567ABC", "TESLA","125",2021, 30000, "Black", new System.DateTime(2021, 2, 3))
            };
            Customers = new List<Customer>
            {
                new Customer(1,"Ignacio Gomez", "1254GTSRA", new System.DateTime(1970, 2, 5)),
                new Customer(2,"Juan Carlos Perez", "1254JCP", new System.DateTime(1975, 5, 18)),
                new Customer(3,"Joaquin Lopez", "1254JL", new System.DateTime(1985, 12, 15)),
            };
        }

        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
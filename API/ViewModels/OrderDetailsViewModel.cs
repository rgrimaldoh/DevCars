using System.Collections.Generic;

namespace API.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel(int idCar, int idCustomer, decimal totalCost, List<string> extraItems)
        {
            IdCar = idCar;
            IdCustomer = idCustomer;
            TotalCost = totalCost;
            ExtraItems = extraItems;
        }

        public int IdCar { get; set; }
        public int IdCustomer { get; set; }
        public decimal TotalCost { get; set; }
        public List<string> ExtraItems { get; set; }
    }
}
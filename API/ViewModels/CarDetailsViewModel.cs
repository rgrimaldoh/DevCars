using System;

namespace API.ViewModels
{
    public class CarDetailsViewModel
    {
        public CarDetailsViewModel(int id, string brand, string model, string vinCode, int year, decimal price, string color, DateTime productionData)
        {
            Id = id;
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Color = color;
            ProductionData = productionData;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime ProductionData { get; set; }
    }
}
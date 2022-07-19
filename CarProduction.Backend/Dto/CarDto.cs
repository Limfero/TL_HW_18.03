using System;

namespace CarProduction.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Model { get;set; }
        public DateTime BuildData { get; set; }
        public int Price { get; set; }
        public int ManufacturerId { get; set; }

    }
}

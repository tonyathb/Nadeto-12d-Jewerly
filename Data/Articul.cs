using System;

namespace Jewerly.Data
{
    public class Articul
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }    
        public string Type { get; set; }
        public string ImageUrl { get; set; }   
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime RegisterOn { get; set; }

    }
}

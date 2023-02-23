using System;

namespace Jewerly.Data
{
    public class Shopping
    {
        public int Id { get; set; } 
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }

        public int ArticulId { get; set; }
        public Articul Articuls { get; set; }


        public int Quantity { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jewerly.Data
{
    public class Articul
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public int TypeId { get; set; }
        public Type Types { get; set; }

        public string ImageUrl { get; set; }
        [Column(TypeName="decimal(10,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime RegisterOn { get; set; }

        public ICollection<Shopping> Shopings { get; set; }

    }
}

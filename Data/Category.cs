using System;

namespace Jewerly.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime RegisterOn { get; set; }
        public ICollection<Articul> Articuls { get; set; }
    }
}

using System;

namespace Jewerly.Data
{
    public class Type
    {
        public int Id { get; set; }
        public string TypeName { get; set; }    
        public DateTime RegisterOn { get; set; }
        public ICollection<Articul> Articuls { get; set; }    
    }
}

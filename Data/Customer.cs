using Microsoft.AspNetCore.Identity;
using System;
using System.Data;

namespace Jewerly.Data
{
    public class Customer:IdentityUser
    {
        public string LastName { get; set; }    
        public ICollection<Shopping> Shoppings { get; set; }
        public DateTime RegisterOn { get; set; }
    }
}

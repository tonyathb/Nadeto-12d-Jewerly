using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jewerly.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Articul> Articuls { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using Models ;
namespace BackEndAaaapero.Data
{
    public class Context
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Customer> customers { get; set; }
    }
}
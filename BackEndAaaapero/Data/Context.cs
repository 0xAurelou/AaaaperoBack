using BackEndAaaapero.Models;
using Microsoft.EntityFrameworkCore;
using Models;
namespace BackEndAaaapero.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Customers> customers { get; set; }
        public DbSet<User> User {get; set; }
    }
}
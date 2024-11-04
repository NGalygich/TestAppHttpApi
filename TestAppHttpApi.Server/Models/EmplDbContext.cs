using Microsoft.EntityFrameworkCore;

namespace TestAppHttpApi.Server.Models
{
    public class EmplDbContext : DbContext
    {
        public EmplDbContext(DbContextOptions<EmplDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}

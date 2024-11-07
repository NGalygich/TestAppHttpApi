using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestAppHttpApi.Server.Models
{
    public class TestAppHttpApiServerContext : DbContext
    {
        public TestAppHttpApiServerContext(DbContextOptions<TestAppHttpApiServerContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;

    }
}

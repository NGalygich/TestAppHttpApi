using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppHttpApi.Server;

namespace TestAppHttpApi.Server.Data
{
    public class TestAppHttpApiServerContext : DbContext
    {
        public TestAppHttpApiServerContext (DbContextOptions<TestAppHttpApiServerContext> options)
            : base(options)
        {
        }

        public DbSet<TestAppHttpApi.Server.Employee> Employee { get; set; } = default!;

    }
}

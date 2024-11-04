using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestAppHttpApi.Server.Models;

namespace TestAppHttpApi.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<EmplDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));


            //services.AddCors();
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TestDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            services.AddDbContext<EmplDbContext>(options =>
            options.UseSqlite(connection));
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

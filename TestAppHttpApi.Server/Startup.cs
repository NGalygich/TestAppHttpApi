using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(); 

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddControllers();
           
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TestDB.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            services.AddDbContext<TestAppHttpApiServerContext>(options =>
            options.UseSqlite(connection));
            //builder.Services.AddCors();
            services.AddCors();
            services.AddMvc();
            //builder.Services.AddControllers();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            ////app.MapControllers();

            //app.Run();

            //здесь были попытки реализовать отображение API в Swagger, но не хватило времени понять как сделать правильно
            //при работе в режиме отображения API в Swagger, сервер не принимал запросы от клиента

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(options =>
            //options.WithOrigins("http://localhost:3000/" )
            //.AllowAnyHeader()
            //.AllowAnyMethod());
            app.UseCors(
                   options => options.WithOrigins("http://localhost:3000/")
                         .AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
               );
            //app.UseMvc();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         

            app.UseRouting();
            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
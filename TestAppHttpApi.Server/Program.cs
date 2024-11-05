using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestAppHttpApi.Server.Data;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TestAppHttpApiServerContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("TestAppHttpApiServerContext") ?? throw new InvalidOperationException("Connection string 'TestAppHttpApiServerContext' not found.")));

//public void ConfigureServices(IServiceCollection services)
//{
    builder.Services.AddControllers();

    //services.AddDbContext<EmplDbContext>(options =>
    //options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));


    //services.AddCors();
    var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TestDB.db" };
    var connectionString = connectionStringBuilder.ToString();
    var connection = new SqliteConnection(connectionString);
    builder.Services.AddDbContext<TestAppHttpApiServerContext>(options =>
    options.UseSqlite(connection));
    builder.Services.AddCors();
//}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

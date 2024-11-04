using Microsoft.Data.Sqlite;

#region Создание БД, таблиц
//using (var connection = new SqliteConnection("Data Source=TestDB.db"))
//{
//    connection.Open();
//    SqliteCommand command = new SqliteCommand();
//    command.Connection = connection;
//    //command.CommandText = "DROP TABLE Employees";
//    //command.ExecuteNonQuery();
//    command.CommandText = "CREATE TABLE ClosureTable(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, ParentId INTEGER NOT NULL, ChildId INTEGER NOT NULL, Depth INTEGER NOT NULL)";
//    command.ExecuteNonQuery();
//    command.CommandText = "CREATE TABLE Employees(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, LastName TEXT NOT NULL, FirstName TEXT NOT NULL, MiddleName TEXT NOT NULL, PositionCode TEXT NOT NULL, DepartmentCode TEXT NOT NULL, IsHidden BLOB NOT NULL, LastModified DATE NOT NULL)";
//    command.ExecuteNonQuery();
//    command.CommandText = "insert into Employees values ('1','Иванов', 'Иван', 'Иванович', '1', '0', '0', date('now', '-5 months', '-3 days'))";
//    command.ExecuteNonQuery();
//    command.CommandText = "insert into Employees values ('2', 'Петров', 'Владимир', 'Петрович', '10', '1', '0', date('now', '-4 months', '-3 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('3','Сидоров', 'Петр', 'Дмитриевич', '101', '1', '0', date('now', '-4 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('4','Смирнов', 'Дмитрий', 'Иванов', '102', '1', '0', date('now', '-4 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('5','Соколов', 'Иван', 'Михайлович', '103', '1', '0', date('now', '-5 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('6','Кузнецов', 'Михаил', 'Владимирович', '1031', '1', '0', date('now', '-5 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('7','Попова', 'Мария', 'Александровна', '1032', '1', '0', date('now', '-5 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('8','Новикова', 'Анна', 'Олеговна', '11', '2', '0', date('now', '-5 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('9','Морозов', 'Сергей', 'Александрович', '111', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('10','Зайцев', 'Александр', 'Дмитриевич', '112', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('11','Виноградов', 'Дмитрий', 'Евгеньевич', '113', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('12','Казаков', 'Олег', 'Петрович', '1111', '2', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('13','Суханов', 'Даниил', 'Иванович', '12', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('14','Воробьёва', 'Алиса', 'Владимировна', '121', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('15','Богданова', 'Евгения', 'Михайловна', '122', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('16','Тихонов', 'Денис', 'Петрович', '123', '3', '0', date('now', '-5 months', '-8 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('17','Муравьёв', 'Григорий', 'Михайлович', '1211', '3', '0', date('now', '-5 months', '-8 days'))";
//    command.ExecuteNonQuery();

//    Console.WriteLine("Таблицы созданы");
//}
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

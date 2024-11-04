using Microsoft.Data.Sqlite;

#region �������� ��, ������
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
//    command.CommandText = "insert into Employees values ('1','������', '����', '��������', '1', '0', '0', date('now', '-5 months', '-3 days'))";
//    command.ExecuteNonQuery();
//    command.CommandText = "insert into Employees values ('2', '������', '��������', '��������', '10', '1', '0', date('now', '-4 months', '-3 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('3','�������', '����', '����������', '101', '1', '0', date('now', '-4 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('4','�������', '�������', '������', '102', '1', '0', date('now', '-4 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('5','�������', '����', '����������', '103', '1', '0', date('now', '-5 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('6','��������', '������', '������������', '1031', '1', '0', date('now', '-5 months', '-4 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('7','������', '�����', '�������������', '1032', '1', '0', date('now', '-5 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('8','��������', '����', '��������', '11', '2', '0', date('now', '-5 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('9','�������', '������', '�������������', '111', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('10','������', '���������', '����������', '112', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('11','����������', '�������', '����������', '113', '2', '0', date('now', '-4 months', '-5 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('12','�������', '����', '��������', '1111', '2', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('13','�������', '������', '��������', '12', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('14','���������', '�����', '������������', '121', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('15','���������', '�������', '����������', '122', '3', '0', date('now', '-4 months', '-7 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('16','�������', '�����', '��������', '123', '3', '0', date('now', '-5 months', '-8 days'))";
//    command.ExecuteNonQuery(); 
//    command.CommandText = "insert into Employees values ('17','��������', '��������', '����������', '1211', '3', '0', date('now', '-5 months', '-8 days'))";
//    command.ExecuteNonQuery();

//    Console.WriteLine("������� �������");
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

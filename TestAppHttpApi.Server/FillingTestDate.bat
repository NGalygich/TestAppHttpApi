::Скрипт для заполнения тестовой базы
::При заполнении таблицы через командную строку не поддерживается кодировка UTF-8
::Не хватило времени разобраться

@echo off 

::таблица сотрудников
.\sqlite3.exe TestDB.db "drop table Employee"
.\sqlite3.exe TestDB.db "create table Employee(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, FirstName TEXT NOT NULL, MiddleName TEXT NOT NULL, LastName TEXT NOT NULL, PositionCode TEXT NOT NULL, DepartmentCode TEXT NOT NULL, IsHidden BLOB NOT NULL, LastModified DATE NOT NULL)"
.\sqlite3.exe TestDB.db "delete from Employee;"

.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Ivanov', 'Ivan', 'Ivanovich', '1', '0', '0', date('now', '-5 months', '-3 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Petrov', 'Vladimir', 'Petrovich', '10', '1', '0', date('now', '-4 months', '-3 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Sidorov', 'Petr', 'Dmitrievich', '101', '1', '0', date('now', '-4 months', '-4 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Smirnov', 'Dmitrij', 'Ivanov', '102', '1', '0', date('now', '-4 months', '-4 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Sokolov', 'Ivan', 'Mihajlovich', '103', '1', '0', date('now', '-5 months', '-4 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Kuznecov', 'Mihail', 'Vladimirovich', '1031', '1', '0', date('now', '-5 months', '-4 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Popova', 'Mariya', 'Aleksandrovna', '1032', '1', '0', date('now', '-5 months', '-5 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Novikova', 'Anna', 'Olegovna', '11', '2', '0', date('now', '-5 months', '-5 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Morozov', 'Sergej', 'Aleksandrovich', '111', '2', '0', date('now', '-4 months', '-5 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Zajcev', 'Aleksandr', 'Dmitrievich', '112', '2', '0', date('now', '-4 months', '-5 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Vinogradov', 'Dmitrij', 'Evgenevich', '113', '2', '0', date('now', '-4 months', '-5 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Kazakov', 'Oleg', 'Petrovich', '1111', '2', '0', date('now', '-4 months', '-7 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Suhanov', 'Daniil', 'Ivanovich', '12', '3', '0', date('now', '-4 months', '-7 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Vorobyova', 'Alisa', 'Vladimirovna', '121', '3', '0', date('now', '-4 months', '-7 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Bogdanova', 'Evgeniya', 'Mihajlovna', '122', '3', '0', date('now', '-4 months', '-7 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Tihonov', 'Denis', 'Petrovich', '123', '3', '0', date('now', '-5 months', '-8 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Muravyov', 'Grigorij', 'Mihajlovich', '1211', '3', '0', date('now', '-5 months', '-8 days'))"
.\sqlite3.exe TestDB.db "insert into Employee (FirstName, MiddleName, LastName, PositionCode, DepartmentCode, IsHidden, LastModified) values ('Maheev', 'Ivan', 'Ivanovich', '1212', '3', '0', date('now', '-5 months', '-8 days'))"

::ClosureTable(Id, ParentId, ChildId, Depth) ::таблица подчиненности для древовидной структуры
.\sqlite3.exe TestDB.db "drop table ClosureTable"
.\sqlite3.exe TestDB.db "create table ClosureTable(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, ParentId INTEGER NOT NULL, ChildId INTEGER NOT NULL, Depth INTEGER NOT NULL)"
.\sqlite3.exe TestDB.db "delete from ClosureTable;"

.\sqlite3.exe TestDB.db "insert into ClosureTable (ParentId, ChildId, Depth) select e_1.Id as ParentId, e_2.Id as ChildId, iif(e_1.PositionCode = substring(e_2.PositionCode, 0, length(e_2.PositionCode)), iif(e_1.Id = e_2.Id, 0, 1), iif(e_1.PositionCode = substring(e_2.PositionCode, 0, length(e_2.PositionCode) - 1), iif(e_1.Id = e_2.Id, 0, 1) + 1, iif(e_1.Id = e_2.Id, 0, 1) + 2)) as Depth from Employee as e_1 cross join Employee as e_2 where e_1.DepartmentCode = e_2.DepartmentCode and (e_1.PositionCode = substring(e_2.PositionCode, 0, length(e_2.PositionCode)) or e_1.PositionCode = substring(e_2.PositionCode, 0, length(e_2.PositionCode) - 1)) or e_1.DepartmentCode = '0' and e_2.Id <> 1"

.\sqlite3.exe TestDB.db "select * from Employee;" ".exit"
.\sqlite3.exe TestDB.db "select * from ClosureTable;" ".exit"

pause
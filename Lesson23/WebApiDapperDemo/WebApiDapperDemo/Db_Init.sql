create database MyCompanyDemoDb
go
use MyCompanyDemoDb
create table Employee
(
	Id int primary key identity,
	FirstName nvarchar(100) not null,
	Age int not null,
	Address nvarchar(255) not null,
	Phone nvarchar(50) not null
)
go
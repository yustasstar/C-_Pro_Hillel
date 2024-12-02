create database AdoNetDemo
go
use AdoNetDemo
go
create table Student(
	Id int primary key identity (1, 1),
	UserName nvarchar(50) not null,
	Email nvarchar(100) null,
	Phone nvarchar(50) not null
);

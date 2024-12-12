create database REG_INFO
go
use REG_INFO
CREATE TABLE users (
id int not null identity(1,1), 
firstname nvarchar(255) not null, 
lastname nvarchar(255) not null,
login nvarchar(255) not null unique,
password nvarchar(255) not null,
salt nvarchar(255) not null
)
go
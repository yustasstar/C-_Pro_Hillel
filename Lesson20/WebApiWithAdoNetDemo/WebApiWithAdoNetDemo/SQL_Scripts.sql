-- use sql script from previous example
--
use AdoNetDemo
go
create procedure InsertNewStudent
	@UserName nvarchar(50),
	@Email nvarchar(100),
	@Phone nvarchar(50)
as
	set nocount on;
	insert into [dbo].[Student] (UserName, Email, Phone)
	values (@UserName, @Email, @Phone)
go

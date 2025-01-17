/*
   Friday, November 8, 202411:00:17 PM
   User: 
   Server: .
   Database: HW_8_DB
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Students
	(
	ID smallint NOT NULL IDENTITY (1, 1),
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	MiddleName nvarchar(50) NULL,
	DateOfBirth smalldatetime NOT NULL,
	Country nvarchar(50) NULL,
	City nvarchar(50) NULL,
	Address nvarchar(50) NULL,
	Email nvarchar(50) NOT NULL,
	Phone nvarchar(20) NULL,
	GroupName nvarchar(20) NULL,
	AVG_Grade_AllSubjects tinyint NULL,
	minAVG_SubjectName tinyint NULL,
	maxAVG_SubjectName tinyint NULL,
	isActive bit NOT NULL,
	isDeleted bit NOT NULL,
	Created datetime2(7) NOT NULL,
	Updated datetime2(7) NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'“Student_Grades” '
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Students', NULL, NULL
GO
ALTER TABLE dbo.Students ADD CONSTRAINT
	PK_Students PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Students SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

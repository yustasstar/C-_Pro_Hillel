-- DB Creation
CREATE DATABASE HW_8_DB
ON  PRIMARY 
(
    NAME = N'HW_8_DB',
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HW_8_DB.mdf', 
    SIZE = 8192KB, 
    FILEGROWTH = 65536KB
)
LOG ON 
(
    NAME = N'HW_8_DB_log', 
    FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HW_8_DB_log.ldf', 
    SIZE = 8192KB, 
    FILEGROWTH = 65536KB
);

GO
USE HW_8_DB;

-- Setting up the database with specific configurations
ALTER DATABASE [HW_8_DB] SET COMPATIBILITY_LEVEL = 160;
GO

-- Create the Students table with required constraints and default values
CREATE TABLE dbo.Students
(
    ID SMALLINT IDENTITY (1, 1), -- Unique student identifier
    FirstName NVARCHAR(50) NOT NULL,          				
	LastName NVARCHAR(50) NOT NULL,           				
    MiddleName NVARCHAR(50), -- Middle name (optional)									
    DateOfBirth DATE NOT NULL,                				
    Country NVARCHAR(50),                     				
    City NVARCHAR(50),                        					
    Email NVARCHAR(100) NOT NULL,   	
    Phone NVARCHAR(20),             	
    GroupName NVARCHAR(20),                   					
    AVG_Grade TINYINT,    
    minAVG_SubjectName NVARCHAR(20),          					
    maxAVG_SubjectName NVARCHAR(20),         		 			
    isActive BIT NOT NULL DEFAULT 1, -- Status of the student is active by default,         					
    isDeleted BIT NOT NULL DEFAULT 0, -- Status of the student is not deleted by default,          					
    Created DATETIME2(0) NOT NULL DEFAULT GETDATE(), -- Record creation date 			
    Updated DATETIME2(0) NOT NULL DEFAULT GETDATE(), -- Last update date

	CONSTRAINT PK_Id PRIMARY KEY (ID), 
    CONSTRAINT UQ_Email UNIQUE (Email), -- Email must be unique
    CONSTRAINT UQ_Phone UNIQUE (Phone), -- Phone number must be unique
	CONSTRAINT CK_Email CHECK(Email != ''), -- Ensure email is not empty
	CONSTRAINT CK_Phone CHECK(Phone != ''), -- Ensure phone number is not empty
	CONSTRAINT CK_DateOfBirth CHECK(DateOfBirth BETWEEN '1934-01-01' AND '2010-12-31'),  -- Ensure valid date of birth
);

-- Insert sample data into Students table
INSERT INTO Students 
(FirstName, LastName, MiddleName, DateOfBirth, Country, City, Email, Phone, GroupName, AVG_Grade, minAVG_SubjectName, maxAVG_SubjectName)
VALUES
('Sophia', 'Taylor', NULL, '2002-04-19', 'USA', 'Boston', 'sophia.taylor@example.com', '1112223334', 'Group 4', 85, 'Biology', 'Physics'),
('Mason', 'Anderson', 'George', '2003-11-15', 'Canada', 'Vancouver', 'mason.anderson@example.com', '1223334445', 'Group 5', 74, 'Math', 'Science'),
('Isabella', 'Wilson', 'Marie', '2000-02-10', 'UK', 'Liverpool', 'isabella.wilson@example.com', '3334445556', 'Group 3', 92, 'English', 'Art'),
('James', 'Martinez', 'Thomas', '2001-09-23', 'Australia', 'Melbourne', 'james.martinez@example.com', '4445556667', 'Group 4', 67, 'History', 'Geography'),
('Mia', 'Davis', NULL, '2002-05-30', 'USA', 'Chicago', 'mia.davis@example.com', '5556667778', 'Group 5', 88, 'Physics', 'Chemistry'),
('Logan', 'Lee', 'Patrick', '1999-07-18', 'USA', 'Seattle', 'logan.lee@example.com', '6667778889', 'Group 6', 79, 'Math', 'English'),
('Ella', 'Clark', NULL, '2000-11-05', 'Canada', 'Ottawa', 'ella.clark@example.com', '7778889990', 'Group 1', 83, 'Science', 'Art'),
('Benjamin', 'Hall', 'Isaac', '2003-01-21', 'UK', 'Manchester', 'benjamin.hall@example.com', '8889990001', 'Group 2', 90, 'History', 'Geography'),
('Ava', 'Green', 'Charlotte', '2001-08-14', 'Australia', 'Brisbane', 'ava.green@example.com', '9990001112', 'Group 3', 69, 'Math', 'Science'),
('Noah', 'Young', 'Lucas', '2002-10-12', 'India', 'Delhi', 'noah.young@example.com', '1002003004', 'Group 5', 76, 'Biology', 'Chemistry'),
('Amelia', 'Scott', NULL, '2000-09-29', 'USA', 'Los Angeles', 'amelia.scott@example.com', '1102203305', 'Group 6', 82, 'Art', 'English'),
('Henry', 'Adams', 'William', '2003-03-09', 'Canada', 'Montreal', 'henry.adams@example.com', '1202303406', 'Group 1', 73, 'Geography', 'Science'),
('Emily', 'Hernandez', NULL, '1999-04-26', 'UK', 'London', 'emily.hernandez@example.com', '1302403507', 'Group 2', 81, 'Math', 'Biology'),
('Jack', 'King', 'David', '2001-12-13', 'Australia', 'Perth', 'jack.king@example.com', '1402503608', 'Group 3', 68, 'History', 'Physics'),
('Chloe', 'Wright', NULL, '2002-06-01', 'USA', 'Houston', 'chloe.wright@example.com', '1502603709', 'Group 4', 77, 'Science', 'Art')


-- Selecting all data from the Students table to verify insertion -- Display all student information
SELECT * FROM Students;

-- Display full names of all students
SELECT FirstName, MiddleName, LastName FROM dbo.Students;

-- Display all average grades for students
SELECT FirstName, LastName, AVG_Grade FROM dbo.Students;

-- Display full names of students with average grade greater than a specified value
DECLARE @MinGrade TINYINT = 80; -- Мінімальна оцінка для порівняння
SELECT FirstName, MiddleName, LastName, AVG_Grade
FROM dbo.Students
WHERE AVG_Grade > @MinGrade;

-- Display unique countries of all students
SELECT DISTINCT Country FROM dbo.Students;

-- Display unique cities where students are located
SELECT DISTINCT City FROM dbo.Students;

-- Display unique group names
SELECT DISTINCT GroupName FROM dbo.Students;

-- Display unique subjects for minimum and maximum average grades
SELECT DISTINCT minAVG_SubjectName AS SubjectName FROM dbo.Students
UNION
SELECT DISTINCT maxAVG_SubjectName FROM dbo.Students;
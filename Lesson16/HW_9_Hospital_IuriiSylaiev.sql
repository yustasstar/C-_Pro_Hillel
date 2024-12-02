CREATE DATABASE Hospital;
GO

USE Hospital;
GO

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Financing MONEY NOT NULL CHECK (Financing >= 0) DEFAULT 0,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name != '')   
);
GO

CREATE TABLE Diseases (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name != ''),
    Severity INT NOT NULL CHECK (Severity >= 1) DEFAULT 1
);
GO

CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(MAX) NOT NULL CHECK (Name != ''),
    Phone CHAR(10) NULL,
    Salary MONEY NOT NULL CHECK (Salary > 0),
    Surname NVARCHAR(MAX) NOT NULL CHECK (Surname != '')
);
GO

CREATE TABLE Examinations (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    EndTime TIME NOT NULL,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name != ''),
    StartTime TIME NOT NULL CHECK (StartTime BETWEEN '08:00' AND '18:00'),
    CONSTRAINT CHK_EndTime_After_StartTime CHECK (EndTime > StartTime)
);
GO

CREATE TABLE Wards (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Floor INT NOT NULL CHECK (Floor >= 1),
    Name NVARCHAR(20) NOT NULL UNIQUE CHECK (Name != '')
);
GO

-- Вставка даних у таблицю Departments
INSERT INTO Departments (Building, Financing, Name)
VALUES
(1, 18000, 'Gastroenterology'),
(2, 22000, 'Urology'),
(3, 14000, 'Dermatology'),
(4, 25000, 'Pulmonology'),
(5, 31000, 'Endocrinology'),
(1, 16000, 'Hematology'),
(2, 20000, 'Ophthalmology'),
(3, 13500, 'Psychiatry'),
(4, 28000, 'Rheumatology'),
(5, 29500, 'Immunology');
GO
-- Вставка даних у таблицю Diseases
INSERT INTO Diseases (Name, Severity)
VALUES
('Hypertension', 2),
('Asthma', 3),
('Tuberculosis', 4),
('Pneumonia', 3),
('Hepatitis', 5),
('Eczema', 2),
('Alzheimer', 5),
('Parkinson', 4),
('Anemia', 2),
('Cystic Fibrosis', 5);
GO
-- Вставка даних у таблицю Doctors
INSERT INTO Doctors (Name, Phone, Salary, Surname)
VALUES
('Olivia', '5678901234', 2800, 'Martinez'),
('Noah', '2345678901', 3200, 'Garcia'),
('Isabella', '3456789012', 2700, 'Lee'),
('Ethan', '4567890123', 2500, 'Davis'),
('Ava', '1234567890', 3100, 'Taylor'),
('Lucas', '6789012345', 2000, 'Harris'),
('Mia', '8901234567', 2900, 'Clark'),
('Benjamin', NULL, 3100, 'Lewis'),
('Sophia', '6789012345', 3300, 'Walker'),
('William', '3456789012', 2400, 'Hall');
GO
-- Вставка даних у таблицю Examinations
INSERT INTO Examinations (DayOfWeek, EndTime, Name, StartTime)
VALUES
(1, '11:00', 'ECG', '10:00'),
(2, '13:00', 'Blood Sugar Test', '12:00'),
(3, '14:30', 'Liver Function Test', '13:30'),
(4, '16:00', 'Thyroid Test', '15:00'),
(5, '17:00', 'Cholesterol Test', '16:00'),
(6, '11:30', 'Vision Test', '10:30'),
(7, '12:30', 'Allergy Test', '11:30'),
(1, '10:00', 'Urine Analysis', '09:00'),
(2, '14:00', 'Kidney Function Test', '13:00'),
(3, '15:30', 'Heart Rate Monitor', '14:30');
GO 
-- Вставка даних у таблицю Wards
INSERT INTO Wards (Building, Floor, Name)
VALUES
(1, 2, 'Ward F'),
(2, 3, 'Ward G'),
(3, 1, 'Ward H'),
(4, 2, 'Ward I'),
(5, 3, 'Ward J'),
(1, 3, 'Ward K'),
(2, 1, 'Ward L'),
(3, 2, 'Ward M'),
(4, 1, 'Ward N'),
(5, 2, 'Ward O');
GO
-- 1. Вивести вміст таблиці палат.
SELECT * 
FROM Wards;
GO
-- Виводить всі дані з таблиці "Wards".

-- 2. Вивести прізвища та телефони усіх лікарів.
SELECT Surname, Phone 
FROM Doctors;
GO
-- Виводить лише прізвища та телефони лікарів.

-- 3. Вивести усі поверхи без повторень, де розміщуються палати.
SELECT DISTINCT Floor 
FROM Wards;
GO
-- Використовується DISTINCT для уникнення повторень.

-- 4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
SELECT Name AS [Name of Disease], Severity AS [Severity of Disease] 
FROM Diseases;
GO
-- Використовуються псевдоніми для колонок.

-- 5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
SELECT d.Name AS DoctorName, e.Name AS ExaminationName, w.Name AS WardName
FROM Doctors d, Examinations e, Wards w;
GO
-- Псевдоніми d, e, w використовуються для скорочення імен таблиць.

-- 6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
SELECT Name 
FROM Departments 
WHERE Building = 5 AND Financing < 30000;
GO
-- Умови для корпусу та фінансування.

-- 7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
SELECT Name 
FROM Departments 
WHERE Building = 3 AND Financing BETWEEN 12000 AND 15000;
GO
-- Використовується BETWEEN для діапазону.

-- 8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
SELECT Name 
FROM Wards 
WHERE Building IN (4, 5) AND Floor = 1;
GO
-- Умови для корпусів і поверху.

-- 9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 4 або 5 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
SELECT Name, Building, Financing 
FROM Departments 
WHERE Building IN (4, 5) AND (Financing < 11000 OR Financing > 25000);
GO
-- Використовується OR для множинних умов.

-- 10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
ALTER TABLE Doctors
ADD Bonus MONEY NOT NULL DEFAULT 0 CHECK (Bonus >= 0) ;  -- new column added
GO

SELECT * FROM Doctors

UPDATE Doctors
SET Bonus = 650
WHERE Id = 1;  -- Doctor with Id = 1
GO
UPDATE Doctors
SET Bonus = 500
WHERE Id = 3;  -- Doctor with Id = 3
GO
UPDATE Doctors
SET Bonus = 275
WHERE Id = 5;  -- Doctor with Id = 5
GO
UPDATE Doctors
SET Bonus = 100
WHERE Id = 7;  -- Doctor with Id = 7
GO
UPDATE Doctors
SET Bonus = 300
WHERE Id = 9;  -- Doctor with Id = 9
GO

SELECT Surname, (Salary + Bonus) AS TotalSalary
FROM Doctors
WHERE (Salary + Bonus) > 1500;
GO
-- 11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.
SELECT Surname 
FROM Doctors
WHERE (Salary / 2) > (Bonus * 3);
GO
-- 12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
SELECT DISTINCT Name 
FROM Examinations
WHERE DayOfWeek BETWEEN 1 AND 3 
  AND StartTime BETWEEN '12:00' AND '15:00';
GO
-- 13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
SELECT Name, Building 
FROM Departments
WHERE Building IN (1, 3, 8, 10);
GO
-- 14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
SELECT Name
FROM Diseases
WHERE Severity NOT IN (1, 2);
GO
-- 15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
SELECT Name 
FROM Departments
WHERE Building NOT IN (1, 3);
GO
-- 16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
SELECT Name 
FROM Departments
WHERE Building IN (1, 3);
GO
-- 17. Вивести прізвища лікарів, що починаються з літери «M».
SELECT Surname
FROM Doctors
WHERE Surname LIKE 'M%';
GO
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
SELECT * FROM Wards;
GO
-- Виводить всі дані з таблиці "Wards".

-- 2. Вивести прізвища та телефони усіх лікарів.
SELECT Surname, Phone FROM Doctors;
GO
-- Виводить лише прізвища та телефони лікарів.

-- 3. Вивести усі поверхи без повторень, де розміщуються палати.
SELECT DISTINCT Floor FROM Wards;
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
GO
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


-- Оновлення існуючих таблиць та створення нових
-- Таблиця: Спеціалізації (Specializations)
CREATE TABLE Specializations (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
);
GO

INSERT INTO Specializations (Name) VALUES
    ('Cardiologist'), 
    ('Neurologist'), 
    ('Orthopedic Surgeon'), 
    ('Pediatrician');
GO
-- Таблиця: Лікарі та спеціалізації (DoctorsSpecializations)
CREATE TABLE DoctorsSpecializations (
    Id INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
    SpecializationId INT NOT NULL FOREIGN KEY REFERENCES Specializations(Id)
);
GO

INSERT INTO DoctorsSpecializations (DoctorId, SpecializationId) VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 4),
    (6, 3),
    (7, 2),
    (8, 1),
    (9, 2),
    (10, 3);
GO

-- Таблиця: Відпустки (Vacations)
CREATE TABLE Vacations (
    Id INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL 
);
GO

INSERT INTO Vacations (DoctorId, StartDate, EndDate) VALUES
    (1, '2024-01-10', '2024-01-20'),
    (2, '2024-02-01', '2024-02-15'),
    (3, '2024-10-10', '2024-10-20'),
    (4, '2024-11-10', '2024-11-20'),
    (5, '2025-11-25', '2025-12-10'),
    (6, '2025-11-20', '2025-12-05'),
    (7, '2025-01-10', '2025-01-20'),
    (8, '2024-11-01', '2024-11-15');
GO
-- Таблиця: Спонсори (Sponsors)
CREATE TABLE Sponsors (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
);
GO

-- Спонсори
INSERT INTO Sponsors (Name) VALUES
    ('Umbrella Corporation'),
    ('Global Health Fund'), 
    ('Medical Innovators');
GO

-- Таблиця: Пожертвування (Donations)
CREATE TABLE Donations (
    Id INT PRIMARY KEY IDENTITY,
    Amount MONEY NOT NULL CHECK (Amount > 0),
    Date DATE NOT NULL DEFAULT GETDATE() CHECK (Date <= GETDATE()),
    DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
    SponsorId INT NOT NULL FOREIGN KEY REFERENCES Sponsors(Id)
);
GO

-- Пожертвування
INSERT INTO Donations (Amount, Date, DepartmentId, SponsorId) VALUES
    (10000, '2024-11-15', 1, 1),
    (5000, '2024-11-10', 2, 2),
    (15234, '2024-10-10', 3, 3);
GO

-- Таблиця: Доктори (Doctors)
-- Оновлена: додано колонку DepartmentId
ALTER TABLE Doctors
    ADD DepartmentId INT;
GO
-- Додаємо зовнішній ключ для DepartmentId
BEGIN
    ALTER TABLE Doctors
    ADD CONSTRAINT FK_Doctors_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id);
END;

UPDATE Doctors
    SET DepartmentId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

-- Таблиця: Палати (Wards)
-- Оновлена: додано колонку DepartmentId
ALTER TABLE Wards
    ADD DepartmentId INT;
GO
-- Додаємо зовнішній ключ для DepartmentId
BEGIN
    ALTER TABLE Wards
    ADD CONSTRAINT FK_Wards_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id);
END;

UPDATE Wards
    SET DepartmentId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

-- Таблиця: (Examinations)
-- Оновлена: додано колонки DoctorId, WardId, DepartmentId, DiseaseId
ALTER TABLE Examinations
    ADD DoctorId INT, WardId INT, DepartmentId INT, DiseaseId INT, ExaminationDate DATE;
GO
-- Додаємо зовнішній ключ для DepartmentId
BEGIN
    ALTER TABLE Examinations
    ADD CONSTRAINT FK_Examinations_Doctors FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
        CONSTRAINT FK_Examinations_Wards FOREIGN KEY (WardId) REFERENCES Wards(Id),
        CONSTRAINT FK_Examinations_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
        CONSTRAINT FK_Examinations_Diseases FOREIGN KEY (DiseaseId) REFERENCES Diseases(Id);
END;

UPDATE Examinations
    SET ExaminationDate = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, DATEADD(YEAR, -1, GETDATE()));
GO
UPDATE Examinations
    SET DoctorId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

UPDATE Examinations
    SET WardId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

UPDATE Examinations
    SET DepartmentId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

UPDATE Examinations
    SET DiseaseId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

-- Таблиця: (Diseases)
-- Оновлена: додано колонки SpecializationId
ALTER TABLE Diseases
    ADD SpecializationId INT;
GO
-- Додаємо зовнішній ключ для SpecializationId
BEGIN
    ALTER TABLE Diseases
    ADD CONSTRAINT FK_Diseases_DoctorsSpecializations FOREIGN KEY (SpecializationId) REFERENCES DoctorsSpecializations(Id);
END;

UPDATE Diseases
    SET SpecializationId = CASE 
                        WHEN Id = 1 THEN 1
                        WHEN Id = 2 THEN 2
                        WHEN Id = 3 THEN 3
                        WHEN Id = 4 THEN 4
                        WHEN Id = 5 THEN 5
                        WHEN Id = 6 THEN 6
                        WHEN Id = 7 THEN 7
                        WHEN Id = 8 THEN 8
                        WHEN Id = 9 THEN 9
                        WHEN Id = 10 THEN 10
                    END
    WHERE Id BETWEEN 1 AND 10;
GO

-- Виконайте запити: 

-- 1. Виведіть повні імена лікарів та їх спеціалізації.
SELECT d.Name + ' ' + d.Surname AS FullName, s.Name AS Specialization
FROM Doctors d
JOIN DoctorsSpecializations ds ON d.Id = ds.DoctorId
JOIN Specializations s ON ds.SpecializationId = s.Id;
GO
-- Об'єднуємо таблиці лікарів та спеціалізацій, щоб отримати повне ім'я лікаря та його спеціалізацію.

-- 2. Виведіть прізвища та зарплати (сума ставки та надбавки) лікарів, які не перебувають у відпустці.
SELECT d.Surname, (d.Salary + d.Bonus) AS TotalSalary
FROM Doctors d
WHERE d.Id NOT IN (SELECT DISTINCT DoctorId FROM Vacations WHERE StartDate <= GETDATE() AND EndDate >= GETDATE());
GO
-- Перевіряємо лікарів, які не мають активних відпусток, та виводимо їхні прізвища та загальну зарплату.

-- 3. Виведіть назви палат, які знаходяться у відділенні «Immunology».
SELECT w.Name AS WardName
FROM Wards w
JOIN Departments d ON w.DepartmentId = d.Id
WHERE d.Name = 'Immunology';
GO
-- Шукаємо палати, які знаходяться в відділенні «Intensive Treatment».

-- 4. Виведіть назви відділень без повторень, які спонсоруються компанією «Umbrella Corporation».
SELECT DISTINCT d.Name AS DepartmentName
FROM Departments d
JOIN Donations don ON d.Id = don.DepartmentId
JOIN Sponsors s ON don.SponsorId = s.Id
WHERE s.Name = 'Umbrella Corporation';
GO
-- Перевіряємо, які відділення отримують фінансування від спонсора «Umbrella Corporation».

-- 5. Виведіть усі пожертвування за останній місяць у вигляді: відділення, спонсор, сума пожертвування, дата пожертвування.
SELECT d.Name AS DepartmentName, s.Name AS SponsorName, don.Amount AS DonationAmount, don.Date AS DonationDate
FROM Donations don
JOIN Departments d ON don.DepartmentId = d.Id
JOIN Sponsors s ON don.SponsorId = s.Id
WHERE don.Date >= DATEADD(MONTH, -1, GETDATE());
GO
-- Виводимо пожертвування за останній місяць, з інформацією про відділення, спонсора, суму та дату.

-- 6. Виведіть прізвища лікарів із зазначенням відділень, в яких вони проводять обстеження. Враховуйте обстеження, які проводяться лише у будні дні.
SELECT d.Surname, dep.Name AS DepartmentName
FROM Doctors d
JOIN Examinations e ON d.Id = e.DoctorId
JOIN Wards w ON e.WardId = w.Id
JOIN Departments dep ON w.DepartmentId = dep.Id
WHERE e.DayOfWeek BETWEEN 1 AND 5;
GO-- Виводимо прізвища лікарів та відділення, де проводяться обстеження лише у будні дні (з понеділка по п’ятницю).


-- 7. Виведіть назви палат і корпуси відділень, в яких проводить обстеження лікар «Isabella	Lee».
SELECT w.Name AS WardName, dep.Building AS BuildingNumber
FROM Doctors d
JOIN Examinations e ON d.Id = e.DoctorId
JOIN Wards w ON e.WardId = w.Id
JOIN Departments dep ON w.DepartmentId = dep.Id
WHERE d.Name = 'Isabella' AND d.Surname = 'Lee';	
GO
-- Знайдемо, в яких палатах і корпусах проводить обстеження лікар «Helen Williams».

-- 8. Виведіть назви відділень, які отримували пожертвування у розмірі понад 10000, із зазначенням їх лікарів.
SELECT d.Name AS DepartmentName, doc.Name + ' ' + doc.Surname AS DoctorName
FROM Donations don
JOIN Departments d ON don.DepartmentId = d.Id
JOIN Doctors doc ON doc.DepartmentId = d.Id
WHERE don.Amount > 10000;
GO
-- Перевіряємо, які відділення отримали пожертвування більше ніж 100000, і лікарів цих відділень.

-- 9. Виведіть назви відділень, в яких лікарі не отримують надбавки.
SELECT d.Name AS DepartmentName
FROM Departments d
JOIN Doctors doc ON doc.DepartmentId = d.Id
WHERE doc.Bonus = 0;
GO-- Виводимо відділення, де лікарі не отримують надбавки.


-- 10. Виведіть назви спеціалізацій, які беруть участь у лікуванні захворювань із ступенем тяжкості вище 3.
SELECT DISTINCT s.Name AS SpecializationName
FROM Specializations s
JOIN DoctorsSpecializations ds ON s.Id = ds.SpecializationId
JOIN Diseases dis ON ds.SpecializationId = dis.SpecializationId
WHERE dis.Severity > 3;
GO
-- Виводимо спеціалізації, які беруть участь у лікуванні захворювань з тяжкістю більше 3.

-- 11. Виведіть назви відділень і назви захворювань, обстеження з яких вони проводили за останні півроку.
SELECT dep.Name AS DepartmentName, dis.Name AS DiseaseName
FROM Examinations e
JOIN Departments dep ON e.DepartmentId = dep.Id
JOIN Diseases dis ON e.DiseaseId = dis.Id
WHERE e.ExaminationDate >= DATEADD(MONTH, -6, GETDATE());
GO-- Виводимо відділення та захворювання, обстеження яких проводилися за останні півроку.


-- 12. Виведіть назви відділень і назви палат, в яких проводилися обстеження із заразних захворювань.
SELECT dis.Name as DiseaseName, dep.Name AS DepartmentName, w.Name AS WardName
FROM Examinations e
JOIN Wards w ON e.WardId = w.Id
JOIN Departments dep ON w.DepartmentId = dep.Id
JOIN Diseases dis ON e.DiseaseId = dis.Id
WHERE dis.Name LIKE '%ia%';
GO
-- Виводимо відділення та палати, де проводяться обстеження з заразних захворювань (назва захворювання містить «Infectious»).
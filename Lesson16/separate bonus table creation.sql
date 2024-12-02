-- Створення separate таблиці для надбавок
CREATE TABLE DocBonus (
    Id INT IDENTITY PRIMARY KEY,                    -- Унікальний ідентифікатор надбавки
    DoctorId INT NOT NULL,                          -- Ідентифікатор лікаря
    BonusAmount MONEY NOT NULL,                     -- Сума надбавки
    Description NVARCHAR(255) UNIQUE NOT NULL,      -- Опис надбавки
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)   -- Зв'язок з таблицею Doctors
);

INSERT INTO DocBonus (DoctorId, BonusAmount, Description)
VALUES
(1, 500, 'Night shifts'),
(2, 700, 'Overtime work'),
(3, 400, 'Specialist bonus'),
(4, 300, 'Risk allowance'),
(5, 600, 'Extra duty');

select * from Doctors
select * from DocBonus

-- Запит для обчислення повної зарплати
-- Вивести прізвища лікарів, чия загальна зарплата перевищує 1500
SELECT d.Surname, (d.Salary + a.BonusAmount) AS TotalSalary
FROM Doctors d
JOIN DocBonus a ON d.Id = a.DoctorId
WHERE (d.Salary + a.BonusAmount) > 1500;
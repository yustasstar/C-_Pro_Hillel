using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Validation.StudentsDb.Models
{
    // Для взаимодействия с MS SQL Server через Entity Framework необходим пакет 
    // Microsoft.EntityFrameworkCore.SqlServer
    // Для создания БД на основе модели необходим пакет Microsoft.EntityFrameworkCore.Tools

    // Entity Framework Core использует подход Code First, при котором необходимо сначала 
    // определить модели и контекст данных, а затем на основе моделей и класса контекста 
    // будет создаваться БД и все ее таблицы.

    public class StudentContext : DbContext
    {
        // Каждое свойство DbSet будет соотноситься с отдельной таблицей в базе данных.
        public DbSet<Student> Students { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
    }

    // Создание БД
    // Tools -> Nuget Package Manager -> Package Manager Console
    // Add-Migration Initial - эта команда добавит в проект файл миграции (Initial), необходимый для создания таблиц в базе данных.
    // Update-Database - эта команда выполнит ранее созданную миграцию, в результате чего на сервере MS SQL Server будет создана 
    // новая база данных, в которой будут определены таблицы, соответствующие моделям и контексту данных.
    public class Student
    {
        // Идентификатор студента
        public int Id { get; set; }

        // Имя студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя студента")]
        public string Name { get; set; }

        // Фамилия студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия студента")]
        public string Surname { get; set; }

        // Возраст студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Возраст")]
        [Range(15, 60, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        // Средний балл
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0.0, 12.0, ErrorMessage = "Недопустимый средний балл")]
        [Display(Name = "Средний балл")]
        public float GPA { get; set; }

        // Электронный адрес
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Students", ErrorMessage = "Email уже используется")]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        /*
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
 
        [Compare("Password",ErrorMessage="Пароли не совпадают")]
        [DataType(DataType.Password)]
        public  virtual string PasswordConfirm { get; set; }
   
        Currency Отображает текст в виде валюты
        DateTime Отображает дату и время
        Date Отображает только дату, без времени
        Time Отображает только время
        Text Отображает однострочный текст
        MultilineText Отображает многострочный текст (элемент textarea)
        Password Отображает символы с использованием маски
        Url  Отображает строку URL
        EmailAddress Отображает электронный адрес
         * */
    }
}

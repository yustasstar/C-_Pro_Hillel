using Microsoft.EntityFrameworkCore;

namespace AspNetCore.NewDb.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }
    }

    public class Student
    {
        // Идентификатор студента
        public int StudentId { get; set; }
        // Имя студента
        public string Name { get; set; }
        // Фамилия студента
        public string Surname { get; set; }
        // Возраст студента
        public int Age { get; set; }
        // Средний балл
        public float GPA { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
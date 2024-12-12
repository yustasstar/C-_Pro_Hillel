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
        // ������������� ��������
        public int StudentId { get; set; }
        // ��� ��������
        public string Name { get; set; }
        // ������� ��������
        public string Surname { get; set; }
        // ������� ��������
        public int Age { get; set; }
        // ������� ����
        public float GPA { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
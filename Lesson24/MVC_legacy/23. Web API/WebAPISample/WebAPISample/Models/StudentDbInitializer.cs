using System.Data.Entity;

namespace WebAPISample.Models
{
    public class StudentDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext db)
        {
            db.Students.Add(new Student { Name = "Иван", Surname = "Иванов", Age = 20, GPA = 10.5f });
            db.Students.Add(new Student { Name = "Сергей", Surname = "Сергеев", Age = 23, GPA = 11.5f });
            db.Students.Add(new Student { Name = "Петр", Surname = "Петров", Age = 25, GPA = 12f });

            base.Seed(db);
        }
    }
}
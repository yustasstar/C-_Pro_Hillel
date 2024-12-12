using System.Data.Entity;

namespace StudentsMVC.Models
{
    // Реализация интерфейса IDatabaseInitializer, который повторно создает и 
    // может повторно заполнить базу данных при первом использовании контекста в домене приложения. 
    // Чтобы заполнить базу данных начальными значениями, необходимо создать производный класс и 
    // переопределить метод Seed.
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
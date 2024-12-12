using System.Data.Entity;

namespace StudentsMVC.Models
{
    // Реализация интерфейса IDatabaseInitializer, который повторно создает и 
    // может повторно заполнить базу данных при первом использовании контекста в домене приложения. 
    // Чтобы заполнить базу данных начальными значениями, необходимо создать производный класс и 
    // переопределить метод Seed.

    /*
       CreateDatabaseIfNotExists: инициализатор, используемый по умолчанию. Он не удаляет автоматически базу данных и данные, 
       а в случае изменения структуры моделей и контекста данных выбрасывает исключение.
       DropCreateDatabaseIfModelChanges: данный инициализатор проверяет на соответствие моделям определения таблиц в базе данных. 
       И если модели не соответствуют определению таблиц, то база данных пересоздается.
       DropCreateDatabaseAlways: этот инициализатор будет всегда пересоздавать базу данных.
   */
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
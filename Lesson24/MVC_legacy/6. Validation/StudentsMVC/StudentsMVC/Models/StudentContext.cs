using System.Data.Entity;

namespace StudentsMVC.Models
{
    // Install-Package EntityFramework -Version 5.0.0
    // Чтобы подключиться к базе данных через Entity Framework, необходим контекст данных. 
    // Контекст данных представляет собой класс, производный от класса DbContext.
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
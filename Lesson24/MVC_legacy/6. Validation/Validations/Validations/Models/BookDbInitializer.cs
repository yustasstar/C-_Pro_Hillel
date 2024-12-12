using System.Data.Entity;

namespace Validations.Models
{
    public class BookDbInitializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "C++", Author = "Страуструп", Year = 2013 });
            base.Seed(db);
        }
    }
}
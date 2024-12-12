using System.Data.Entity;

namespace MvcModels.Models
{
    public class BookDbInitializer : CreateDatabaseIfNotExists<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Year = 1869 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Year = 1862 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Year = 1896 });

            base.Seed(db);
        }
    }
}
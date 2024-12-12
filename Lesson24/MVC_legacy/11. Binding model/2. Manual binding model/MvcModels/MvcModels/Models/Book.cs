using System.Web.Mvc;
using MvcModels.Infrastructure;

namespace MvcModels.Models
{
    [ModelBinder(typeof(BookModelBinder))] // Альтернативный способ регистрации привязчика 
    public class Book
    {
        // ID книги
        public int Id { get; set; }
        // название книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // цена
        public int Year { get; set; }
    }
}
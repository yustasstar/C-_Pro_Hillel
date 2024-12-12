using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Infrastructure
{
    public class BookModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Получаем поставщик значений
            var valueProvider = bindingContext.ValueProvider;

            // получаем данные по одному полю
            ValueProviderResult vprId = valueProvider.GetValue("Id");

            // получаем данные по остальным полям
            string name = (string)valueProvider.GetValue("Name").ConvertTo(typeof(string));
            string author = (string)valueProvider.GetValue("Author").ConvertTo(typeof(string));
            int year = (int)valueProvider.GetValue("Year").ConvertTo(typeof(int));
            Book book = new Book() { Name = name, Author = author, Year = year };

            // если поле Id определено (редактирование)
            if (vprId != null)
            {
                book.Id = (int)vprId.ConvertTo(typeof(int));
            }
            return book;
        }
    }
}
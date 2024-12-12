using System.Web.Mvc;
using System.Web.Routing;
using MvcModels.Infrastructure;
using MvcModels.Models;
using System.Data.Entity;

namespace MvcModels
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new BookDbInitializer());
            // Необходимо зарегистрировать фабрику поставщика значений 
            // В данном случае мы добавляем наш поставщик в конец коллекции ValueProviderFactories.Factories. 
            // Фреймворк просматривает последовательно все фабрики поставщиков значений в порядке регистрации. 
            // Если будет найден соответствующий поставщик, то следующие после него уже не используются.
            ValueProviderFactories.Factories.Add(new BrowserValueProviderFactory());

            // Однако если возникнет необходимость поставить свою фабрику поставщика значений на первое место в списке, то: 
            // ValueProviderFactories.Factories.Insert(0, new BrowserValueProviderFactory());

            ValueProviderFactories.Factories.Insert(
                index: 0,
                item: new CustomValueProviderFactory());

            // Необходимо зарегистрировать привязчик модели
            // Связыватель регистрируется с помощью метода ModelBinders.Binders.Add(), которому передается тип, 
            // поддерживаемый связывателем, и экземпляр класса связывателя
            ModelBinders.Binders.Add(typeof(Book), new BookModelBinder());
            ModelBinders.Binders.Add(typeof(AddressSummary), new AddressSummaryBinder());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

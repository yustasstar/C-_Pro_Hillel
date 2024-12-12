using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class BrowserValueProviderFactory : ValueProviderFactory
    {
        // Чтобы задействовать свой поставщик значений, нам надо определить фабрику поставщика:
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            // данные, передаваемые через параметр ControllerContext, 
            // можно использовать для реагирования на различные виды 
            // запросов путем создания разных поставщиков значений
            return new BrowserValueProvider();
        }
    }
}
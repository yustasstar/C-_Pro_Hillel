using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    // Чтобы зарегистрировать поставщик значений для приложения, понадобится построить класс фабрики, 
    // который будет создавать экземпляры поставщика, когда они окажутся затребованными инфраструктурой ASP.NET MVC Framework. 
    // Класс фабрики должен быть унаследован от абстрактного класса ValueProviderFactory.
    public class CustomValueProviderFactory : ValueProviderFactory
    {
        // Метод GetValueProvider() вызывается, когда связывателю модели необходимо получить значения для процесса привязки.
        public override IValueProvider GetValueProvider(
            ControllerContext controllerContext)
        {
            return new CountryValueProvider();
        }
    }
}
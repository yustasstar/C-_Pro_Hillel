using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Infrastructure
{
    public class AddressSummaryBinder : IModelBinder
    {
        // Инфраструктура ASP.NET MVC Framework вызывает метод BindModel(), 
        // когда ей требуется экземпляр типа модели, которую поддерживает привязчик.
        public object BindModel(ControllerContext controllerContext,
                ModelBindingContext bindingContext)
        {
            AddressSummary model = new AddressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;

            ValueProviderResult result = context.ValueProvider.GetValue(name);
            if (result == null || result.AttemptedValue == "")
            {
                return "<Не указано>";
            }
            else
            {
                return (string)result.AttemptedValue;
            }
        }
    }
}
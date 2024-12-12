using System.Globalization;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country") > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                // В методе GetValue, если ключ совпадает с префиксом, то мы возвращаем объект ValueProviderResult, 
                // в конструктор которого передаем три параметра - первый параметр принимает значение, ассоциируемое с ключом. 
                // Второй параметр используется для отслеживания ошибок, а в третьем параметре передается информация о культуре, 
                // с которой ассоциируется значение
                return new ValueProviderResult("Украина", "Украина",
                    CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}
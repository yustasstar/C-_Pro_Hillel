using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {

         // Процессом можно управлять напрямую. Это обеспечит более явный контроль над тем, 
        // каким образом создаются объекты модели; откуда получаются значения данных и как обрабатываются ошибки разбора данных.
        public ActionResult Address()
        {
            List<AddressSummary> addresses = new List<AddressSummary>();

            // Метод UpdateModel() или TryUpdateModel() принимает в качестве параметра ранее определенный объект модели и 
            // пытается получить значения для его открытых свойств, используя стандартный процесс привязки
            // По умолчанию связыватель просматривает четыре местоположения: 
            // данные формы, данные маршрутизации, строку запроса и загруженные файлы. 
            // Каждое из четырех стандартных местоположений представлено реализацией интерфейса IValueProvider:
            // Источник Request.Form - реализация FormValueProvider
            // Источник RouteData.Values - реализация RouteDataValueProvider
            // Источник Request.QueryString	 - реализация QueryStringValueProvider
            // Источник Request.Files - реализация HttpFileCollectionValueProvider
            // Можно ограничить связыватель поиском данных в единственном местоположении, например, в данных формы
            if (TryUpdateModel(addresses /*, new FormValueProvider(ControllerContext)*/ ))
            {
                // Продолжить обработку обычным образом
            }
            else
            {
                // Отобразить ошибку пользователю
            }
            return View(addresses);
        }

        // Класс FormCollection реализует интерфейс IValueProvider, связыватель модели предоставит объект, 
        // который можно передавать непосредственно методу UpdateModel().
        public ActionResult Address2(FormCollection formData)
        {
            List<AddressSummary> addresses = new List<AddressSummary>();
            // При явном вызове привязки моделей мы сами отвечаем за обработку ошибок ( недопустимые даты или текст вместо числовых значений). 
            // Связыватель модели сообщает об ошибках привязки путем генерации исключения InvalidOperationException. 
            // Когда привязка модели вызывается автоматически, ошибки привязки не сопровождаются исключениями. 
            // Вместо этого нужно проверять результат привязки с помощью свойства ModelState.IsValid.
            try
            {
                UpdateModel(addresses, formData);
            }
            catch (InvalidOperationException exception)
            {
                // Отобразить ошибку пользователю
            }
            return View(addresses);
        }

        public string BrowserInfo(string browser)
        {
            return browser;
        }
    }
}
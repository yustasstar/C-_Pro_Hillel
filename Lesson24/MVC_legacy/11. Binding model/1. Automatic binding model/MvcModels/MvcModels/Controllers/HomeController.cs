using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcModels.Models;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private List<User> UserCollection = new List<User> {
            new User {UserId = 1, FirstName = "Иван", 
                LastName = "Иванов", HomeAddress = new Address{ Country = "Украина", City = "Одесса"} },
            new User {UserId = 2, FirstName = "Петр", 
                LastName = "Петров", HomeAddress = new Address{ Country = "Украина", City = "Киев"} },
            new User {UserId = 3, FirstName = "Сергей", 
                LastName = "Сергеев", HomeAddress = new Address{ Country = "Украина", City = "Львов"} },
            new User {UserId = 4, FirstName = "Василий", 
                LastName = "Васильев", HomeAddress = new Address{ Country = "Украина", City = "Харьков"} }
        };

        // Процесс, с помощью которого сегмент URL (/Home/Index/1) был преобразован в аргумент int метода, 
        // является примером привязки моделей. 
        public ActionResult Index(int? id) 
        {
            // DefaultModelBinder пытается преобразовать строковое значение, 
            // полученное из данных запроса, в тип параметра, 
            // используя класс System.ComponentModel.TypeDescriptor.
            int ident = id ?? 1;
            User user = UserCollection.Single(u => u.UserId == ident);
            return View(user);
        }

        public ActionResult CreateUser()
        {
            return View(new User());
        }

        // После сопоставления запроса с некоторым маршрутом вызываются специальные компоненты - 
        // активаторы действий (action invoker), которые вызывают нужное действие контроллера и 
        // передают в него значения из контекста запроса. А чтобы сопоставить полученные значения 
        // с конкретными параметрами активаторы действий используют привязчики моделей (model binder). 
        // Привязчики моделей и осуществляют собственно привязку.
        // Все привязчики моделей должны реализовать интерфейс IModelBinder:
        /*
         *  public interface IModelBinder
            {
                object BindModel (ControllerContext controllerContext, 
                                    ModelBindingContext bindingContext);
            }
         * */
        // Для каждого отдельного типа может существовать свой привязчик модели. 
        // При просмотре параметров метода действия активатор действий ищет для 
        // каждого типа параметра соответствующий привязчик и вызывает его метод BindModel. 
        // В случае, если соответствующего данному типу привязчика не обнаружится, 
        // то используется привязчик по умолчанию - DefaultModelBinder.

        // По умолчанию этот привязчик модели производит поиск данных, 
        // соответствующих имени привязываемого параметра, в четырех местоположениях:
        // Request.Form - значения, предоставленные пользователем в HTML-элементах <form>
        // RouteData.Values - значения, полученные с использованием маршрутов приложения
        // Request.QueryString - данные, включенные в строку запроса URL
        // Request.Files - файлы, загруженные как часть запроса
        [HttpPost]
        public ActionResult CreateUser(User model)
        {
            // Если параметр метода действия относится к сложному типу 
            // (т.е. к любому типу, который не может быть преобразован с помощью класса System.ComponentModel.TypeDescriptor), 
            // то класс DefaultModelBinder использует рефлексию для получения набора открытых свойств 
            // с последующей привязкой каждого из них по очереди.
            // Для каждого свойства простого типа связыватель пытается найти значение в запросе.
            // Если свойство требует другой сложный тип, процесс повторяется для нового типа. 
            return View("Index", model);
        }

        // Встречаются ситуации, когда сгенерированная HTML-разметка относится к одному типу объекта, 
        // но ее необходимо привязать к другому типу. Это означает, что префиксы, содержащие представление, 
        // не будут соответствовать структуре, которую ожидает связыватель модели, и данные не смогут быть правильно обработаны.
        // Атрибут Bind позволяет сообщить связывателю префикс для поиска
        // Свойство Exclude атрибута Bind позволяет исключать свойства из процесса привязки моделей
        // Свойство Include позволяет указать только те свойства модели, которые должны привязываться; 
        // все прочие свойства будут проигнорированы.

        [HttpPost]
        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress" /*, Exclude = "Country"*/ )] AddressSummary summary)
        {
            return View(summary);
        }

        // Метод действия Names() принимает параметр names типа строкового массива. 
        // Связыватель модели будет искать любые элементы данных под названием names и создаст массив, содержащий эти значения. 
        public ActionResult Names(string[] names)
        {
            // Оператор ?? называется оператором объединения со значением null. 
            // Он возвращает левый операнд, если этот операнд не имеет значение null; 
            // в противном случае возвращается правый операнд.
            names = names ?? new string[0];
            return View(names);
        }
        // Привязка коллекций
        public ActionResult NamesList(List<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        // Когда форма отправляется, стандартный связыватель модели определяет, 
        // что необходимо создать коллекцию объектов AddressSummary, и использует 
        // префиксы индексов массива в атрибутах name для получения значений, 
        // предназначенных для свойств этих объектов. Свойства с префиксом [0] 
        // применяются для первого объекта AddressSumary, свойства с префиксом [1] - 
        // для второго объекта AddressSumary и т.д.
        public ActionResult Address(AddressSummary[] addresses)
        {
            addresses = addresses ?? new AddressSummary[0];
            return View(addresses);
        }

        public ActionResult AddressList(List<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }
    }
}
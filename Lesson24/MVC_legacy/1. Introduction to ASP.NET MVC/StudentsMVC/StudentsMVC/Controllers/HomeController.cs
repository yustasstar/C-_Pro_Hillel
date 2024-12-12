using System.Web.Mvc;
using StudentsMVC.Util;

namespace StudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        // ContentResult: пишет указанный контент напрямую в ответ в виде строки
        // Если в качестве возвращаемого результата тип string, то фреймворк 
        // автоматически создаст объект ContentResult для возвращаемой строки.
        public string Square(int a, int h)
        {
            Response.Write("<h1>Вычисление площади треугольника</h1>");
            double s = a * h / 2;
            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>";
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет, мир!</h2>");
        }

        public ActionResult GetImage()
        {
            string path = "../Images/IMG_20170504_170840.jpg";
            return new ImageResult(path);
        }

        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Images/IMG_20170504_170840.jpg");
            // Тип файла - content-type
            string file_type = "image/jpeg";
            // Имя файла - необязательно
            string file_name = "Капри.jpg";
            return File(file_path, file_type, file_name);
        }

        public ViewResult SomeMethod()
        {
            ViewBag.Name = "Code First";
            ViewData["Head"] = "Entity Framework";
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult Index()
        {
            ViewBag.Name = "ASP.NET MVC";
            ViewData["Head"] = "ASP.NET WebForms";
            ViewBag.Message = "Это вызов частичного представления из обычного";
            return View();
        }

        public RedirectResult RedirectMethod()
        {
            return Redirect("/Home/Index");
        }

        public string Info()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: "
                + url + "</p><p>IP-адрес: " + ip + "</p>";
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return PartialView();
        }

        public ActionResult Country()
        {
            return View();
        }
    }
}

/*
EmptyResult: по сути ничего не делает, отправляет пустой ответ

FileResult: является базовым классом для всех объектов, пишущих бинарный ответ в выходной поток. Предназначен для отправки файлов

FileContentResult: класс, производный от FileResult, пишет в ответ массив байтов

FilePathResult: также производный от FileResult класс, пишет в ответ файл, находящийся по заданному пути

FileStreamResult: класс, производный от FileResult, пишет бинарный поток в выходной ответ

HttpStatusCodeResult: результат действия, который возвращает клиенту определенный статусный код HTTP

HttpUnauthorizedResult: класс, производный от HttpStatusCodeResult. Возвращает клиенту ответ в виде статусного кода HTTP 401, указывая, что пользователь не прошел авторизацию и не имеет прав доступа к запрошенному ресурсу.

HttpNotFoundResult: производный от HttpStatusCodeResult. Возвращает клиенту ответ в виде статусного кода HTTP 404, указывая, что запрошенный ресурс не найден

JavaScriptResult: возвращает в ответ в качестве содержимого код JavaScript

JsonResult: возвращает в качестве ответа объект или набор объектов в формате JSON

PartialViewResult: производит рендеринг частичного представления в выходной поток

RedirectResult: перенаправляет пользователя по другому адресу URL, возвращая статусный код 302 для временной переадресации или код 301 для постоянной переадресации зависимости от того, установлен ли флаг Permanent.

RedirectToRouteResult: класс работает подобно RedirectResult, но перенаправляет пользователя по определенному адресу URL, указанному через параметры маршрута

ViewResult: производит рендеринг представления и отправляет результаты рендеринга в виде html-страницы клиенту
*/
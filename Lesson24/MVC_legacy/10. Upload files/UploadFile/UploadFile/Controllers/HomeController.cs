using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            /*
             * параметр IEnumerable<HttpPostedFileBase> fileUpload представляет перечисление файлов, 
             * которые были отправлены пользователем. Важно, что имя fileUpload совпадает со значением 
             * атрибута name элементов формы, в том числе, с теми которые содержат индексаторы [№]. 
             * Именно наличие индексаторов позволяет MVC автоматически присваивать в параметр перечисление.
             */
            int count = 0;
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                string filename = Path.GetFileName(file.FileName);
                string tempfolder = Server.MapPath("~/Images");
                if (filename != null)
                {
                    file.SaveAs(Path.Combine(tempfolder, filename));
                    count++;
                }
            }
            ViewBag.Text = "Количество загруженных файлов: " + count;
            return View();
        }
    }
}

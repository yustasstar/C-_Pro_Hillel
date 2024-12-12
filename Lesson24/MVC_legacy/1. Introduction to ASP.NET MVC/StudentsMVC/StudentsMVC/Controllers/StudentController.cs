using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StudentsMVC.Models;
using System.Threading.Tasks;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        StudentContext sc = new StudentContext();

        public ActionResult Index()
        {
            // получаем из базы данных всю информацию о студентах
            var allStudents = sc.Students.ToList<Student>();
            // Создаем объект Students и передаем в него всю информацию
            ViewBag.Students = allStudents;
            return View();
        }

        // асинхронный метод
        public async Task<ActionResult> StudentList()
        {
            IEnumerable<Student> students = await Task.Run(() => sc.Students);
            ViewBag.Students = students;
            return View("Index");
        }
    }
}

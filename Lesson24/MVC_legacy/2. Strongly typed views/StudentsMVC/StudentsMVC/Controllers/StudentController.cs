using System.Linq;
using System.Web.Mvc;
using StudentsMVC.Models;


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
            return View(allStudents);
        }
    }
}

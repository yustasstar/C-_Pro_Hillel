using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class ValuesController: ApiController
    {
        StudentContext db = new StudentContext();

        // GET api/values
        public IEnumerable<Student> GetStudents()
        {
            IEnumerable<Student> list = db.Students;
            return list;
        }

        // GET api/values/5
        public Student GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            return student;
        }

        // POST api/values
        [HttpPost]
        public void CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditStudent(int id, Student student)
        {
            if (id == student.Id)
            {
                db.Entry(student).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}

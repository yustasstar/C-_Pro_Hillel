using WebApiWithAdoNetDemo.Models;

namespace WebApiWithAdoNetDemo.Common
{
    public class SqlCrudService
    {
        private readonly string _connectionString;
        SqlDataAccessService _sqlDataAccessService = new SqlDataAccessService();

        public SqlCrudService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAllStudents()
        {
            string sqlString = "SELECT * FROM Student ORDER BY Id DESC";

            return _sqlDataAccessService.LoadData(sqlString, _connectionString);
        }

        public List<Student> PostStudent(Student student)
        {
            string sqlProcedure = "InsertNewStudent";

            return _sqlDataAccessService.PostData(sqlProcedure, _connectionString, student);
        }

        // Implement methods:
        // - GetById
        // - Update
        // - Delete
    }
}

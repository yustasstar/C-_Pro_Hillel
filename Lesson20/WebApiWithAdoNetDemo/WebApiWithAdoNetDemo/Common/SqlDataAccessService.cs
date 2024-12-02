using System.Data.SqlClient;
using WebApiWithAdoNetDemo.Models;

namespace WebApiWithAdoNetDemo.Common
{
    public class SqlDataAccessService
    {
        public List<Student> LoadData(string sqlQuery, string connectionString)
        {
            var students = new List<Student>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sqlQuery, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = Convert.ToString(reader["UserName"]),
                    Email = Convert.ToString(reader["Email"]),
                    Phone = Convert.ToString(reader["Phone"])
                });
            }

            return students;
        }

        public List<Student> PostData(string sqlQuery, string connectionString, Student newStudent)
        {
            var students = new List<Student>();
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sqlQuery, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", newStudent.UserName);
            command.Parameters.AddWithValue("@Email", newStudent.Email);
            command.Parameters.AddWithValue("@Phone", newStudent.Phone);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserName = Convert.ToString(reader["UserName"]),
                    Email = Convert.ToString(reader["Email"]),
                    Phone = Convert.ToString(reader["Phone"])
                });
            }

            return students;
        }

        // Implement methods:
        // - GetById
        // - Update
        // - Delete
    }
}

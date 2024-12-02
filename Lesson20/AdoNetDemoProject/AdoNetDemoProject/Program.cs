// 1. Install nuget package: Microsoft.Data.SqlClient
// 2. Run "DB_Initial.sql"

using Microsoft.Data.SqlClient;

namespace AdoNetDemoProject
{
    public class AdoNetDemo
    {
        static void Main()
        {
            var connection = CreateConnection();
            try
            {
                connection.Open();
                try
                {
                    while (true)
                    {
                        Console.WriteLine(
                            "\n1. Get All Records" +
                            "\n2. Insert new record" +
                            "\n3. Update existing record" +
                            "\n4. Delete record" +
                            "\n5. Exit");
                        int userSelect = Convert.ToInt16(Console.ReadLine());

                        switch (userSelect)
                        {
                            case 1:
                                Console.WriteLine("Current data: ");
                                GetData(connection);
                                break;
                            case 2:
                                Console.WriteLine("Inserting new records...");
                                var newStudents = new List<Student>
                                {
                                    new Student
                                    {
                                        UserName = "Vasya",
                                        Email = "vasya@gmail.com",
                                        Phone = "+380123456789"
                                    },
                                    new Student
                                    {
                                        UserName = "Petya",
                                        Phone = "+380987654321"
                                    },
                                    new Student
                                    {
                                        UserName = "Anton",
                                        Email = "anton@gmail.com",
                                        Phone = "+380654987321"
                                    }
                                };

                                foreach (var student in newStudents)
                                {
                                    InsertData(connection, student);
                                }
                                break;
                            case 3:
                                Console.WriteLine("Updating existing record...");
                                UpdatetData(
                                    connection, new Student
                                    {
                                        UserName = "Test",
                                        Email = "anton@gmail.com",
                                        Phone = "+380654987321"
                                    },
                                    6);
                                break;
                            case 4:
                                Console.WriteLine("Deleting record...");
                                DeleteData(connection, 1);
                                break;
                            case 5:
                                Console.WriteLine("Exit...");
                                return;
                            default:
                                Console.WriteLine("Incorrect input!");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        static SqlConnection CreateConnection()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdoNetDemo;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            var sqlConnection = new SqlConnection(connectionString);
            Console.WriteLine("Connection established.");
            return sqlConnection;
        }

        static void InsertData(SqlConnection sqlConnection, Student student)
        {
            string sql = "insert into Student VALUES(@username, @email, @phone);";
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@username", student.UserName);
            sqlCommand.Parameters.AddWithValue("@email", student.Email);
            sqlCommand.Parameters.AddWithValue("@phone", student.Phone);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Data inserted successfully.");
        }

        static void UpdatetData(SqlConnection sqlConnection, Student student, int studentId)
        {
            if (IsRecordExists(sqlConnection, studentId))
            {
                string sql = "update Student set UserName=@username, Email=@email, Phone=@phone where Id=@id;";
                var sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", studentId);
                sqlCommand.Parameters.AddWithValue("@username", student.UserName);
                sqlCommand.Parameters.AddWithValue("@email", student.Email);
                sqlCommand.Parameters.AddWithValue("@phone", student.Phone);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data updated successfully.");
            }
            else
            {
                Console.WriteLine("Record not found!");
            }
        }

        static void DeleteData(SqlConnection sqlConnection, int studentId)
        {
            if (IsRecordExists(sqlConnection, studentId))
            {
                string sql = "delete from Student where Id=@id;";
                var sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", studentId);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record not found!");
            }
        }

        static bool IsRecordExists(SqlConnection sqlConnection, int studentId)
        {
            string sql = "SELECT * from Student where Id=@id;";
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", studentId);
            var sqlDataReader = sqlCommand.ExecuteReader();
            var isExists = sqlDataReader.Read() ? true : false;
            sqlDataReader.Close();
            return isExists;
        }

        static void GetData(SqlConnection sqlConnection)
        {
            string sql = "SELECT * from Student;";
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader["Id"]);
                Console.WriteLine(sqlDataReader["UserName"]);
                Console.WriteLine(sqlDataReader["Email"]);
                Console.WriteLine(sqlDataReader["Phone"]);
            }

            sqlDataReader.Close();
        }
    }
}


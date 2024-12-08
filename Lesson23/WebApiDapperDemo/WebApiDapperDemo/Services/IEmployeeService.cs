using WebApiDapperDemo.Models;

namespace WebApiDapperDemo.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(Employee employee);
        Task</*List*/IEnumerable<Employee>> GetEmployeeList();
        Task<Employee> GetEmployee(int id);
        Task<int> UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int key);
    }
}

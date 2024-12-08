using WebApiDapperDemo.Models;

namespace WebApiDapperDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            return await _dbService.EditData("INSERT INTO EMPLOYEE (firstname, age, address, phone) VALUES (@FirstName, @Age, @Address, @Phone)", employee);
        }

        public async Task<int> DeleteEmployee(int key)
        {
            return await _dbService.EditData("DELETE FROM EMPLOYEE WHERE id=@Id", new { Id = key });
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbService.GetAsync<Employee>("SELECT * FROM EMPLOYEE WHERE id=@Id", new { id });
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await _dbService.GetAll<Employee>("SELECT * FROM EMPLOYEE", new { });
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            return await _dbService.EditData("UPDATE EMPLOYEE SET firstname=@FirstName, age=@Age, address=@Address, phone=@Phone WHERE id=@Id", employee);
        }
    }
}

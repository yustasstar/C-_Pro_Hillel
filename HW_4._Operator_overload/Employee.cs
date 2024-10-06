
namespace HW_4._Operator_overload
{
    public class Employee
    {
        private string _name;
        private decimal _salary;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public static Employee operator +(Employee employee, decimal amount)
        {
            employee.Salary += amount;
            Console.WriteLine($"New {employee.Name} salary is: {employee.Salary:C}");
            return employee;
        }
        public static Employee operator -(Employee employee, decimal amount)
        {
            employee.Salary -= amount;
            Console.WriteLine($"New {employee.Name} salary is: {employee.Salary:C}");
            return employee;
        }
        public static bool operator ==(Employee emp1, Employee emp2) => emp1.Salary == emp2.Salary;
        public static bool operator !=(Employee emp1, Employee emp2) => !(emp1 == emp2);
        public static bool operator >(Employee emp1, Employee emp2) => emp1.Salary > emp2.Salary;
        public static bool operator <(Employee emp1, Employee emp2) => emp1.Salary < emp2.Salary;
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Employee)
                return false;

            Employee other = (Employee)obj;
            return Salary == other.Salary;
        }
        public override int GetHashCode() => HashCode.Combine(Name, Salary); 
        public void PrintEmployeeInfo() => Console.WriteLine($"{Name} - Salary: {Salary:C}");


    }
}

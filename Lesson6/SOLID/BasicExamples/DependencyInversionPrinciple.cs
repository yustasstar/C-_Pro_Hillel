namespace Lesson6.SOLID.BasicExamples
{
    // Problem:

    // Высокоуровневые модули напрямую зависят от низкоуровневых модулей, что усложняет изменение и тестирование кода.

    // EmployeeService зависит от конкретной реализации класса Database.
    // Если нужно будет изменить способ хранения данных, придется изменить сам класс EmployeeService.

    public class Database
    {
        public void Save()
        {
            // Логика сохранения данных
        }
    }

    public class EmployeeService
    {
        private Database _database;

        public EmployeeService()
        {
            _database = new Database();
        }

        public void SaveEmployee()
        {
            _database.Save();
        }
    }

    // Solution:

    // Используем абстракцию для работы с хранилищем данных и внедрение зависимостей через интерфейсы.

    public interface IRepository
    {
        void Save();
    }

    public class DatabaseV2 : IRepository
    {
        public void Save()
        {
            // Логика сохранения в БД
        }
    }

    public class EmployeeServiceV2
    {
        private IRepository _repository;

        public EmployeeServiceV2(IRepository repository)
        {
            _repository = repository;
        }

        public void SaveEmployee()
        {
            _repository.Save();
        }
    }

    // Теперь класс EmployeeService не зависит от конкретной реализации Database,
    // а работает через интерфейс IRepository.
    // Это упрощает замену зависимостей и тестирование.
}

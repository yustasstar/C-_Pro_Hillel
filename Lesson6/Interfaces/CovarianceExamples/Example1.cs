// Ковариантность позволяет использовать более специфичные типы (наследников) вместо базового типа.
// Это может быть полезно, когда мы хотим вернуть объект в иерархии классов и быть уверенными,
// что он будет корректно воспринят как базовый тип.

namespace Lesson6.Interfaces.CovarianceExamples
{
    // Problem:

    // У нас есть интерфейс IUserGetter<T>, который возвращает объекты типа T.
    // Мы пытаемся передать IUserGetter<Admin> в место, где ожидается IUserGetter<User>,
    // но возникает ошибка компиляции, так как наш кастомный интерфейс не поддерживает ковариантность.

    // Базовый класс
    public class User
    {
        public string Name { get; set; }
    }

    // Производный класс
    public class Admin : User
    {
        public int AdminLevel { get; set; }
    }

    // Интерфейс для получения пользователей
    public interface IUserGetter<T>
    {
        T GetUser();
    }

    // Реализация для админов
    public class AdminGetter : IUserGetter<Admin>
    {
        public Admin GetUser()
        {
            return new Admin { Name = "AdminUser", AdminLevel = 1 };
        }
    }

    public class UserService
    {
        // Ожидаем IUserGetter<User>
        public void PrintUser(IUserGetter<User> userGetter)
        {
            var user = userGetter.GetUser();
            Console.WriteLine($"User: {user.Name}");
        }
    }

    // Solution: 

    // Мы можем решить эту проблему, сделав наш интерфейс ковариантным,
    // используя ключевое слово out для типа T в интерфейсе.
    // Это означает, что T будет использоваться только в качестве возвращаемого значения (выходного типа),
    // и можно будет передавать более конкретные типы (наследников) в место, где ожидаются более общие типы.

    // Интерфейс для получения пользователей с ковариантностью
    public interface IUserGetterV2<out T>
    {
        T GetUser();
    }

    // Реализация для админов
    public class AdminGetterV2 : IUserGetterV2<Admin>
    {
        public Admin GetUser()
        {
            return new Admin { Name = "AdminUser", AdminLevel = 1 };
        }
    }

    public class UserServiceV2
    {
        // Ожидаем IUserGetter<User>
        public void PrintUser(IUserGetterV2<User> userGetter)
        {
            var user = userGetter.GetUser();
            Console.WriteLine($"User: {user.Name}");
        }
    }

    public static class TestExample1
    {
        public static void Example()
        {
            IUserGetter<Admin> adminGetter = new AdminGetter();
            UserService userService = new UserService();

            // Ошибка компиляции, так как IUserGetter<Admin> не может быть приведен к IUserGetter<User>
            // userService.PrintUser(adminGetter);  // Ошибка компиляции

            // Проблема в том, что интерфейс IUserGetter<T> не является ковариантным.
            // Компилятор не позволяет передать IUserGetter<Admin> туда, где ожидается IUserGetter<User>,
            // потому что неизвестно, может ли код корректно работать с производным типом.

            /////
            IUserGetterV2<Admin> adminGetterV2 = new AdminGetterV2();
            UserServiceV2 userServiceV2 = new UserServiceV2();

            // Теперь это работает, так как IUserGetter<Admin> может быть приведен к IUserGetter<User>
            userServiceV2.PrintUser(adminGetterV2);  // Работает
        }
    }

}

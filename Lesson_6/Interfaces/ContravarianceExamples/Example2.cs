// Контрвариантность позволяет использовать более общий тип вместо конкретного.
// Это может быть полезно, когда мы принимаем параметры и можем работать с их более общими типами.

namespace Lesson6.Interfaces.ContravarianceExamples
{
    // Теперь рассмотрим обратную ситуацию с интерфейсом, который принимает объекты типа T.
    // Это интерфейс IUserSaver<T>, который сохраняет пользователя.
    // Если мы пытаемся передать IUserSaver<User> в метод, который ожидает IUserSaver<Admin>,
    // снова возникает ошибка компиляции.

    // Интерфейс для сохранения пользователей
    public interface IUserSaver<T>
    {
        void SaveUser(T user);
    }

    // Базовый класс
    public class User
    {
        public string Name { get; set; }
    }

    // Реализация для пользователей
    public class UserSaver : IUserSaver<User>
    {
        public void SaveUser(User user)
        {
            Console.WriteLine($"Saving user: {user.Name}");
        }
    }

    // Производный класс
    public class Admin : User
    {
        public int AdminLevel { get; set; }
    }

    public class AdminService
    {
        // Ожидаем IUserSaver<Admin>
        public void SaveAdmin(IUserSaver<Admin> saver)
        {
            saver.SaveUser(new Admin { Name = "AdminUser", AdminLevel = 1 });
        }
    }

    // Solution:

    // Для решения этой проблемы мы можем использовать ключевое слово in для типа T в интерфейсе,
    // чтобы сделать его контрвариантным. Это означает, что можно передавать более общий
    // тип (например, User) туда, где ожидается более конкретный тип (например, Admin).

    // Интерфейс для сохранения пользователей с контрвариантностью
    public interface IUserSaverV2<in T>
    {
        void SaveUser(T user);
    }

    // Реализация для пользователей
    public class UserSaverV2 : IUserSaverV2<User>
    {
        public void SaveUser(User user)
        {
            Console.WriteLine($"Saving user: {user.Name}");
        }
    }

    public class AdminServiceV2
    {
        // Ожидаем IUserSaverV2<Admin>
        public void SaveAdmin(IUserSaverV2<Admin> saver)
        {
            saver.SaveUser(new Admin { Name = "AdminUser", AdminLevel = 1 });
        }
    }

    public static class Example2
    {
        public static void Example()
        {
            IUserSaver<User> userSaver = new UserSaver();
            AdminService adminService = new AdminService();

            // Ошибка компиляции, так как IUserSaver<User> не может быть приведен к IUserSaver<Admin>
            // adminService.SaveAdmin(userSaver);  // Ошибка компиляции

            // Проблема в том, что интерфейс IUserSaver<T> не является контрвариантным.
            // Компилятор не позволяет передать IUserSaver<User> туда, где ожидается IUserSaver<Admin>,
            // потому что неизвестно, будет ли это безопасно — мы можем случайно передать User,
            // а не Admin, что нарушает типобезопасность.

            //////
            IUserSaverV2<User> userSaverV2 = new UserSaverV2();
            AdminServiceV2 adminServiceV2 = new AdminServiceV2();

            // Теперь это работает, так как IUserSaver<User> может быть приведен к IUserSaver<Admin>
            adminServiceV2.SaveAdmin(userSaverV2);  // Работает
        }
    }
}

// Ковариантность (out) полезна, когда возвращаются объекты, и позволяет использовать более специфичные типы.
// Контрвариантность(in) полезна, когда объекты передаются как параметры, и позволяет использовать более общие типы.
// Ковариантность и контрвариантность помогают сделать код более гибким и типобезопасным, особенно при работе с обобщенными интерфейсами.

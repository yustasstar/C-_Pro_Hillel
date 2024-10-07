namespace Lesson4
{
    // Методи розширення (extension methods) дозволяють додавати нові методи вже існуючі типи без створення нового похідного класу.
    // Ця функціональність буває особливо корисною, коли нам хочеться додати до певного типу новий метод,
    // але сам тип (клас чи структуру) ми змінити не можемо, оскільки ми не маємо доступу до вихідного коду.
    // Або якщо ми не можемо використати стандартний механізм успадкування, наприклад, якщо класи визначені з модифікатором sealed.

    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }

    public static class Example2
    {
        public static void StartTest()
        {
            string s = "Hello world";
            char c = 'l';
            int i = s.CharCount(c);
            Console.WriteLine(i);
        }
    }
}

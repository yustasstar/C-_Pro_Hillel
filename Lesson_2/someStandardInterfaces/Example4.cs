namespace Lesson_2.someStandardInterfaces
{
    // ICloneable под капотом
    //public interface ICloneable
    //{
    //    object Clone();
    //}

    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public object Clone()
        {
            return new Person(Name, Age);
        }

        // Для скорочення коду копіювання ми можемо використовувати спеціальний метод MemberwiseClone(), який повертає копію об'єкта
        //public object Clone()
        //{
        //    // Цей метод реалізує поверхневе (неглибоке) копіювання. Однак цього копіювання може бути недостатньо.
        //    return MemberwiseClone();
        //}

        // Наприклад, нехай клас Person містить посилання на об'єкт класу Company:
        //public Company Work { get; set; }

        //public Person(string name, int age, Company company)
        //{
        //    Name = name;
        //    Age = age;
        //    Work = company;
        //}

        //public object Clone() => new Person(Name, Age, new Company(Work.Name));
    }

    class Company
    {
        public string Name { get; set; }
        public Company(string name) => Name = name;
    }

    public static class Example4
    {
        public static void StartTest()
        {
            // В даному випадку об'єкти tom і bob будуть вказувати на той самий об'єкт у пам'яті,
            // тому зміни властивостей для змінної bob торкнуться також і змінну tom.

            // Щоб змінна bob вказувала на новий об'єкт, але при цьому мала значення зі змінної tom,
            // ми можемо застосувати клонування за допомогою реалізації ICloneable інтерфейсу
            var tom = new Person("Tom", 23);
            var bob = tom;
            bob.Name = "Bob";
            Console.WriteLine(tom.Name); // Bob

            // тепер все нормально копіюється, зміни у властивостях змінної bob не позначаються на властивостях із змінної tom.
            //var tom = new Person("Tom", 23);
            //var bob = (Person)tom.Clone();
            //bob.Name = "Bob";
            //Console.WriteLine(tom.Name); // Tom

            //
            //var tom = new Person("Tom", 23, new Company("Microsoft"));
            //var bob = (Person)tom.Clone();
            //bob.Work.Name = "Google";
            //Console.WriteLine(tom.Work.Name); // Google - а должно быть Microsoft

            // Поверхневе копіювання працює тільки для властивостей, що становлять примітивні типи, але не для складних об'єктів.
            // І в цьому випадку треба застосовувати глибоке копіювання
        }
    }
}

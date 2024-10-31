// Всі класи в .NET, навіть ті, які ми самі створюємо, а також базові типи, такі як System.Int32, є похідними від класу Object.
// Навіть якщо ми не вказуємо клас Object як базовий, за умовчанням неявно клас Object все одно стоїть на вершині ієрархії спадкування.
// Тому всі типи та класи можуть реалізувати ті методи, які визначені у класі System.Object.

namespace ThirdLesson.objAndMethods
{
    public class Clock
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        // Метод ToString служить отримання рядкового представлення даного об'єкта.
        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }

    public class Person
    {
        public string Name { get; set; } = "";

        public override string? ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }

        // Метод GetHashCode дозволяє повернути деяке числове значення, яке буде відповідати даному об'єкту або його хеш-коду.
        // За цим числом, наприклад, можна порівнювати об'єкти. Можна визначати різні алгоритми генерації подібного числа
        // або взяти реалізацію базового типу

        // В даному випадку метод GetHashCode повертає хеш-код значення властивості Name.
        // Тобто два об'єкти Person, які мають те саме ім'я, повертатимуть один і той же хеш-код.
        // Проте насправді алгоритм може бути різним.
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        // разом із методом Equals слід реалізувати метод GetHashCode !!!
        public override bool Equals(object? obj)
        {
            // якщо параметр методу представляє тип Person
            // то повертаємо true, якщо імена збігаються
            if (obj is Person person)
                return Name == person.Name;
            return false;
        }

        // Метод Equals приймає як параметр об'єкт будь-якого типу, який потім приводити до поточного класу - класу Person.

        // Якщо переданий об'єкт є типом Person, то повертаємо результат порівняння імен
        // двох об'єктів Person.Якщо об'єкт представляє інший тип, то повертається false.

        // В даному випадку для прикладу застосовується досить простий алгоритм порівняння,
        // проте при необхідності реалізацію методу можна зробити складнішою, наприклад,
        // порівнювати за декількома властивостями за їх наявності.

        // Слід зазначити, що з методом Equals слід реалізувати метод GetHashCode.

        // Якщо порівнювати два складні об'єкти, то краще використовувати метод Equals, а не стандартну операцію ==
    }

    public static class Example1
    {
        public static void StartTest()
        {
            Clock clock = new Clock { Hours = 15, Minutes = 34, Seconds = 53 };
            Console.WriteLine(clock.ToString()); // виведе 15:34:53

            Person tom = new Person { Name = "Tom" };
            Console.WriteLine(tom.ToString()); // Tom

            Person undefined = new Person();
            Console.WriteLine(undefined.ToString()); // Person

            Console.WriteLine(tom.GetHashCode());
            Console.WriteLine(tom.Name.GetHashCode());

            // Метод GetType дозволяє отримати тип об'єкта:
            Console.WriteLine(tom.GetType());    // Цей спосіб повертає об'єкт Type, тобто тип об'єкта.

            // За допомогою ключового слова typeof ми отримуємо тип класу і порівнюємо його з типом об'єкта.
            // І якщо цей об'єкт є типом Person, то виконуємо певні дії.
            object person = new Person { Name = "Tom" };

            if (person.GetType() == typeof(Person))
                Console.WriteLine("It's Person class");

            // Причому оскільки клас Object є базовим типом всім класів,
            // ми можемо змінної типу object привласнити об'єкт будь-якого типу.
            // Однак для цієї змінної метод GetType все одно поверне той тип, на який посилається змінна.
            // Тобто в цьому випадку об'єкт типу Person.

            // Варто зазначити, що перевірку типу у прикладі вище можна скоротити за допомогою оператора is:
            if (person is Person)
                Console.WriteLine("It's Person class");

            // На відміну від методів ToString, Equals, GetHashCode, метод GetType() не перевизначається.

            // https://www.geeksforgeeks.org/is-vs-as-operator-keyword-in-c-sharp/
            // https://www.c-sharpcorner.com/blogs/is-and-as-keyword-difference-in-c-sharp

            var person1 = new Person { Name = "Tom" };
            var person2 = new Person { Name = "Bob" };
            var person3 = new Person { Name = "Tom" };

            Console.WriteLine(person1.Equals(person2));    // false
            Console.WriteLine(person1.Equals(person3));    // true
        }
    }
}

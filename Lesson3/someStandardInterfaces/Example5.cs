namespace ThirdLesson.someStandardInterfacesV2
{
    // под капотом IComparable
    // public interface IComparable
    // {
    //    int CompareTo(object? o);
    // }

    // Метод CompareTo призначений для порівняння поточного об'єкта з об'єктом, який передається як параметр об'єкта? o.
    // На виході він повертає ціле число, яке може мати одне із трьох значень:
    // Менше нуля.Отже, поточний об'єкт повинен перебувати перед об'єктом, який передається як параметр
    // дорівнює нулю. Отже, обидва об'єкти рівні
    // Більше нуля. Отже, поточний об'єкт повинен перебувати після об'єкта, що передається як параметр

    // class Person : IComparable 
    class Person : IComparable<Person>
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        //public int CompareTo(object? o)
        //{
        //    if (o is Person person) return Name.CompareTo(person.Name);
        //    else throw new ArgumentException("Incorrect parameter value");
        //}

        public int CompareTo(Person? person)
        {
            if (person is null) throw new ArgumentException("Incorrect parameter value");
            return Age - person.Age;
        }
    }

    public static class Example5
    {
        public static void StartTest()
        {
            // тут под капотом работает компаратор
            int[] numbers = new int[] { 97, 45, 32, 65, 83, 23, 15 };
            Array.Sort(numbers);
            foreach (int n in numbers)
                Console.WriteLine(n);
            // 15 23 32 45 65 83 97

            //
            var tom = new Person("Tom", 37);
            var bob = new Person("Bob", 41);
            var sam = new Person("Sam", 25);

            Person[] people = { tom, bob, sam };
            Array.Sort(people);

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

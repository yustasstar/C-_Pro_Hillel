using System.Collections;

namespace ThirdLesson.someStandardInterfaces
{
    // Интерфейсы IEnumerable и IEnumerator
    // Основною для більшості колекцій є реалізація інтерфейсів IEnumerable та IEnumerator.
    // Завдяки такій реалізації ми можемо перебирати об'єкти в циклі.
    // Колекція, що перебирається, повинна реалізувати інтерфейс IEnumerable.
    // Інтерфейс IEnumerable має метод, який повертає посилання на інший інтерфейс - перечислювач

    //public interface IEnumerable
    //{
    //    IEnumerator GetEnumerator();
    //}

    // А інтерфейс IEnumerator визначає функціонал для перебору внутрішніх об'єктів у контейнері

    //public interface IEnumerator
    //{
    //    bool MoveNext(); // переміщення однією позицію вперед у контейнері елементів
    //    object Current { get; } // поточний елемент у контейнері
    //    void Reset(); // Переміщення на початок контейнера
    //}

    //Метод MoveNext() переміщує покажчик на поточний елемент наступну позицію в послідовності.
    //Якщо послідовність ще закінчилася, то повертає true. Якщо послідовність закінчилася, то повертається false.

    //Властивість Current повертає об'єкт у послідовності, який вказує покажчик.

    //Метод Reset() скидає покажчик позиції початкове положення.

    class WeekEnumerator : IEnumerator
    {
        string[] days;
        int position = -1;
        public WeekEnumerator(string[] days) => this.days = days;
        public object Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new ArgumentException();
                return days[position];
            }
        }
        public bool MoveNext()
        {
            if (position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
    }
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
        public IEnumerator GetEnumerator() => new WeekEnumerator(days);
    }

    public static class Example6
    {
        public static IEnumerable<int> GetData()
        {
            Console.WriteLine("1");
            yield return 1;

            Console.WriteLine("2");
            yield return 2;

            Console.WriteLine("3");
            yield return 3;
        }

        public static IEnumerable<string> GetHellos()
        {
            while (true)
            {
                yield return "hello";
            }
        }

        public static void Start()
        {
            foreach (var val in GetHellos())
            {
                Console.WriteLine(val);
            }
        }

        public static void StartTest()
        {
            // Start();

            // Console.WriteLine(GetData());

            //foreach (var item in GetData())
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerator numberEnumerator = GetData().GetEnumerator();
            //Console.WriteLine(numberEnumerator.MoveNext());
            //Console.WriteLine(numberEnumerator.Current);

            //Console.WriteLine(numberEnumerator.MoveNext());
            //Console.WriteLine(numberEnumerator.Current);

            //Console.WriteLine(numberEnumerator.MoveNext());
            //Console.WriteLine(numberEnumerator.Current);

            //Console.WriteLine(numberEnumerator.MoveNext());
            //Console.WriteLine(numberEnumerator.Current);

            // numberEnumerator.Reset();

            //Console.WriteLine(numberEnumerator.MoveNext());
            //Console.WriteLine(numberEnumerator.Current);


            // без використання циклу foreach переберемо масив за допомогою інтерфейсу IEnumerator
            //string[] people = { "Tom", "Sam", "Bob" };

            //IEnumerator peopleEnumerator = people.GetEnumerator(); // отримуємо IEnumerator
            //while (peopleEnumerator.MoveNext()) // поки не буде повернуто false
            //{
            //    string item = (string)peopleEnumerator.Current; // Отримуємо елемент на поточній позиції
            //    Console.WriteLine(item);
            //}
            //peopleEnumerator.Reset(); // скидаємо покажчик на початок масиву

            ////
            //Week week = new Week();
            //foreach (var day in week)
            //{
            //    Console.WriteLine(day);
            //}
        }
    }
}

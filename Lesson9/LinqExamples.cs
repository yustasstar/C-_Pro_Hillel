///////////////////////////////////////////////////////////////////////
//// LINQ(Language - Integrated Query) представляє просту та зручну мову запитів до джерела даних.
//// Як джерело даних може бути об'єкт, що реалізує інтерфейс IEnumerable (наприклад, стандартні колекції, масиви),
//// набір даних DataSet, документ XML. Але незалежно від типу джерела LINQ дозволяє застосувати до всіх той самий
//// підхід для вибірки даних.

//// Існує кілька різновидів LINQ:

//// LINQ to Objects:       застосовується для роботи з масивами та колекціями
//// LINQ to Entities:      використовується при зверненні до баз даних через технологію Entity Framework
//// LINQ to XML:           застосовується під час роботи з файлами XML
//// LINQ to DataSet:       застосовується під час роботи з об'єктом DataSet
//// Parallel LINQ (PLINQ): використовується для виконання паралельних запитів

//// У цьому розділі мова йтиме насамперед про LINQ to Objects, але в наступних матеріалах також торкнуться й інших різновидів LINQ.
//// Основна частина функціональності LINQ зосереджена у просторі імен System.LINQ.
//// У проектах під .NET 6 цей простір імен підключається за замовчуванням.
//// У чому зручність LINQ? Подивимося на найпростіший приклад.

//// Виберемо з масиву рядки, які починаються на певну літеру, наприклад, літеру "T", та відсортуємо отриманий список:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//// создаем новый список для результатов
//var selectedPeople = new List<string>();
//// проходим по массиву
//foreach (string person in people)
//{
//    // если строка начинается на букву T, добавляем в список
//    if (person.ToUpper().StartsWith("T"))
//        selectedPeople.Add(person);
//}
//// сортируем список
//selectedPeople.Sort();

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Для роботи з колекціями можна використовувати два способи:
//// 1. Оператори запитів LINQ
//// 2. Методи розширень LINQ
///////////////////////////////////////////////////////////////////////
//// * Оператори запитів LINQ:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//// создаем новый список для результатов
//var selectedPeople = from p in people // передаем каждый элемент из people в переменную p
//                     where p.ToUpper().StartsWith("T") //фильтрация по критерию
//                     orderby p  // упорядочиваем по возрастанию
//                     select p; // выбираем объект в создаваемую коллекцию

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// * Методи розширення LINQ:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderByDescending(p => p);

//foreach (string person in selectedPeople) 
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Список используемых методов расширения LINQ:
///////////////////////////////////////////////////////////////////////
//// Select:                определяет проекцию выбранных значений
//// Where:                 определяет фильтр выборки
//// OrderBy:               упорядочивает элементы по возрастанию
//// OrderByDescending:     упорядочивает элементы по убыванию
//// ThenBy:                задает дополнительные критерии для упорядочивания элементов возрастанию
//// ThenByDescending:      задает дополнительные критерии для упорядочивания элементов по убыванию
//// Join:                  соединяет две коллекции по определенному признаку
//// Aggregate:             применяет к элементам последовательности агрегатную функцию, которая сводит их к одному объекту
//// GroupBy:               группирует элементы по ключу
//// ToLookup:              группирует элементы по ключу, при этом все элементы добавляются в словарь
//// GroupJoin:             выполняет одновременно соединение коллекций и группировку элементов по ключу
//// Reverse:               располагает элементы в обратном порядке
//// All:                   определяет, все ли элементы коллекции удовлятворяют определенному условию
//// Any:                   определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
//// Contains:              определяет, содержит ли коллекция определенный элемент
//// Distinct:              удаляет дублирующиеся элементы из коллекции
//// Except:                возвращает разность двух коллекцию, то есть те элементы, которые создаются только в одной коллекции
//// Union:                 объединяет две однородные коллекции
//// Intersect:             возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
//// Count:                 подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
//// Sum:                   подсчитывает сумму числовых значений в коллекции
//// Average:               подсчитывает cреднее значение числовых значений в коллекции
//// Min:                   находит минимальное значение
//// Max:                   находит максимальное значение
//// Take:                  выбирает определенное количество элементов
//// Skip:                  пропускает определенное количество элементов
//// TakeWhile:             возвращает цепочку элементов последовательности, до тех пор, пока условие истинно
//// SkipWhile:             пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы
//// Concat:                объединяет две коллекции
//// Zip:                   объединяет две коллекции в соответствии с определенным условием
//// First:                 выбирает первый элемент коллекции
//// FirstOrDefault:        выбирает первый элемент коллекции или возвращает значение по умолчанию
//// Single:                выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, то генерируется исключение
//// SingleOrDefault:       выбирает единственный элемент коллекции. Если коллекция пуста, возвращает значение по умолчанию. Если в коллекции больше одного элемента, генерирует исключение
//// ElementAt:             выбирает элемент последовательности по определенному индексу
//// ElementAtOrDefault:    выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого ди апазона
//// Last:                  выбирает последний элемент коллекции
//// LastOrDefault:         выбирает последний элемент коллекции или возвращает значение по умолчанию

///////////////////////////////////////////////////////////////
//// v1

//var people = new List<Person>
//{
//    new Person ("Tom", 23),
//    new Person ("Bob", 27),
//    new Person ("Sam", 29),
//    new Person ("Alice", 24)
//};

//var names = from p in people select p.Name;

//foreach (string n in names)
//    Console.WriteLine(n);
//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////
//// v2

//var people = new List<Person>
//{
//    new Person ("Tom", 23),
//    new Person ("Bob", 27),
//    new Person ("Sam", 29),
//    new Person ("Alice", 24)
//};
//var names = people.Select(u => u.Name);

//foreach (string n in names)
//    Console.WriteLine(n);
//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////
//// v3

//var people = new List<Person>
//{
//    new Person ("Tom", 23),
//    new Person ("Bob", 27)
//};

//var personel = from p in people
//               select new
//               {
//                   FirstName = p.Name,
//                   Year = DateTime.Now.Year - p.Age
//               };

//foreach (var p in personel)
//    Console.WriteLine($"{p.FirstName} - {p.Year}");
//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////
//// Іноді виникає потреба зробити у запитах LINQ якісь додаткові проміжні обчислення.
//// Для цього ми можемо задати у запитах свої змінні за допомогою оператора - let:
///////////////////////////////////////////////////////////////////////

//var people = new List<Person>
//{
//    new Person ("Tom", 23),
//    new Person ("Bob", 27)
//};

//var personnel = from p in people
//                let name = $"Mr. {p.Name}"
//                let year = DateTime.UtcNow.Year - p.Age
//                select new
//                {
//                    Name = name,
//                    Year = year
//                };

//foreach (var p in personnel)
//    Console.WriteLine($"{p.Name} - {p.Year}");

//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////
//// * Вибірка з кількох джерел:
///////////////////////////////////////////////////////////////////////

//var courses = new List<Course> { new Course("C#"), new Course("Java") };
//var students = new List<Student> { new Student("Tom"), new Student("Bob") };

//var enrollments = from course in courses    //  выбираем по одному курсу
//                  from student in students       //  выбираем по одному студенту
//                  select new { Student = student.Name, Course = course.Title };   // соединяем каждого студента с каждым курсом

//foreach (var enrollment in enrollments)
//    Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");

//record class Course(string Title);  // учебный курс
//record class Student(string Name);  // студент

///////////////////////////////////////////////////////////////////////
//// SelectMany та зведення об'єктів:
//////////////////////////////////////////////////////////////////////////
//// Метод SelectMany дозволяє звести набір колекцій до однієї колекції.

//var companies = new List<Company>
//{
//    new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
//    new Company("Google", new List<Person> {new Person("Sam"), new Person("Mike")}),
//};
//var employees = companies.SelectMany(c => c.Staff);

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name}");

//record class Company(string Name, List<Person> Staff);
//record class Person(string Name);

///////////////////////////////////////////////////////////////////////

//var companies = new List<Company>
//{
//    new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
//    new Company("Google", new List<Person> {new Person("Sam"), new Person("Mike")}),
//};
//var employees = from c in companies
//                from emp in c.Staff
//                select emp;

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name}");

//record class Company(string Name, List<Person> Staff);
//record class Person(string Name);

///////////////////////////////////////////////////////////////////////

//var companies = new List<Company>
//{
//    new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
//    new Company("Google", new List<Person> {new Person("Sam"), new Person("Mike")}),
//};

//var employees = companies.SelectMany(c => c.Staff,
//                                    (c, emp) => new { Name = emp.Name, Company = c.Name });

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name} - {emp.Company}");

//record class Company(string Name, List<Person> Staff);
//record class Person(string Name);

///////////////////////////////////////////////////////////////////////

//var companies = new List<Company>
//{
//    new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
//    new Company("Google", new List<Person> {new Person("Sam"), new Person("Mike")}),
//};
//var employees = from c in companies
//                from emp in c.Staff
//                select new { Name = emp.Name, Company = c.Name };

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name} - {emp.Company}");

//record class Company(string Name, List<Person> Staff);
//record class Person(string Name);

///////////////////////////////////////////////////////////////////////
//// * Фільтрування колекції:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = people.Where(p => p.Length == 3); // "Tom", "Bob", "Sam", "Tim"

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = from p in people
//                     where p.Length == 3
//                     select p;

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
//// методы расширения
//var evens1 = numbers.Where(i => i % 2 == 0 && i > 10);
//// операторы запросов
//var evens2 = from i in numbers
//             where i % 2 == 0 && i > 10
//             select i;

///////////////////////////////////////////////////////////////////////

//var people = new List<Person>
//{
//    new Person ("Tom", 23, new List<string> {"english", "german"}),
//    new Person ("Bob", 27, new List<string> {"english", "french" }),
//    new Person ("Sam", 29, new List<string>  { "english", "spanish" }),
//    new Person ("Alice", 24, new List<string> {"spanish", "german" })
//};

//var selectedPeople = from p in people
//                     where p.Age > 25
//                     select p;

//foreach (Person person in selectedPeople)
//    Console.WriteLine($"{person.Name} - {person.Age}");

//record class Person(string Name, int Age, List<string> Languages);

///////////////////////////////////////////////////////////////////////

//var selectedPeople = from person in people
//                     from lang in person.Languages
//                     where person.Age < 28
//                     where lang == "english"
//                     select person;

///////////////////////////////////////////////////////////////////////

//var selectedPeople = people.SelectMany(u => u.Languages,
//                            (u, l) => new { Person = u, Lang = l })
//                          .Where(u => u.Lang == "english" && u.Person.Age < 28)
//                          .Select(u => u.Person);

///////////////////////////////////////////////////////////////////////
//// Додатковий метод розширення - OfType() дозволяє відфільтрувати дані колекції за певним типом
///////////////////////////////////////////////////////////////////////

//var people = new List<Person>
//{
//    new Student("Tom"),
//    new Person("Sam"),
//    new Student("Bob"),
//    new Employee("Mike")
//};

//var students = people.OfType<Student>();

//foreach (var student in students)
//    Console.WriteLine(student.Name);


//record class Person(string Name);
//record class Student(string Name) : Person(Name);
//record class Employee(string Name) : Person(Name);

///////////////////////////////////////////////////////////////////////
//// * Сортування:
///////////////////////////////////////////////////////////////////////

//int[] numbers = { 3, 12, 4, 10 };
//var orderedNumbers = from i in numbers
//                     orderby i
//                     select i;
//foreach (int i in orderedNumbers)
//    Console.WriteLine(i);

///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Sam" };
//var orderedPeople = from p in people orderby p select p;
//foreach (var p in orderedPeople)
//    Console.WriteLine(p);       // Bob Sam Tom

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 3, 12, 4, 10 };
//var orderedNumbers = numbers.OrderBy(n => n);
//foreach (int i in orderedNumbers)
//    Console.WriteLine(i);

//string[] people = { "Tom", "Bob", "Sam" };
//var orderedPeople = people.OrderBy(p => p);
//foreach (var p in orderedPeople)
//    Console.WriteLine(p);

///////////////////////////////////////////////////////////////////////

//var people = new List<Person>
//{
//    new Person("Tom", 37),
//    new Person("Sam", 28),
//    new Person("Tom", 22),
//    new Person("Bob", 41),
//};
//// с помощью оператора orderby
//var sortedPeople1 = from p in people
//                    orderby p.Name
//                    select p;

//foreach (var p in sortedPeople1)
//    Console.WriteLine($"{p.Name} - {p.Age}");

//// с помощью метода OrderBy
//var sortedPeople2 = people.OrderBy(p => p.Name);

//foreach (var p in sortedPeople2)
//    Console.WriteLine($"{p.Name} - {p.Age}");

//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 3, 12, 4, 10 };
//var orderedNumbers = from i in numbers
//                     orderby i descending
//                     select i;
//foreach (int i in orderedNumbers)
//    Console.WriteLine(i);   // 12 10 4 3

//

//int[] numbers = { 3, 12, 4, 10 };
//var orderedNumbers = numbers.OrderByDescending(n => n);
//foreach (int i in orderedNumbers)
//    Console.WriteLine(i);   // 12 10 4 3

///////////////////////////////////////////////////////////////////////

//var people = new List<Person>
//{
//    new Person("Tom", 37),
//    new Person("Sam", 28),
//    new Person("Tom", 22),
//    new Person("Bob", 41),
//};
//// с помощью оператора orderby
//var sortedPeople1 = from p in people
//                    orderby p.Name, p.Age
//                    select p;

//foreach (var p in sortedPeople1)
//    Console.WriteLine($"{p.Name} - {p.Age}");


//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////

//string[] people = new[] { "Kate", "Tom", "Sam", "Mike", "Alice" };
//var sortedPeople = people.OrderBy(p => p, new CustomStringComparer());

//foreach (var p in sortedPeople)
//    Console.WriteLine(p);

//// сравнение по длине строки
//class CustomStringComparer : IComparer<String>
//{
//    public int Compare(string? x, string? y)
//    {
//        int xLength = x?.Length ?? 0; // если x равно null, то длина 0
//        int yLength = y?.Length ?? 0;
//        return xLength - yLength;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// Об'єднання, перетин та різниця колекцій
///////////////////////////////////////////////////////////////////////

//string[] soft = { "Microsoft", "Google", "Apple" };
//string[] hard = { "Apple", "IBM", "Samsung" };

//// разность последовательностей
//var result = soft.Except(hard);

//foreach (string s in result)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////

//string[] soft = { "Microsoft", "Google", "Apple" };
//string[] hard = { "Apple", "IBM", "Samsung" };

//// пересечение последовательностей
//var result = soft.Intersect(hard);

//foreach (string s in result)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////

//string[] soft = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };

//// удаление дублей
//var result = soft.Distinct();

//foreach (string s in result)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////

//string[] soft = { "Microsoft", "Google", "Apple" };
//string[] hard = { "Apple", "IBM", "Samsung" };

//// объединение последовательностей
//var result = soft.Union(hard);

//foreach (string s in result)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////

//Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
//Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };

//// объединение последовательностей
//var people = students.Union(employees);

//foreach (Person person in people)
//    Console.WriteLine(person.Name);


//class Person
//{
//    public string Name { get; }
//    public Person(string name) => Name = name;

//    public override bool Equals(object? obj)
//    {
//        if (obj is Person person) return Name == person.Name;
//        return false;
//    }
//    public override int GetHashCode() => Name.GetHashCode();
//}

///////////////////////////////////////////////////////////////////////
//// * Агрегатні операції:
///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 5 };

//int query = numbers.Aggregate((x, y) => x - y);
//Console.WriteLine(query);   // -13

///////////////////////////////////////////////////////////////////////

//string[] words = { "Gaudeamus", "igitur", "Juvenes", "dum", "sumus" };
//var sentence = words.Aggregate("Text:", (first, next) => $"{first} {next}");

//Console.WriteLine(sentence);  // Text: Gaudeamus igitur Juvenes dum sumus

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
//int size = numbers.Count();  // 10
//Console.WriteLine(size);

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
////  количество четных чисел, которые больше 10
//int size = numbers.Count(i => i % 2 == 0 && i > 10);
//Console.WriteLine(size);    // 3

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

//int sum = numbers.Sum();
//Console.WriteLine(sum);     // 340

///////////////////////////////////////////////////////////////////////

//Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };

//int ageSum = people.Sum(p => p.Age);
//Console.WriteLine(ageSum);     // 106

//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

//int min = numbers.Min();
//int max = numbers.Max();
//double average = numbers.Average();

//Console.WriteLine($"Min: {min}");           // Min: 1
//Console.WriteLine($"Max: {max}");           // Max: 88
//Console.WriteLine($"Average: {average}");   // Average: 34

///////////////////////////////////////////////////////////////////////

//Person[] people = { new Person("Tom", 37), new Person("Sam", 28), new Person("Bob", 41) };

//int minAge = people.Min(p => p.Age); // минимальный возраст
//int maxAge = people.Max(p => p.Age); // максимальный возраст
//double averageAge = people.Average(p => p.Age); //средний возраст

//Console.WriteLine($"Min Age: {minAge}");           // Min Age: 28
//Console.WriteLine($"Max Age: {maxAge}");           // Max Age: 41
//Console.WriteLine($"Average Age: {averageAge}");   // Average Age: 35,33

//record class Person(string Name, int Age);

///////////////////////////////////////////////////////////////////////
//// * Методы Skip и Take:
//// Ряд методів у LINQ дозволяють отримати частину колекції, зокрема такі методи як Skip, Take, SkipWhile, TakeWhile.
//// Метод Skip() пропускает определенное количество элементов.
//// Количество пропускаемых элементов передается в качестве параметра в метод:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
//// пропускаем первые два элемента
//var result = people.Skip(2);    // "Bob", "Mike", "Kate"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Sam", "Bob", "Mike", "Kate" };
//// пропускаем последние два элемента
//var result = people.SkipLast(2);    // "Tom", "Sam", "Bob"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Метод SkipWhile() пропускает цепочку элементов, начиная с первого элемента, пока они удовлетворяют определенному условию:

//string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
//// пропускаем первые элементы, длина которых равна 3
//var result = people.SkipWhile(p => p.Length == 3);    // "Mike", "Kate", "Bob"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Метод Take() извлекает определенное число элементов. Количество извлекаемых элементов передается в метод в качестве параметра.

//string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
//// извлекаем первые 3 элемента
//var result = people.Take(3);    // "Tom", "Sam", "Mike"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Метод TakeLast() извлекает определенное количество элементов с конце коллекции:

//string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
//// извлекаем последние 3 элемента
//var result = people.TakeLast(3);    // "Mike", "Kate", "Bob"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// Метод TakeWhile() выбирает цепочку элементов, начиная с первого элемента, пока они удовлетворяют определенному условию

//string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob" };
//// извлекаем первые элементы, длина которых равна 3
//var result = people.TakeWhile(p => p.Length == 3);    // "Tom", "Sam"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// * Постраничный вывод:
//// Совмещая оба метода - Take и Skip, мы можем выбрать определенное количество элементов начиная с определенного элемента.
//// Например, выберем два элемента, начиная со четвертого (то есть пропустим 3 первых элемента):

//string[] people = { "Tom", "Sam", "Mike", "Kate", "Bob", "Alice" };
//// пропускаем 3 элемента и выбираем 2 элемента
//var result = people.Skip(3).Take(2);    // "Kate", "Bob"

//foreach (var person in result)
//    Console.WriteLine(person);

///////////////////////////////////////////////////////////////////////
//// * Угруповання:
//// Оператор group by - 
///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
//};

//var companies = from person in people
//                group person by person.Company;

//foreach (var company in companies)
//{
//    Console.WriteLine(company.Key);

//    foreach (var person in company)
//    {
//        Console.WriteLine(person.Name);
//    }
//    Console.WriteLine(); // для разделения между группами
//}

//record class Person(string Name, string Company);

///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
//};

//var companies = people.GroupBy(p => p.Company);

//foreach (var company in companies)
//{
//    Console.WriteLine(company.Key);

//    foreach (var person in company)
//    {
//        Console.WriteLine(person.Name);
//    }
//    Console.WriteLine(); // для разделения между группами
//}

//record class Person(string Name, string Company);

///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
//};

//var companies = from person in people
//                group person by person.Company into g
//                select new { Name = g.Key, Count = g.Count() }; ;

//foreach (var company in companies)
//{
//    Console.WriteLine($"{company.Name} : {company.Count}");
//}

//record class Person(string Name, string Company);

///////////////////////////////////////////////////////////////////////
//// * Вкладені запити:
///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//    new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
//};
//var companies = from person in people
//                group person by person.Company into g
//                select new
//                {
//                    Name = g.Key,
//                    Count = g.Count(),
//                    Employees = from p in g select p
//                };

//foreach (var company in companies)
//{
//    Console.WriteLine($"{company.Name} : {company.Count}");
//    foreach (var employee in company.Employees)
//    {
//        Console.WriteLine(employee.Name);
//    }
//    Console.WriteLine(); // для разделения компаний
//}

//record class Person(string Name, string Company);

///////////////////////////////////////////////////////////////////////
//// или

//var companies = people
//                    .GroupBy(p => p.Company)
//                    .Select(g => new
//                    {
//                        Name = g.Key,
//                        Count = g.Count(),
//                        Employees = g.Select(p => p)
//                    });

///////////////////////////////////////////////////////////////////////
////  * З'єднання колекцій
//// З'єднання LINQ використовується для об'єднання двох різнотипних наборів в один.
//// Для з'єднання використовується оператор join або метод Join().
//// Як правило, ця операція застосовується до двох наборів, які мають один загальний критерій.

//// from объект1 in набор1
//// join объект2 in набор2 on объект2.свойство2 equals объект1.свойство1
///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//};
//Company[] companies =
//{
//    new Company("Microsoft", "C#"),
//    new Company("Google", "Go"),
//    new Company("Oracle", "Java")
//};
//var employees = from p in people
//                join c in companies on p.Company equals c.Title
//                select new { Name = p.Name, Company = c.Title, Language = c.Language };

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");

//record class Person(string Name, string Company);
//record class Company(string Title, string Language);

///////////////////////////////////////////////////////////////////////
//// Метод Join() - приймає чотири параметри:
//// другий список, який з'єднуємо з поточним
//// делегат, який визначає властивість об'єкта з поточного списку, яким йде з'єднання
//// делегат, який визначає властивість об'єкта з другого списку, яким йде з'єднання
//// делегат, який визначає новий об'єкт у результаті з'єднання
//// Перепишемо попередній приклад з використанням методу Join:
//////////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//};
//Company[] companies =
//{
//    new Company("Microsoft", "C#"),
//    new Company("Google", "Go"),
//    new Company("Oracle", "Java")
//};
//var employees = people.Join(companies, // второй набор
//             p => p.Company, // свойство-селектор объекта из первого набора
//             c => c.Title, // свойство-селектор объекта из второго набора
//             (p, c) => new { Name = p.Name, Company = c.Title, Language = c.Language }); // результат

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");

//record class Person(string Name, string Company);
//record class Company(string Title, string Language);

///////////////////////////////////////////////////////////////////////
//// Метод GroupJoin() крім з'єднання послідовностей також виконує групування.

//GroupJoin(IEnumerable < TInner > inner,
//        Func < TOuter, TKey > outerKeySelector,
//        Func < TInner, TKey > innerKeySelector,
//        Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);

///////////////////////////////////////////////////////////////////////
//// Метод GroupJoin()  - приймає чотири параметри:
//// другий список, який з'єднуємо з поточним
//// делегат, який визначає властивість об'єкта з поточної колекції, яким йде з'єднання і яким буде йти угруповання
//// делегат, який визначає властивість об'єкта з другої колекції, яким йде з'єднання
//// делегат, який визначає новий об'єкт у результаті з'єднання. Цей делегат отримує групу - об'єкт поточної колекції,
//// яким йшло угруповання, і набір об'єктів з другої колекції, які складають групу
///////////////////////////////////////////////////////////////////////

//Person[] people =
//{
//    new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
//    new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
//};
//Company[] companies =
//{
//    new Company("Microsoft", "C#"),
//    new Company("Google", "Go"),
//    new Company("Oracle", "Java")
//};
//var personnel = companies.GroupJoin(people, // второй набор
//             c => c.Title, // свойство-селектор объекта из первого набора
//             p => p.Company, // свойство-селектор объекта из второго набора
//             (c, employees) => new   // результат
//             {
//                 Title = c.Title,
//                 Employees = employees
//             });

//foreach (var company in personnel)
//{
//    Console.WriteLine(company.Title);
//    foreach (var emp in company.Employees)
//    {
//        Console.WriteLine(emp.Name);
//    }
//    Console.WriteLine();
//}

//record class Person(string Name, string Company);
//record class Company(string Title, string Language);

///////////////////////////////////////////////////////////////////////
//// Метод Zip()  - послідовно поєднує відповідні елементи поточної послідовності з другою послідовністю, яка передається метод як параметр.
//// Тобто перший елемент з першої послідовності поєднується з першим елементом з другої послідовності,
//// другий елемент з першої послідовності з'єднується з другим елементом з другої послідовності і так далі.
//// Результатом методу є колекція кортежів, де кожен кортеж зберігає пару відповідних елементів з обох послідовностей:
///////////////////////////////////////////////////////////////////////

//var courses = new List<Course> { new Course("C#"), new Course("Java") };
//var students = new List<Student> { new Student("Tom"), new Student("Bob") };

//var enrollments = courses.Zip(students);

//foreach (var enrollment in enrollments)
//    Console.WriteLine($"{enrollment.First} - {enrollment.Second}");

//record class Course(string Title);  // учебный курс
//record class Student(string Name);  // студент

///////////////////////////////////////////////////////////////////////
// Перевірка наявності та отримання елементів
// Метод All() - проверяет, соответствуют ли все элементы условию. Если все элементы соответствуют условию, то возвращается true.
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Tim", "Bob", "Sam" };

//// проверяем, все ли элементы имеют длину в 3 символа
//bool allHas3Chars = people.All(s => s.Length == 3);     // true
//Console.WriteLine(allHas3Chars);

//// проверяем, все ли строки начинаются на T
//bool allStartsWithT = people.All(s => s.StartsWith("T"));   // false
//Console.WriteLine(allStartsWithT);

///////////////////////////////////////////////////////////////////////
//// Метод Any() - действует подобным образом, только возвращает true, если хотя бы один элемент коллекции определенному условию:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Tim", "Bob", "Sam" };

//// проверяем, все ли элементы имеют длину больше 3 символов
//bool allHasMore3Chars = people.Any(s => s.Length > 3);     // false
//Console.WriteLine(allHasMore3Chars);

//// проверяем, все ли строки начинаются на T
//bool allStartsWithT = people.Any(s => s.StartsWith("T"));   // true
//Console.WriteLine(allStartsWithT);

///////////////////////////////////////////////////////////////////////
//// Метод Contains() - возвращает true, если коллекция содержит определенный элемент.
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Tim", "Bob", "Sam" };

//// проверяем, есть ли строка Tom
//bool hasTom = people.Contains("Tom");     // true
//Console.WriteLine(hasTom);

//// проверяем, есть ли строка Mike
//bool hasMike = people.Contains("Mike");     // false
//Console.WriteLine(hasMike);

///////////////////////////////////////////////////////////////////////
//// Стоит отметить, что для сравнения объектов применяется реализация метода Equals.
//// Соответственно если мы работаем с объектами своих типов, то мы можем реализовать данный метод:
///////////////////////////////////////////////////////////////////////

//Person[] people = { new Person("Tom"), new Person("Sam"), new Person("Bob") };

//var tom = new Person("Tom");
//var mike = new Person("Mike");

//// проверяем, есть ли Tom
//bool hasTom = people.Contains(tom);     // true
//Console.WriteLine(hasTom);

//// проверяем, есть ли строка Mike
//bool hasMike = people.Contains(mike);     // false
//Console.WriteLine(hasMike);

//class Person
//{
//    public string Name { get; }
//    public Person(string name) => Name = name;

//    public override bool Equals(object? obj)
//    {
//        if (obj is Person person) return Name == person.Name;
//        return false;
//    }
//    public override int GetHashCode() => Name.GetHashCode();
//}

///////////////////////////////////////////////////////////////////////
//// Но стоит отметить, что Contains не всегда может вернуть ожидаемые данные. Например:

//string[] people = { "tom", "Tim", "bOb", "Sam" };

//// проверяем, есть ли строка Tom
//bool hasTom = people.Contains("Tom");     // false
//Console.WriteLine(hasTom);

//// проверяем, есть ли строка Bob
//bool hasMike = people.Contains("Bob");     // false
//Console.WriteLine(hasMike);

///////////////////////////////////////////////////////////////////////
//// В данном случае в массиве нет строки "Tom", а есть строка "tom".
//// Поэтому вызов people.Contains("Tom") возвратит false.
//// Но подобное поведение не всегда может быть желательным.
//// И в этом случае мы можем задать логику сравнения с помощью реализации интерфейса IComparer
//// и затем передать ее в качестве второго параметра в метод Contains:
//////////////////////////////////////////////////////////////////////////

//string[] people = { "tom", "Tim", "bOb", "Sam" };

//// проверяем, есть ли строка Tom
//bool hasTom = people.Contains("Tom", new CustomStringComparer());     // true
//Console.WriteLine(hasTom);

//// проверяем, есть ли строка Bob
//bool hasMike = people.Contains("Bob", new CustomStringComparer());     // true
//Console.WriteLine(hasMike);

//class CustomStringComparer : IEqualityComparer<string>
//{
//    public bool Equals(string? x, string? y)
//    {
//        if (x is null || y is null) return false;
//        return x.ToLower() == y.ToLower();

//    }

//    public int GetHashCode(string obj) => obj.ToLower().GetHashCode();
//}

///////////////////////////////////////////////////////////////////////
//// * First/FirstOrdefault:
//////////////////////////////////////////////////////////////////////////
//// Метод First() - возвращает первый элемент последовательности:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Tim", "Sam" };

//// проверяем, есть ли строка Tom
//var first = people.First();  // Tom
//Console.WriteLine(first);

///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//// первая строка, длина которой равна 4 символам
//var firstWith4Chars = people.First(s => s.Length == 4);  // Kate
//Console.WriteLine(firstWith4Chars);

///////////////////////////////////////////////////////////////////////
//// Стоит учитывать, что если коллекция пуста или в коллекции нет элементов,
//// который соответствуют условию, то будет сгенерировано исключение.
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//// первая строка, длина которой равна 5 символам
//var firstWith5Chars = people.First(s => s.Length == 5);  // ! исключение
//Console.WriteLine(firstWith5Chars);

//var first = new string[] { }.First();  // ! исключение
//Console.WriteLine(first);

///////////////////////////////////////////////////////////////////////
//// Метод FirstOrDefault() - также возвращает первый элемент и также может принимать условие, только если коллекция пуста 
//// или в коллекции не окажется элементов, которые соответствуют условию, то метод возвращает значение по умолчанию:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//// первый элемент
//var first = people.FirstOrDefault();  // Tom
//Console.WriteLine(first);

//// первая строка, длина которой равна 4 символам
//var firstWith4Chars = people.FirstOrDefault(s => s.Length == 4);  // Kate
//Console.WriteLine(firstWith4Chars);

//// первый элемент из пустой коллекции
//var firstOrDefault = new string[] { }.FirstOrDefault();
//Console.WriteLine(firstOrDefault);  // null

///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//string? firstWith5Chars = people.FirstOrDefault(s => s.Length == 5, "Undefined");
//Console.WriteLine(firstWith5Chars); // Undefined

//// первый элемент из пустой коллекции строк
//string? firstOrDefault = new string[] { }.FirstOrDefault("hello"); // hello - значение по умолчанию
//Console.WriteLine(firstOrDefault);  // hello

//// первый элемент из пустой коллекции int
//int firstNumber = new int[] { }.FirstOrDefault(100); // 100 - значение по умолчанию
//Console.WriteLine(firstNumber); // 100

///////////////////////////////////////////////////////////////////////
//// * Last и LastOrDefault:
//////////////////////////////////////////////////////////////////////////
//// Метод Last() - аналогичен по работе методу First, только возвращает последний элемент.
//// Если коллекция не содержит элемент, который соответствуют условию, или вообще пуста, то метод генерирует исключение.
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//string last = people.Last();
//Console.WriteLine(last); // Sam

//string lastWith4Chars = people.Last(s => s.Length == 4);
//Console.WriteLine(lastWith4Chars); // Mike

///////////////////////////////////////////////////////////////////////
//// Метод LastOrDefault() - возвращает последний элемент или значение по умолчанию,
//// если коллекция не содержит элемент, который соответствуют условию, или вообще пуста:
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//string? last = people.LastOrDefault();
//Console.WriteLine(last); // Sam

//string? lastWith4Chars = people.LastOrDefault(s => s.Length == 4);
//Console.WriteLine(lastWith4Chars); // Mike

//string? lastWith5Chars = people.LastOrDefault(s => s.Length == 5);
//Console.WriteLine(lastWith5Chars); // null

//string? lastWith5CharsOrDefault = people.LastOrDefault(s => s.Length == 5, "Undefined");
//Console.WriteLine(lastWith5CharsOrDefault); // Undefined

//// первый элемент из пустой коллекции строк
//string? lastOrDefault = new string[] { }.LastOrDefault("hello");
//Console.WriteLine(lastOrDefault);  // hello

///////////////////////////////////////////////////////////////////////
//// * Відкладене та негайне виконання LINQ:
//////////////////////////////////////////////////////////////////////////
//// Є два способи виконання запиту LINQ: відкладене (deferred) та негайне (immediate) виконання.
//// При відкладеному виконанні LINQ-вираз не виконується, поки не буде проведено ітерацію або перебір за вибіркою,
//// наприклад, у циклі foreach. Зазвичай подібні операції повертають об'єкт IEnumerable<T> або IOrderedEnumerable<T>.
//// Повний список відкладених операцій LINQ:

//// AsEnumerable
//// Cast
//// Concat
//// DefaultIfEmpty
//// Distinct
//// Except
//// GroupBy
//// GroupJoin
//// Intersect
//// Join
//// OfType
//// OrderBy
//// OrderByDescending
//// Range
//// Repeat
//// Reverse
//// Select
//// SelectMany
//// Skip
//// SkipWhile
//// Take
//// TakeWhile
//// ThenBy
//// ThenByDescending
//// Union
//// Where
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Sam", "Bob" };

//var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);

//// выполнение LINQ-запроса
//foreach (string s in selectedPeople)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////
//// То есть фактическое выполнение запроса происходит не в строке определения: var selectedPeople = people.Where..., 
//// а при переборе в цикле foreach.
//// Фактически LINQ-запрос разбивается на три этапа:
//// 1. Получение источника данных
//// 2. Создание запроса
//// 3 .Выполнение запроса и получение его результатов
//// Как это происходит в нашем случае:
//// Получение источника данных - определение массива teams:

//string[] people = { "Tom", "Sam", "Bob" };
//Создание запроса - определение переменной selectedTeams:

//var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);
//Выполнение запроса и получение его результатов:

//foreach (string s in selectedPeople)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////
//// После определения запроса он может выполняться множество раз.
//// И до выполнения запроса источник данных может изменяться.
//// Чтобы более наглядно увидеть это, мы можем изменить какой-либо элемент до перебора выборки:

//string[] people = { "Tom", "Sam", "Bob" };

//var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);

//people[2] = "Mike";
//// выполнение LINQ-запроса
//foreach (string s in selectedPeople)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////
//// Теперь выборка будет содержать два элемента, а не три,
//// так как последний элемент после изменения не будет соответствовать условию.
//// Важно понимать, что переменная запроса сама по себе не выполняет никаких
//// действий и не возвращает никаких данных. Она только хранит набор команд,
//// которые необходимы для получения результатов. То есть выполнение запроса после его создания откладывается.
//// Само получение результатов производится при переборе в цикле foreach.
///////////////////////////////////////////////////////////////////////
//// * Немедленное выполнение запроса:
//// С помощью ряда методов мы можем применить немедленное выполнение запроса. 
//// Это методы, которые возвращают одно атомарное значение или один элемент или данные типов Array, List и Dictionary. 
//// Полный список подобных операций в LINQ:

//// Aggregate
//// All
//// Any
//// Average
//// Contains
//// Count
//// ElementAt
//// ElementAtOrDefault
//// Empty
//// First
//// FirstOrDefault
//// Last
//// LastOrDefault
//// LongCount
//// Max
//// Min
//// SequenceEqual
//// Single
//// SingleOrDefault
//// Sum
//// ToArray
//// ToDictionary
//// ToList
//// ToLookup
///////////////////////////////////////////////////////////////////////

//string[] people = { "Tom", "Sam", "Bob" };
//// определение и выполнение LINQ-запроса
//var count = people.Where(s => s.Length == 3).OrderBy(s => s).Count();

//Console.WriteLine(count);   // 3 - до изменения коллекции

//people[2] = "Mike";
//Console.WriteLine(count);   // 3 - после изменения коллекции

///////////////////////////////////////////////////////////////////////
//// Результатом метода Count будет объект int, поэтому сработает немедленное выполнение.
//// Сначала создается запрос: people.Where(s => s.Length == 3).OrderBy(s => s).
//// Далее к нему применяется метод Count(), который выполняет запрос, неявно выполняет перебор по последовательности элементов, 
//// генерируемой этим запросом, и возвращает число элементов в этой последовательности.
//// Также мы можем изменить код таким образом, чтобы метод Count() учитывал изменения и 
//// выполнялся отдельно от определения запроса:

//string[] people = { "Tom", "Sam", "Bob" };
//// определение LINQ-запроса
//var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s);
//// выполнение запроса
//Console.WriteLine(selectedPeople.Count());   // 3 - до изменения коллекции

//people[2] = "Mike";
//// выполнение запроса
//Console.WriteLine(selectedPeople.Count());   // 2 - после изменения коллекции

///////////////////////////////////////////////////////////////////////
//// Также для немедленного выполнения LINQ-запроса и кэширования его
//// результатов мы можем применять методы преобразования ToArray<T>(), ToList<T>(), ToDictionary() и т.д..
//// Эти методы получают результат запроса в виде объектов Array, List и Dictionary соответственно. Например:

//string[] people = { "Tom", "Sam", "Bob" };

//// определение и выполнение LINQ-запроса
//var selectedPeople = people.Where(s => s.Length == 3).OrderBy(s => s).ToList();

//// изменение массива никак не затронет список selectedPeople
//people[2] = "Mike";

//// выполнение запроса
//foreach (string s in selectedPeople)
//    Console.WriteLine(s);

///////////////////////////////////////////////////////////////////////
//// * Делегаты в запросах LINQ:
///////////////////////////////////////////////////////////////////////
//// Если мы обратимся к определению многих методов расширений LINQ, то увидим, что в качестве параметра многие из них принимают делегаты
//// например, Func<TSource, bool>, например, определение метода Where:

//public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);


///////////////////////////////////////////////////////////////////////
//// Хотя, как правило, в качестве делегата в подобные методы удобно передавать лямбда-выражения.
//// Но тем не менее мы также можем передать полноценные методы. Например:

//string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

//var result = people.Where(LenghtIs3);

//foreach (var person in result)
//    Console.WriteLine(person);

//bool LenghtIs3(string name) => name.Length == 3;

///////////////////////////////////////////////////////////////////////
//// Пусть метод Select() применяется к коллекции целых чисел и преобразует каждое число в его квадрат:

//int[] numbers = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7 };

//var result = numbers.Where(i => i > 0).Select(Square);

//foreach (int i in result)
//    Console.WriteLine(i);
//int Square(int n) => n * n;

//// Метод Select в качестве параметра принимает тип Func<TSource, TResult> selector.
//// Так как у нас набор объектов int, то входным параметром делегата также будет объект типа int.
//// В качестве типа выходного параметра выберем int, так как здесь квадрат числа - это целочисленное значение.
///////////////////////////////////////////////////////////////////////
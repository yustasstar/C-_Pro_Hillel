// Крім звичайних класів у C# є абстрактні класи. Навіщо вони потрібні?
// Класи зазвичай представляють план певного роду об'єктів чи сутностей.
// Наприклад, ми можемо визначити клас Car для представлення машин або клас Person для представлення людей,
// вклавши в ці класи відповідні властивості, поля, методи, які описуватимуть ці об'єкти. Проте деякі сутності,
// які хочемо висловити з допомогою мови програмування, може мати конкретного втілення.
// Наприклад, насправді немає геометричної постаті як такої. Є коло, прямокутник, квадрат, але фігури немає.
// Однак і коло, і прямокутник мають щось спільне і є фігурами. І для опису подібних сутностей,
// які не мають конкретного втілення, призначені абстрактні класи.

// Анотація клас схожий на звичайний клас. Він може мати змінні, методи, конструктори, властивості.
// Єдине, що для визначення абстрактних класів використовується ключове слово abstract.

// Але головна відмінність абстрактних класів від звичайних полягає в тому,
// що ми НЕ можемо використовувати конструктор абстрактного класу для створення екземпляра класу.

// Абстрактні члени класів
// Крім звичайних властивостей і методів, абстрактний клас може мати абстрактні члени класів,
// які визначаються за допомогою ключового слова abstract і не мають ніякого функціоналу.

// Зокрема, абстрактними можуть бути:
// - Методи
// - Властивості
// - Індексатори
// - Події

// Абстрактні члени класів не повинні мати private модифікатор.
// У цьому похідний клас повинен перевизначити і продати всі абстрактні способи і якості, які у базовому абстрактному класі.
// При перевизначенні у похідному класі такий метод або властивість також оголошуються з модифікатором override
// (як і за звичайного перевизначення віртуальних методів та властивостей).
// Також слід врахувати, що якщо клас має хоча б один абстрактний метод (або абстрактну властивість, індексатор, подію),
// то цей клас має бути визначений як абстрактний.

// Абстрактні члени також, як і віртуальні, є частиною поліморфного інтерфейсу.
// Але якщо у випадку з віртуальними методами говоримо, що клас-спадкоємець успадковує реалізацію,
// то у випадку з абстрактними методами успадковується інтерфейс, представлений цими абстрактними методами.

// Відмова від реалізації абстрактних членів ->
// Похідний клас повинен продати всі абстрактні члени базового класу.
// Однак ми можемо відмовитися від реалізації, але в цьому випадку похідний клас також має бути визначений як абстрактний

namespace ThirdLesson.abstractClasses
{
    abstract class Transport
    {
        public string Name { get; }

        // абстрактна властивість для зберігання швидкості
        public abstract int Speed { get; set; }

        // конструктор абстрактного класу Transport
        public Transport(string name)
        {
            Name = name;
        }
        public void Move() => Console.WriteLine($"{Name} moving");

        public abstract void Info();
    }
    // класс корабля
    class Ship : Transport
    {
        int speed;
        public override int Speed
        {
            get => speed;
            set => speed = value;
        }

        // викликаємо конструктор базового класу
        public Ship(string name) : base(name) { }

        // ми повинні реалізувати всі абстрактні методи та властивості базового класу
        public override void Info()
        {
            Console.WriteLine("The ship is sailing");
        }
    }
    // класс самолета
    class Aircraft : Transport
    {
        public override int Speed { get; set; }
        public Aircraft(string name) : base(name) { }

        // ми повинні реалізувати всі абстрактні методи та властивості базового класу
        public override void Info()
        {
            Console.WriteLine("The plane is flying");
        }
    }
    // класс машины
    class Car : Transport
    {
        public override int Speed { get; set; }
        public Car(string name) : base(name) { }

        // ми повинні реалізувати всі абстрактні методи та властивості базового класу
        public override void Info()
        {
            Console.WriteLine("Car rides");
        }
    }

    // класичний приклад з абстрактним класом

    public interface IShape
    {
        // абстрактный метод для получения периметра
        public double GetPerimeter();
        // абстрактный метод для получения площади
        public double GetArea();
    }

    // абстрактный класс фигуры
    abstract class Shape : IShape
    {
        // абстрактный метод для получения периметра
        public abstract double GetPerimeter();
        // абстрактный метод для получения площади
        public abstract double GetArea();

        public void Show()
        {
            Console.WriteLine();
        }
    }
    // производный класс прямоугольника
    class Rectangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        // переопределение получения периметра
        public override double GetPerimeter() => Width * 2 + Height * 2;
        // переопрелеление получения площади
        public override double GetArea() => Width * Height;
    }
    // производный класс окружности
    class Circle : Shape
    {
        public double Radius { get; set; }

        // переопределение получения периметра
        public override double GetPerimeter() => Radius * 2 * 3.14;
        // переопрелеление получения площади
        public override double GetArea() => Radius * Radius * 3.14;
    }

    public static class Example2
    {
        public static void StartTest()
        {
            Transport car = new Car("Car");
            Transport ship = new Ship("Ship");
            Transport aircraft = new Aircraft("Aircraft");

            car.Move();
            ship.Move();
            aircraft.Move();

            car.Info();
            ship.Info();
            aircraft.Info();

            var rectanle = new Rectangle { Width = 20, Height = 20 };
            var circle = new Circle { Radius = 200 };
            Console.WriteLine($"Perimeter: {rectanle.GetPerimeter()}  Area: {rectanle.GetArea()}");
            Console.WriteLine($"Perimeter: {circle.GetPerimeter()}  Area: {circle.GetArea()}");
        }
    }
}

//# ООП - объектно ориентированное программирование
//# Класс - это кастомный тип данных, который описывает некоторый объект.
//# Класс - чертеж будущего экземпляра объекта.

//# Инкапсуляция - сокрытие внутренней реализации и предоставление санкционированного доступа
//# к интерфейсу класса. Как черный ящик.
//# Абстрагируемся от внутренней реализации.

//# Наследование - создание нового класса на основе уже существующего.
//# Расширение базового класса - дочерним классом.
//# Абстрагируемся от базового класса, используя дочерний класс.
// В C# НЕТ множественного наследования
// множественное наследование можно реализовать с помощью интерфейсов
// класс может наследоваться от одного класса и любого кол-ва интерфейсов

// интерфейс - это контракт, то есть описание полей и методов которые класс обязуется реализовать
// в случае наследования класса от интерфейса

//# Полиморфизм - один интерфейс и много реализаций.
//# Абстрагируемся от конкретной реализации

// Типы данных делятся на значимые и ссылочные

//Типы значений (хранятся в стеке (в windows 1 мегабайт) или куче (heap - вся нераспределенная ОЗУ)):
// значимый тип будет храниться в куче если он является частью ссылочного типа
// например если мы создали поле типа данных int в классе

//Целочисленные типы(byte, sbyte, short, ushort, int, uint, long, ulong)

//Типы с плавающей запятой (float, double)

//Тип decimal

//Тип bool

//Тип char

//Перечисления enum

//Структуры (struct)

// record struct

//Ссылочные типы (хранятся только в куче (heap)):

//Тип object

//Тип string

//Классы (class)

//Интерфейсы(interface)

//Делегаты(delegate)

// record class

namespace SecondLesson.oop
{
    // если у class нет явно модификатора доступа - по умолчанию будет internal
    class State
    {
        // все равно, что private string defaultVar;
        string defaultVar = "default";
        // поле доступно только из текущего класса
        private string privateVar = "private";
        // доступно из текущего класса и производных классов, которые определены в этом же проекте
        protected private string protectedPrivateVar = "protected private";
        // доступно из текущего класса и производных классов
        protected string protectedVar = "protected";
        // доступно в любом месте текущего проекта
        internal string internalVar = "internal";
        // доступно в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal string protectedInternalVar = "protected internal";
        // доступно в любом месте программы, а также для других программ и сборок
        public string publicVar = "public";

        // по умолчанию имеет модификатор private
        void Print() => Console.WriteLine(defaultVar);

        // метод доступен только из текущего класса
        private void PrintPrivate() => Console.WriteLine(privateVar);

        // доступен из текущего класса и производных классов, которые определены в этом же проекте
        protected private void PrintProtectedPrivate() => Console.WriteLine(protectedPrivateVar);

        // доступен из текущего класса и производных классов
        protected void PrintProtected() => Console.WriteLine(protectedVar);

        // доступен в любом месте текущего проекта
        internal void PrintInternal() => Console.WriteLine(internalVar);

        // доступен в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal void PrintProtectedInternal() => Console.WriteLine(protectedInternalVar);

        // доступен в любом месте программы, а также для других программ и сборок
        public void PrintPublic() => Console.WriteLine(publicVar);
    }

    // v1
    class Person
    {
        // поле
        private int _age;
        private string _companyName = "Google";
        private string _hobby;
        private string _firstName;

        public Person(string firstName)
        {
            _firstName = firstName;
		}

		// чтоб такое не писать - используйте автосвойство
		public string Hobby
        {
            get
            {
                return _hobby;
            }
            set
            {
                if( _hobby != value )
                {
                    _hobby = value;
                }
            }
        }

        // автосвойство
        public string Name { get; set; } = "noname";

        // свойство
        public int Age
        {
            set
            {
                if (value <= 1 || value > 150)
                {
                    // throw new Exception("Incorrect age");
                    Console.WriteLine("Incorrect age");
                }
                else
                {
                    _age = value; // value - это ключ слово, которое будет содержать значение которое мы присвоим в дальнейшем
                }
            }
            get { return _age; }
        }

        // обычный метод
        public void SetAge(int age)
        {
            if (age <= 1 || age > 150)
            {
                // throw new Exception("Incorrect age");
                Console.WriteLine("Incorrect age");
            }

            this._age = age; // value - это ключ слово, которое будет содержать значение которое мы присвоим в дальнейшем
        }

        // readonly свойство (только для чтения)
        public string CompanyName
        {
            // v1
            // get { return _companyName; }
            // v2
            get;
        }

        // writeonly свойство (только для записи)
        public string FirstName
        {
            set { _firstName = value; }
        }

        //
        public string TestInfo { get; init; } = "Some test info";
    }

    // v2
    // sealed class Person - запечатанный класс, от него нельзя отнаследоваться
    //public class Person
    //{
    //    public string Name { get; set; } = "noname";

    //    protected string Hobby { get; set; } = "no hobby";

    //    private string HobbyPrivate { get; set; } = "no private hobby";

    //    public Person(string name, string hobby, string hobbyPrivate)
    //    {
    //        Name = name;
    //        Hobby = hobby;
    //        HobbyPrivate = hobbyPrivate;
    //    }
    //}

    //public class Employee : Person // наследуемся от класса Person
    //{
    //    public string Company { get; set; } = "Google";

    //    public Employee(string company, string name, string hobby, string hobbyPrivate)
    //        : base(name, hobby, hobbyPrivate) // передали данные конструктору базового класса
    //    {
    //        Company = company;
    //    }

    //    public void ShowInfo()
    //    {
    //        Console.WriteLine($"Name: {Name} Hobby: {Hobby} Company: {Company}");
    //    }
    //}

    // v3
    public class PhoneBase
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public PhoneBase(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        // virtual - означает что этот метод мы сможем явно переопределить
        public virtual void Print()
        {
            Console.WriteLine($"Name: {Name}\nCost: {Cost}");
        }
    }

    public class SmartPhone : PhoneBase
    {
        public double Pixels { get; set; }

        public SmartPhone(string name, decimal cost, double pixels) : base(name, cost)
        {
            this.Pixels = pixels;
        }

        // неявное сокрытие метода - теряем реализацию метода с таким названием из базового класса
        //public void Print()
        //{
        //    Console.WriteLine($"Pixels: {Pixels}");
        //}

        // явное сокрытие метода - теряем реализацию метода с таким названием из базового класса
        // эту ситуацию лучше не создавать, а использовать override
        //public new void Print()
        //{
        //    Console.WriteLine($"Pixels: {Pixels}");
        //}

        // override - переопределение реализации метода базового класса
        // public override sealed void Print() - делаем запрет на дальнейшее переопределение этого метода
        public override void Print()
        {
            base.Print(); // вызываем реализацию из базового класса
            Console.WriteLine($"Pixels: {Pixels}");
        }
    }
}

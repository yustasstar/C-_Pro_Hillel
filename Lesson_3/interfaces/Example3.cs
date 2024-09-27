// Інтерфейс представляє тип посилання, який може визначати деякий функціонал - набір методів і властивостей без реалізації.
// Потім цей функціонал реалізують класи та структури, які застосовують дані інтерфейси.

// Для визначення інтерфейсу використається ключове слово interface.
// Як правило, назви інтерфейсів у C# починаються з великої літери I, наприклад,
// IComparable, IEnumerable (так звана угорська (венгерская) нотація),
// проте це не обов'язкова вимога, а більше стиль програмування.

// Що може визначити інтерфейс? Загалом інтерфейси можуть визначати такі сутності:
// - Методи
// - Властивості
// - Індексатори
// - Події
// - Статичні поля та константи (починаючи з версії C# 8.0)

// Проте інтерфейси що неспроможні визначати нестатичні змінні.

// Ще один момент в оголошенні інтерфейсу: якщо його члени - методи та властивості не мають модифікаторів доступу,
// то фактично за умовчанням доступ public, оскільки мета інтерфейсу - визначення функціоналу для реалізації його класом.
// Це стосується також констант і статичних змінних, які в класах і структурах за замовчуванням мають модифікатор private.
// В інтерфейсах вони мають за замовчуванням модифікатор public.

// Але, починаючи з версії C# 8.0, ми можемо явно вказувати модифікатори доступу у компонентів інтерфейсу.

// Як і класи, стандартні інтерфейси мають рівень доступу internal, тобто такий інтерфейс доступний тільки в рамках поточного проекту.
// Але за допомогою модифікатора public ми можемо зробити інтерфейс загальнодоступним

// Також, починаючи з версії C# 8.0, інтерфейси підтримують реалізацію методів і властивостей за умовчанням.
// Це означає, що ми можемо визначити в інтерфейсах повноцінні методи та властивості,
// які мають реалізацію як у звичайних класах та структурах.

// Інтерфейс представляє певний опис типу, набір компонентів, який повинен мати тип даних.
// І, власне, ми не можемо створювати об'єкти інтерфейсу безпосередньо за допомогою конструктора, як, наприклад, у класах

// У кінцевому підсумку інтерфейс призначений реалізації у класах і структурах.

// Інтерфейси мають ще одну важливу функцію: в C# не підтримується множинне успадкування,
// тобто ми можемо успадкувати клас тільки від одного класу, на відміну, скажімо, від мови С++,
// де успадкування можна використовувати. Інтерфейси дозволяють частково обійти це обмеження,
// оскільки C# класи і структури можуть реалізувати відразу кілька інтерфейсів.
// Всі реалізовані інтерфейси вказуються через кому

namespace ThirdLesson.interfaces
{
    public interface IMovableDemo
    {
        public const int minSpeed = 0;     // минимальная скорость
        private static int maxSpeed = 60;   // максимальная скорость
        public void Move();
        protected internal string Name { get; set; }    // название
        public delegate void MoveHandler(string message);  // определение делегата для события
        public event MoveHandler MoveEvent;    // событие движения
    }

    interface IMovable
    {
        // реализация метода по умолчанию
        void Move() => Console.WriteLine("Walking");
        // реализация свойства по умолчанию
        // свойство только для чтения
        // int MaxSpeed { get { return 0; } }

        // Якщо інтерфейс має приватні методи та властивості (тобто з модифікатором private),
        // то вони повинні мати реалізацію за умовчанням.
        // Те саме стосується статичних методів (не обов'язково приватних)

        public const int minSpeed = 0;     // минимальная скорость
        private static int maxSpeed = 60;   // максимальная скорость
                                            // находим время, за которое надо пройти расстояние distance со скоростью speed
        static double GetTime(double distance, double speed) => distance / speed;
        static int MaxSpeed
        {
            get => maxSpeed;
            set
            {
                if (value > 0) maxSpeed = value;
            }
        }
    }

    public class Person : IMovable { }

    public class Car : IMovable
    {
        public void Move() => Console.WriteLine("Driving");
    }

    public interface IMessage
    {
        string Text { get; set; }
    }
    public interface IPrintable
    {
        void Print();
    }
    public class Message : IMessage, IPrintable
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
        public void Print() => Console.WriteLine(Text);
    }

    // Окрім неявного застосування інтерфейсів, яке було розглянуто у колишній статті, існує також явна реалізація інтерфейсу.
    // При явній реалізації вказується назва методу або властивості разом із назвою інтерфейсу,
    // при цьому ми не можемо використовувати модифікатор public, тобто методи закриті
    public interface IAction
    {
        void Move();
    }
    public class BaseAction : IAction
    {
        void IAction.Move() => Console.WriteLine("Move in Base Class");
    }

    // У якій ситуації може справді знадобитися явна реалізація інтерфейсу?
    // Наприклад, коли клас застосовує кілька інтерфейсів, але вони мають один і той же метод з одним і тим же результатом,
    // що повертається, і одним і тим же набором параметрів

    class PersonDemo : ISchool, IUniversity
    {
        public void Study() => Console.WriteLine("Education at school or university");
    }
    interface ISchool
    {
        void Study();
    }
    interface IUniversity
    {
        void Study();
    }

    // Щоб розмежувати реалізовані інтерфейси, треба явно застосувати інтерфейс
    class PersonDemo2 : ISchool, IUniversity
    {
        void ISchool.Study() => Console.WriteLine("Studying in School");
        void IUniversity.Study() => Console.WriteLine("Studying at the University");
    }

    // Інша ситуація, коли у базовому класі вже реалізовано інтерфейс, але необхідно у похідному класі по-своєму реалізувати інтерфейс
    interface IActionDemo
    {
        void Move();
    }
    class BaseActionDemo : IActionDemo
    {
        public void Move() => Console.WriteLine("Move in BaseAction");
    }
    class HeroAction : BaseActionDemo, IActionDemo
    {
        void IActionDemo.Move() => Console.WriteLine("Move in HeroAction");
    }

    // Члени інтерфейсу можуть мати різні модифікатори доступу.
    // Якщо модифікатор доступу не public, а якийсь інший, то для реалізації методу,
    // властивості або події інтерфейсу в класах і структурах необхідно використовувати явну реалізацію інтерфейсу.

    // Зміна реалізації інтерфейсів у похідних класах


    // Перший варіант – перевизначення віртуальних/абстрактних методів

    //interface IAction
    //{
    //    void Move();
    //}
    //class BaseAction : IAction
    //{
    //    public virtual void Move() => Console.WriteLine("Move in BaseAction");
    //}
    //class HeroAction : BaseAction
    //{
    //    public override void Move() => Console.WriteLine("Move in HeroAction");
    //}

    // використання
    // BaseAction action1 = new HeroAction();
    // action1.Move();            // Move in HeroAction

    // IAction action2 = new HeroAction();
    // action2.Move();             // Move in HeroAction

    // Другий варіант - приховування методу у похідному класі

    //interface IAction
    //{
    //    void Move();
    //}
    //class BaseAction : IAction
    //{
    //    public void Move() => Console.WriteLine("Move in BaseAction");

    //}
    //class HeroAction : BaseAction
    //{
    //    public new void Move() => Console.WriteLine("Move in HeroAction");
    //}

    // використання

    //BaseAction action1 = new HeroAction();
    //action1.Move();            // Move in BaseAction

    //IAction action2 = new HeroAction();
    //action2.Move();           // Move in BaseAction

    // Третій варіант – повторна реалізація інтерфейсу в класі-спадкоємці

    //interface IAction
    //{
    //    void Move();
    //}
    //class BaseAction : IAction
    //{
    //    public void Move() => Console.WriteLine("Move in BaseAction");
    //}
    //class HeroAction : BaseAction, IAction
    //{
    //    public new void Move() => Console.WriteLine("Move in HeroAction");
    //}

    // використання

    //BaseAction action1 = new HeroAction();
    //action1.Move();            // Move in BaseAction

    //IAction action2 = new HeroAction();
    //action2.Move();             // Move in HeroAction

    //HeroAction action3 = new HeroAction();
    //action3.Move();             // Move in HeroAction

    // Четвертий варіант: явна реалізація інтерфейсу

    //interface IAction
    //{
    //    void Move();
    //}
    //class BaseAction : IAction
    //{
    //    public void Move() => Console.WriteLine("Move in BaseAction");
    //}
    //class HeroAction : BaseAction, IAction
    //{
    //    public new void Move() => Console.WriteLine("Move in HeroAction");
    //    // явная реализация интерфейса
    //    void IAction.Move() => Console.WriteLine("Move in IAction");
    //}

    // використання

    //BaseAction action1 = New HeroAction();
    //action1.Move(); // Move in BaseAction

    //IAction action2 = new HeroAction();
    //action2.Move(); // Move in IAction

    //HeroAction action3 = New HeroAction();
    //action3.Move(); // Move in HeroAction

    // Інтерфейси, як і класи, можуть успадковуватись
    // sealed, abstract интерфейс не может быть
    // Однак методи інтерфейсів можуть використовувати ключове слово new для приховання методів базового інтерфейсу

    interface IActionTest
    {
        void Move();
    }
    interface IRunActionTest : IActionTest
    {
        void Run();

        // скрываем реализацию из IAction
        // new void Move() => Console.WriteLine("I am running");
    }
    class BaseActionTest : IRunActionTest
    {
        public void Move()
        {
            Console.WriteLine("Move");
        }
        public void Run()
        {
            Console.WriteLine("Run");
        }
    }

    class RunAction : BaseActionTest
    {
        public void Move() => Console.WriteLine("I am tired");
    }


    public static class Example3
    {
        public static void StartTest()
        {
            Car tesla = new Car();
            tesla.Move();   // Driving

            Person tom = new Person();
            // tom.Move();     // Ошибка - метод Move не визначено у класі Person

            Message hello = new Message("Hello World");
            hello.Print();  // Hello World

            // Усі об'єкти Message є об'єктами IMessage
            IMessage hello_world = new Message("Hello World");
            Console.WriteLine(hello.Text);

            // Не всі об'єкти IMessage є об'єктами Message, необхідне явне приведення
            // Message someMessage = hello; // ! Ошибка

            // Інтерфейс IMessage не має властивості Print, необхідне явне приведення
            // hello.Print();  // ! Ошибка

            // якщо hello представляє клас Message, виконуємо перетворення
            if (hello_world is Message someMessage) someMessage.Print();

            // Перетворення від класу до його інтерфейсу, як і від похідного типу до базового, виконується автоматично.
            // Оскільки будь-який об'єкт Message реалізує інтерфейс IMessage.

            // Зворотне перетворення -від інтерфейсу до класу, що реалізує його,
            // буде аналогічно перетворення від базового класу до похідного.
            // Так як не кожен об'єкт IMessage є об'єктом Message(адже інтерфейс IMessage можуть реалізувати інші класи),
            // то для такого перетворення необхідна операція приведення типів.
            // І якщо ми хочемо звернутися до методів класу Message, які не визначені в інтерфейсі IMessage,
            // але є частиною класу Message, то нам потрібно явно виконати перетворення типів

            //
            // Слід враховувати, що з явної реалізації інтерфейсу його методи та властивості є частиною інтерфейсу класу.
            // Тому безпосередньо через об'єкт класу ми до них не зможемо звернутися:

            BaseAction baseAction1 = new BaseAction();

            // baseAction1.Move(); //! Помилка - у BaseAction немає методу Move
            // Необхідне приведення до типу IAction
            // Небезпечне приведення
            ((IAction)baseAction1).Move();
            // безпечне приведення
            if (baseAction1 is IAction action) action.Move();
            // чи так
            IAction baseAction2 = new BaseAction();
            baseAction2.Move();

            // 
            PersonDemo pers = new PersonDemo();
            pers.Study();

            //
            PersonDemo2 person = new PersonDemo2();

            ((ISchool)person).Study();
            ((IUniversity)person).Study();

            //
            HeroAction action1 = new HeroAction();
            action1.Move();            // Move in BaseAction
            ((IActionDemo)action1).Move(); // Move in HeroAction

            IActionDemo action2 = new HeroAction();
            action2.Move();             // Move in HeroAction

            //
            IActionTest action1Test = new RunAction();
            action1Test.Move(); 

            IRunActionTest action2Test = new RunAction();
            action2Test.Move();
        }
    }
}

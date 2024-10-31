namespace Lesson6.SOLID.BasicExamples2
{
    // Кожен компонент повинен мати одну і тільки одну причину зміни.

    // У C# як компонент може виступати клас, структура, метод.
    // А під обов'язком тут розуміється набір дій, що виконують єдине завдання.
    // Тобто суть принципу полягає в тому, що клас/структура/метод повинні виконувати одне завдання.
    // Весь функціонал компонента повинен бути цілісним, мати високу зв'язність (high cohesion) та низьке зчеплення (low coupling)

    class Phone
    {
        public string Model { get; }
        public int Price { get; }
        public Phone(string model, int price)
        {
            Model = model;
            Price = price;
        }
    }

    // example with incorrect implementation
    class MobileStoreV1
    {
        List<Phone> phones = new();
        public void Process()
        {
            // getting data
            Console.WriteLine("Enter model:");
            string? model = Console.ReadLine();
            Console.WriteLine("Enter price:");

            // validation
            bool result = int.TryParse(Console.ReadLine(), out var price);

            if (result == false || price <= 0 || string.IsNullOrEmpty(model))
            {
                throw new Exception("Incorrect data!");
            }
            else
            {
                phones.Add(new Phone(model, price));
                // saving data to file
                using (StreamWriter writer = new StreamWriter("store.txt", true))
                {
                    writer.WriteLine(model);
                    writer.WriteLine(price);
                }
                Console.WriteLine("Data saved correctly!");
            }
        }
    }

    // Клас має один єдиний метод Process, проте цей невеликий метод містить у собі як мінімум чотири обов'язки:
    // введення даних, їх валідація, створення об'єкта Phone і збереження.
    // У результаті клас знає абсолютно все: як отримувати дані, як валідувати, як зберігати.
    // За потреби в нього можна було б засунути ще кілька обов'язків.
    // Такі класи ще називають "божественними" або "класи-боги", оскільки вони інкапсулюють у собі абсолютно всю функціональність.
    // Подібні класи є одним із поширених анти-патернів, і їх застосування треба намагатися уникати.

    // correct implementation
    class MobileStore
    {
        List<Phone> phones = new List<Phone>();

        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }
        public IPhoneSaver Saver { get; set; }

        public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = saver;
        }

        public void Process()
        {
            string?[] data = Reader.GetInputData();
            Phone phone = Binder.CreatePhone(data);
            if (Validator.IsValid(phone))
            {
                phones.Add(phone);
                Saver.Save(phone, "store.txt");
                Console.WriteLine("Data saved correctly!");
            }
            else
            {
                Console.WriteLine("Incorrect data!");
            }
        }
    }

    interface IPhoneReader
    {
        string?[] GetInputData();
    }
    class ConsolePhoneReader : IPhoneReader
    {
        public string?[] GetInputData()
        {
            Console.WriteLine("Enter model:");
            string? model = Console.ReadLine();
            Console.WriteLine("Enter price:");
            string? price = Console.ReadLine();
            return new string?[] { model, price };
        }
    }

    interface IPhoneBinder
    {
        Phone CreatePhone(string?[] data);
    }

    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(string?[] data)
        {
            if (data is { Length: 2 } && data[0] is string model &&
                model.Length > 0 && int.TryParse(data[1], out var price))
            {
                return new Phone(model, price);

            }
            throw new Exception("Incorrect data!");
        }
    }

    interface IPhoneValidator
    {
        bool IsValid(Phone phone);
    }

    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone phone) =>
            !string.IsNullOrEmpty(phone.Model) && phone.Price > 0;
    }

    interface IPhoneSaver
    {
        void Save(Phone phone, string fileName);
    }

    class TextPhoneSaver : IPhoneSaver
    {
        public void Save(Phone phone, string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine(phone.Model);
            writer.WriteLine(phone.Price);
        }
    }

    public static class SingleResponsibilityPrincipleDemo
    {
        public static void Demo()
        {
            MobileStore store = new MobileStore(
                new ConsolePhoneReader(), new GeneralPhoneBinder(),
                new GeneralPhoneValidator(), new TextPhoneSaver());
            store.Process();
        }
    }
}

//Распространенные случаи отхода от принципа SRP

//Нередко принцип единственной обязанности нарушает при смешивании в одном классе функциональности разных уровней.
//Например, класс производит вычисления и выводит их пользователю,
//то есть соединяет в себя бизнес-логику и работу с пользовательским интерфейсом.
//Либо класс управляет сохранением/получением данных и выполнением над ними вычислений, что также нежелательно.
//Класс следует применять только для одной задачи - либо бизнес-логика, либо вычисления, либо работа с данными.

//Другой распространенный случай - наличие в классе или его методах абсолютно несвязанного между собой функционала.

//Распространенные сценарии выделения компонентов
//Есть ряд распространенных сценариев, которые обычно выносятся в отдельные компоненты:

//Логика хранения данных
//Валидация
//Механизм уведомлений пользователя
//Обработка ошибок
//Логгирование
//Выбор класса или создание его объекта
//Форматирование
//Парсинг
//Маппинг данных


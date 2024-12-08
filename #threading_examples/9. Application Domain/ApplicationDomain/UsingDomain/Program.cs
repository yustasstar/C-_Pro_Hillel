using System;
using System.Threading;
using System.Reflection;

namespace UsingDomain
{
    class Program
    {
        static AppDomain firstDomain, secondDomain, thirdDomain;

        static void Main(string[] args)
        {
            // Получаем текущий домен приложения
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Из сборки {0} вызван метод Main в домене {0}", 
                Assembly.GetExecutingAssembly().GetName().Name /* Возвращает отображаемое имя сборки.*/, 
                currentDomain.FriendlyName /* Возвращает дружественное имя этого домена приложения */);
            Console.WriteLine("Базовая директория: {0}", currentDomain.BaseDirectory);
            Console.WriteLine("Загруженные в текущий домен сборки: ");
            Assembly[] assemblies = currentDomain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            // Создаем три домена приложения с заданными именами
            firstDomain = AppDomain.CreateDomain("First Application Domain");
            secondDomain = AppDomain.CreateDomain("Second Application Domain");
            thirdDomain = AppDomain.CreateDomain("Third Application Domain");

            // Событие DomainUnload происходит непосредственно перед выгрузкой объекта AppDomain.
            firstDomain.DomainUnload += new EventHandler(DomainUnload);
            secondDomain.DomainUnload += new EventHandler(DomainUnload);
            thirdDomain.DomainUnload += new EventHandler(DomainUnload);

            // создаем три потока для параллельного запуска сборок
            Thread th1 = new Thread(new ThreadStart(ThreadMethod1));
            th1.Start();
            Thread th2 = new Thread(new ThreadStart(ThreadMethod2));
            th2.Start();          
            Thread th3 = new Thread(new ThreadStart(ThreadMethod3));
            th3.Start();

            // Выполняем сборку, содержащуюся в указанном файле.
            currentDomain.ExecuteAssembly("ApplicationDomainTest.exe");
        }

        static void ThreadMethod1()
        {
            // Выполняем сборку, содержащуюся в указанном файле.
            firstDomain.ExecuteAssembly("ApplicationDomainTest.exe");
            /* выгружаем домен приложения */
            AppDomain.Unload(firstDomain);
            
        }
        static void ThreadMethod2()
        {
            // Выполняем сборку, содержащуюся в указанном файле.
            secondDomain.ExecuteAssembly("ApplicationDomainTest.exe");
            /* выгружаем домен приложения */
            AppDomain.Unload(secondDomain);
        }

        static void ThreadMethod3()
        {
            // Создаем новый экземпляр заданного типа, определенного в указанной сборке.
            thirdDomain.CreateInstance(
                "ApplicationDomainTest" /* Отображаемое имя сборки */, 
                "ApplicationDomainTest.Demo" /* Полное имя запрошенного типа, включая пространство имен */, 
                true /* Логическое значение, указывающее, следует ли учитывать регистр при поиске */,
               BindingFlags.CreateInstance /* Указывает, что отражение должно создавать экземпляр заданного типа */, 
               null, 
               new object[] { 100, 200 } /* Аргументы для передачи конструктору */, 
               null, null);
            /* выгружаем домен приложения */
            AppDomain.Unload(thirdDomain);
        }

        static void DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Домен с именем " + (sender as AppDomain).FriendlyName + " был успешно выгружен!");
        }
    }
}

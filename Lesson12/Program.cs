class Program
{
    static void Main(string[] args)
    {
        // Main method intentionally left empty
    }
}

// Скасування завдань та паралельних операцій. CancellationToken

// Паралельне виконання завдань може тривати багато часу.
// І іноді може виникнути необхідність перервати завдання, що виконується.
// Для цього платформа .NET надає структуру CancellationToken із простору імен System.Threading.

//Загальний алгоритм скасування завдання зазвичай передбачає такий порядок дій:

//1. Створення об'єкта CancellationTokenSource , який керує та надсилає повідомлення про скасування токену.

//2. За допомогою властивості CancellationTokenSource.
//Token отримуємо власне токен - об'єкт структури CancellationToken і передаємо його в завдання, яке може бути скасовано.

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

// Для передачі токена в завдання можна застосовувати один із конструкторів класу Task:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() => { выполняемые_действия}, token); //

//3. Визначаємо завдання дії у разі її скасування.

//4. Викликаємо метод CancellationTokenSource.Cancel() ,
//який встановлює властивості CancellationToken.IsCancellationRequested значення true.
//Варто розуміти, що сам по собі метод CancellationTokenSource.Cancel() не скасовує завдання,
//він лише надсилає повідомлення про відміну через установку властивості CancellationToken.IsCancellationRequested.
//Як буде відбуватися вихід із завдання, це вирішує сам розробник.

//5. Клас CancellationTokenSource реалізує інтерфейс IDisposable.
//І коли робота з об'єктом CancellationTokenSource завершена,
//у нього слід викликати метод Dispose для звільнення всіх ресурсів, що з ним пов'язані.
//(Замість явного виклику методу Dispose можна використовувати систему using).

//Тепер щодо третього пункту – визначення дій скасування завдання.
//Як завершити завдання? Конкретні дії лежать цілком на розробнику, проте є два загальні варіанти виходу:

//При отриманні сигналу скасування вийти з методу завдання, наприклад,
//за допомогою оператора return або побудувавши відповідну логіку методу.
//Але слід враховувати, що в цьому випадку завдання перейде в стан TaskStatus.RanToCompletion,
//а не в стан TaskStatus.Canceled.

//При отриманні сигналу скасування згенерувати виняток OperationCanceledException ,
//викликавши у токена метод ThrowIfCancellationRequested() . Після цього завдання перейде у стан TaskStatus.Canceled.

/////
//// М'який вихід із завдання без винятку OperationCanceledException

// Спочатку розглянемо перший - "м'який" варіант завершення:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

// задача вычисляет квадраты чисел
//Task task = new Task(() =>
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
//        {
//            Console.WriteLine("Operation terminated");
//            return;     //  выходим из метода и тем самым завершаем задачу
//        }
//        Console.WriteLine($"Number square {i} equals {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//task.Start();

//Thread.Sleep(1000);
//// после задержки по времени отменяем выполнение задачи
//cancelTokenSource.Cancel();
//// ожидаем завершения задачи
//Thread.Sleep(1000);
////  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");
//cancelTokenSource.Dispose(); // освобождаем ресурсы

////////////////
/// Скасування завдання за допомогою генерації виключення
/// 
// Другий спосіб завершення завдання представляє генерація виключення OperationCanceledException .
// Для цього застосовується метод ThrowIfCancellationRequested() об'єкта CancellationToken:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//Task task = new Task(() =>
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//            token.ThrowIfCancellationRequested(); // генерируем исключение

//        Console.WriteLine($"Number square {i} equals {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    // после задержки по времени отменяем выполнение задачи
//    cancelTokenSource.Cancel();

//    task.Wait(); // ожидаем завершения задачи
//}
//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Operation terminated");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

////  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");

///
// Варто зазначити, що виняток виникає лише тоді,
// коли ми зупиняємо поточний потік і очікуємо на завершення завдання за допомогою методів Wait або WaitAll.
// Якщо ці методи не використовуються для очікування завдання, для неї просто встановлюється стан Canceled.
// Наприклад, у наступному випадку виняток не виникне:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//Task task = new Task(() =>
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//            token.ThrowIfCancellationRequested(); // генерируем исключение

//        Console.WriteLine($"Number square {i} equals {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    // после задержки по времени отменяем выполнение задачи
//    cancelTokenSource.Cancel();

//    // ожидаем завершения задачи
//    Thread.Sleep(1000);
//}
//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Operation terminated");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

//  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");

///////////////////
// Реєстрація обробника скасування завдання


// Вище для перевірки сигналу відміни застосовувалася властивість IsCancellationRequested.
// Але є й інший спосіб дізнатися про те, що було надіслано сигнал скасування завдання.
// Метод Register() дозволяє зареєструвати обробник скасування завдання у вигляді делегата Action:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//// задача вычисляет квадраты чисел
//Task task = new Task(() =>
//{
//    int i = 1;
//    token.Register(() =>
//    {
//        Console.WriteLine("Canceled");
//        i = 10;
//    });
//    for (; i < 10; i++)
//    {
//        Console.WriteLine($"Number square {i} equals {i * i}");
//        Thread.Sleep(400);
//    }
//}, token);
//task.Start();

//Thread.Sleep(1000);
//// после задержки по времени отменяем выполнение задачи
//cancelTokenSource.Cancel();
//// ожидаем завершения задачи
//Thread.Sleep(1000);
////  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");
//cancelTokenSource.Dispose(); // освобождаем ресурсы

// Тут обробник скасування представлений лямбда-виразом:
//token.Register(() =>
//{
//    Console.WriteLine("Canceled");
//    i = 10;
//});

// Оскільки дія задачі представляє цикл, який виконується при значенні i менше 10,
// то встановлення цієї змінної в обробнику скасування призведе до виходу із циклу та відповідно до завершення задачі.

//
// Передача токена у зовнішній метод

// Якщо операція, яка виконується в задачі, представляє зовнішній метод, то йому можна передавати як один із параметрів:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//Task task = new Task(() => PrintSquares(token), token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    // после задержки по времени отменяем выполнение задачи
//    cancelTokenSource.Cancel();

//    // ожидаем завершения задачи
//    task.Wait();
//}
//catch (AggregateException ae)
//{
//    foreach (Exception e in ae.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Canceled");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

////  проверяем статус задачи
//Console.WriteLine($"Task Status: {task.Status}");


//void PrintSquares(CancellationToken token)
//{
//    for (int i = 1; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//            token.ThrowIfCancellationRequested(); // генерируем исключение

//        Console.WriteLine($"Number square {i} equals {i * i}");
//        Thread.Sleep(200);
//    }
//}

// Скасування паралельних операцій Parallel

// Для скасування виконання паралельних операцій, запущених за допомогою методів Parallel.For() та Parallel.ForEach() ,
// можна використовувати перевантажені версії даних методів, які приймають як параметр об'єкт ParallelOptions .
// Цей об'єкт дозволяє встановити токен:

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;

//// в другой задаче посылаем сигнал отмены
//new Task(() =>
//{
//    Thread.Sleep(400);
//    cancelTokenSource.Cancel();
//}).Start();

//try
//{
//    Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5 },
//                                new ParallelOptions { CancellationToken = token }, Square);
//    // или так
//    //Parallel.For(1, 5, new ParallelOptions { CancellationToken = token }, Square);
//}
//catch (OperationCanceledException)
//{
//    Console.WriteLine("Canceled");
//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

//void Square(int n)
//{
//    Thread.Sleep(3000);
//    Console.WriteLine($"Number square {n} equals {n * n}");
//}

// У паралельній запущеній задачі через 400 мілісекунд відбувається виклик cancelTokenSource.Cancel(),
// в результаті програма викидає виняток OperationCanceledException, і виконання паралельних операцій припиняється.

/////////////
// Асинхронні методи, async та await

//Нерідко програма виконує такі операції, які можуть зайняти тривалий час, наприклад,
//звернення до мережевих ресурсів, читання-запису файлів, звернення до бази даних і т.д.
//Такі операції можуть серйозно навантажити програму.
//Особливо це актуально у графічних (десктопних або мобільних) додатках,
//де тривалі операції можуть блокувати інтерфейс користувача
//та негативно вплинути на бажання користувача працювати з програмою, або у веб-додатках,
//які мають бути готові обслуговувати тисячі запитів на секунду.
//У синхронному додатку при виконанні тривалих операцій в основному потоці цей потік просто
//блокувався б на час виконання операції. І щоб тривалі операції не блокували загальну роботу програми,
//C# можна задіяти асинхронність.

//Асинхронність дозволяє винести окремі завдання з основного потоку до спеціальних асинхронних методів
//і при цьому більш економно використовувати потоки. Асинхронні методи виконуються окремих потоках.
//Однак при виконанні тривалої операції потік асинхронного методу повернеться в пул потоків
//і використовуватиметься для інших завдань. А коли тривала операція завершить своє виконання,
//для асинхронного методу знову виділяється потік з пулу потоків, асинхронний метод продовжує свою роботу.

//Ключовими для роботи з асинхронними викликами C# є два оператори: async і await , мета яких -
//спростити написання асинхронного коду. Вони використовуються для створення асинхронного методу.

//Асинхронний метод має такі ознаки:

//У заголовку методу використовується модифікатор async

//Метод містить один або кілька виразів await

//Як тип, що повертається, використовується один з наступних:

//void

//Task

//Task<T>

//ValueTask<T>

//Асинхронний метод, як і звичайний, може використовувати будь-яку кількість параметрів
//або взагалі не використовувати їх. Однак асинхронний метод не може визначати параметри з модифікаторами out , ref та in .

//Також варто зазначити, що слово async , яке вказується у визначенні методу,
//НЕ робить автоматично метод асинхронним. Воно лише вказує, що даний метод може містити один або кілька виразів await .

//Розглянемо найпростіший приклад визначення та виклику асинхронного методу:


//await PrintAsync();   // вызов асинхронного метода
//Console.WriteLine("Actions in Main");

//void Print()
//{
//    Thread.Sleep(3000);     // имитация продолжительной работы
//    Console.WriteLine("Hello");
//}

//// определение асинхронного метода
//async Task PrintAsync()
//{
//    Console.WriteLine("start PrintAsync"); // выполняется синхронно
//    await Task.Run(() => Print());                // выполняется асинхронно
//    Console.WriteLine("end PrintAsync");
//}

///
//Асинхронний метод Main
//Варто враховувати, що оператор await можна застосовувати лише у методі, який має модифікатор async .
//І якщо ми в методі Main використовуємо оператор await , то метод Main теж має бути визначений як асинхронний.
//Тобто попередній приклад фактично буде аналогічним до наступного:

//class Program
//{
//    async static Task Main(string[] args)
//    {
//        await PrintAsync();   // вызов асинхронного метода
//        Console.WriteLine("Actions in Main");

//        void Print()
//        {
//            Thread.Sleep(3000);     // имитация продолжительной работы
//            Console.WriteLine("Hello");
//        }

//        //// определение асинхронного метода
//        async Task PrintAsync()
//        {
//            Console.WriteLine("start PrintAsync"); // выполняется синхронно
//            await Task.Run(() => Print());                // выполняется асинхронно
//            Console.WriteLine("end PrintAsync");
//        }
//    }
//}

////
// Затримка асинхронної операції та Task.Delay
// В асинхронних методах для зупинки методу на деякий час можна використовувати метод Task.Delay() .
// Як параметр він приймає кількість мілісекунд у вигляді значення int або об'єкт TimeSpan, який задає час затримки:

//await PrintAsync();   // вызов асинхронного метода
//Console.WriteLine("actions in Main");

//// определение асинхронного метода
//async Task PrintAsync()
//{
//    await Task.Delay(3000);     // имитация продолжительной работы
//    // или так
//    //await Task.Delay(TimeSpan.FromMilliseconds(3000));
//    Console.WriteLine("Hello");
//}

// Причому метод Task.Delay сам собою представляє асинхронну операцію, тому до нього застосовується оператор await.

//Переваги асинхронності
//Наведені вище приклади є спрощенням, і навряд чи їх можна вважати показовим. Розглянемо інший приклад:

//PrintName("Tom");
//PrintName("Bob");
//PrintName("Sam");

//void PrintName(string name)
//{
//    Thread.Sleep(3000);     // имитация продолжительной работы
//    Console.WriteLine(name);
//}

//Цей код є синхронним і виконує послідовно три виклики методу PrintName. 
//    Оскільки для імітації тривалої роботи в методі встановлено затримку на три секунди, 
//    то загальне виконання програми займе щонайменше 9 секунд. 
//    Так як кожен наступний виклик PrintName буде чекати, поки завершиться попередній.

//Змінимо у програмі синхронний метод PrintName на асинхронний:

//await PrintNameAsync("Tom");
//await PrintNameAsync("Bob");
//await PrintNameAsync("Sam");

//// определение асинхронного метода
//async Task PrintNameAsync(string name)
//{
//    await Task.Delay(3000);     // имитация продолжительной работы
//    Console.WriteLine(name);
//}

//Замість методу PrintName тепер викликається тричі PrintNameAsync. 
//    Для імітації тривалої роботи в методі встановлено затримку на 3 секунди за допомогою дзвінка Task.Delay(3000). 
//    І оскільки при викликі кожного методу застосовується оператор await, 
//    який зупиняє виконання до завершення асинхронного методу,
//    загальне виконання програми знову ж таки займе не менше 9 секунд. Тим не менш, 
//    тепер виконання асинхронних операцій не блокує основний потік.

//Тепер оптимізуємо програму:

//var tomTask = PrintNameAsync("Tom");
//var bobTask = PrintNameAsync("Bob");
//var samTask = PrintNameAsync("Sam");

//await tomTask;
//await bobTask;
//await samTask;
//// определение асинхронного метода
//async Task PrintNameAsync(string name)
//{
//    await Task.Delay(3000);     // имитация продолжительной работы
//    Console.WriteLine(name);
//}

// У разі завдання фактично запускаються щодо. А оператор await застосовується лише тоді,
// коли нам потрібно дочекатися завершення асинхронних операцій – тобто наприкінці програми.
// І в цьому випадку загальне виконання програми займе не менше 3 секунд, але набагато менше 9 секунд.

// Визначення асинхронного лямбда-виразу

// асинхронное лямбда-выражение
//Func<string, Task> printer = async (message) =>
//{
//    await Task.Delay(1000);
//    Console.WriteLine(message);
//};

//await printer("Hello World");
//await printer("Hello");

///////////
// Повернення результату з асинхронного методу

// Як тип, що повертається в асинхронному методі повинні використовуватися типи void , Task , Task<T> або ValueTask<T>

// void

//PrintAsync("Hello World");
//PrintAsync("Hello");

//Console.WriteLine("Main End");
//await Task.Delay(3000); // ждем завершения задач

//// определение асинхронного метода
//async void PrintAsync(string message)
//{
//    await Task.Delay(1000);     // имитация продолжительной работы
//    Console.WriteLine(message);
//}

// Однак асинхронних void-методів слід уникати і слід використовувати тільки там,
// де ці подібні методи є єдиним можливим способом визначення асинхронного методу.
// Насамперед ми не можемо застосувати до подібних методів оператор await. Також тому,
// що винятки в таких методах складно обробляти, оскільки вони не можуть бути перехоплені поза методом.
// Крім того, такі void-методи складно тестувати.

// Тим не менш, є ситуації, де без подібних методів не обійтися - наприклад, при обробці подій:

//Account account = new Account();
//account.Added += PrintAsync;

//account.Put(500);

//await Task.Delay(2000); // ждем завершения

//// определение асинхронного метода
//async void PrintAsync(object? obj, string message)
//{
//    await Task.Delay(1000);     // имитация продолжительной работы
//    Console.WriteLine(message);
//}

//class Account
//{
//    int sum = 0;
//    public event EventHandler<string>? Added;
//    public void Put(int sum)
//    {
//        this.sum += sum;
//        Added?.Invoke(this, $"Inbound to acc {sum} $");
//    }
//}

// В даному випадку подія Added у класі Account представляє делегат EventHandler, який має тип void.
// Відповідно під цю подію можна визначити лише метод-обробник із типом void.

// Task

//var task = PrintAsync("Hello"); // задача начинает выполняться
//Console.WriteLine(task.Status);
//Console.WriteLine("Main Works");

//await task; // ожидаем завершения задачи

//// определение асинхронного метода
//async Task PrintAsync(string message)
//{
//    await Task.Delay(0);
//    Console.WriteLine(message);
//}

// Task<T>

//var square5 = SquareAsync(5);
//var square6 = SquareAsync(6);

//Console.WriteLine("rest of actions in Main");

//var n1_task = square5;
//Console.WriteLine(n1_task);
//int n1 = n1_task.Result;
//int n2 = await square6;
//Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(0);
//    var result = n * n;
//    Console.WriteLine($"number square {n} equals {result}");
//    return result;
//}

// ValueTask<T>

//Використання типу ValueTask<T> багато в чому аналогічне до застосування Task<T> за винятком деяких
//відмінностей у роботі з пам'яттю, оскільки ValueTask - структура, яка містить більшу кількість полів.
//Тому застосування ValueTask замість Task призводить до копіювання більшої кількості даних і створює деякі додаткові витрати.

//Перевагою ValueTask перед Task і те, що цей тип дозволяє уникнути додаткових виділень пам'яті в хіпі.
//Наприклад, іноді потрібно синхронно повернути певне значення. Так, візьмемо такий приклад:

//var result = await AddAsync(4, 5);
//Console.WriteLine(result);

//Task<int> AddAsync(int a, int b)
//{
//    return Task.FromResult(a + b);
//}

// Тут метод AddAsync синхронно повертає деяке значення - у разі суму двох чисел.
// За допомогою статичного методу Task.FromResult можна синхронно повернути деяке значення.
// Однак використання типу Task призведе до виділення додаткового завдання із супутніми виділеннями пам'яті в хіпі.
// ValueTask вирішує це завдання:

//var result = await AddAsync(4, 5);
//Console.WriteLine(result);

//ValueTask<int> AddAsync(int a, int b)
//{
//    return new ValueTask<int>(a + b);
//}

// У цьому випадку додатковий об'єкт Task не буде створюватись і відповідно додаткова пам'ять не виділятиметься.
// Тому ValueTask зазвичай застосовується, коли результат асинхронної операції вже є.

// При необхідності також можна перетворити ValueTask на об'єкт Task за допомогою методу AsTask() :

//var getMessage = GetMessageAsync();
//string message = await getMessage.AsTask();
//Console.WriteLine(message); // Hello

//async ValueTask<string> GetMessageAsync()
//{
//    await Task.Delay(0);
//    return "Hello";
//}

// Послідовне та паралельне виконання. Task.WhenAll та Task.WhenAny

// Асинхронний метод може містити безліч виразів await.
// Коли система зустрічає в блоці коду оператор await, виконання в асинхронному методі зупиняється,
// поки не завершиться асинхронне завдання. Після завершення завдання керування переходить
// до наступного оператора await і так далі. Це дозволяє викликати асинхронні завдання послідовно у порядку.
// Наприклад:

//await PrintAsync("Hello C#");
//await PrintAsync("Hello World");
//await PrintAsync("Hello C++");

//async Task PrintAsync(string message)
//{
//    await Task.Delay(2000);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

//Тобто ми бачимо, що виклики PrintAsync виконуються послідовно в порядку, в якому вони визначені в коді.
//Кожне завдання виконується як мінімум 2 секунди, відповідно,
//загальний час виконання трьох завдань буде як мінімум 6 секунд. І в цьому випадку висновок суворо детерміновано.

//Нерідко така послідовність буває необхідною, якщо одне завдання залежить від результатів іншого.

//Однак це не завжди потрібно. У разі ми можемо відразу запустити всі завдання паралельно і
//застосувати оператор await там, де необхідно гарантувати завершення виконання завдання, наприклад, у кінці програми.

// определяем и запускаем задачи
//var task1 = PrintAsync("Hello C#");
//var task2 = PrintAsync("Hello World");
//var task3 = PrintAsync("Hello C++");

//// ожидаем завершения задач
//await task1;
//await task2;
//await task3;

//async Task PrintAsync(string message)
//{
//    await Task.Delay(2000);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// У цьому випадку всі завдання запускаються і виконуються паралельно, відповідно,
// загальний час виконання буде менше 6 секунд, а консольний висновок програми недетермінований.

// Однак .NET дозволяє спростити відстеження виконання набору завдань за допомогою методу Task.WhenAll .
// Цей метод приймає набір асинхронних завдань і очікує на завершення всіх цих завдань.
// Цей метод є аналогом статичного методу Task.WaitAll(),
// проте призначений безпосередньо для асинхронних методів і дозволяє застосовувати оператор await:

//// определяем и запускаем задачи
//var task1 = PrintAsync("Hello C#");
//var task2 = PrintAsync("Hello World");
//var task3 = PrintAsync("Hello C++");

//// ожидаем завершения всех задач
//await Task.WhenAll(task1, task2, task3);

//async Task PrintAsync(string message)
//{
//    await Task.Delay(2000);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// Спочатку запускаються три завдання. Потім Task.WhenAll створює нове завдання,
// яке буде автоматично виконано після виконання всіх наданих задач, тобто задач task1, task2, task3.
// А за допомогою оператора await очікуємо на її завершення.

//Якщо нам треба дочекатися, коли буде виконано хоча б одне завдання з деякого набору завдань,
//можна застосовувати метод Task.WhenAny() . Це аналог методу Task.WaitAny()-він завершує виконання,
//коли завершується хоча одне завдання. Але для очікування виконання Task.WhenAny() застосовується оператор await:

//// определяем и запускаем задачи
//var task1 = PrintAsync("Hello C#");
//var task2 = PrintAsync("Hello World");
//var task3 = PrintAsync("Hello C++");

//// ожидаем завершения хотя бы одной задачи
//await Task.WhenAny(task1, task2, task3);

//async Task PrintAsync(string message)
//{
//    await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

//
// Отримання результату

// Завдання, що передаються Task.WhenAllі Task.WhenAny, можуть повертати деяке значення.
// У цьому випадку з методів Task.WhenAll та Task.WhenAny можна отримати масив, який міститиме результати завдань:

//// определяем и запускаем задачи
//var task1 = SquareAsync(4);
//var task2 = SquareAsync(5);
//var task3 = SquareAsync(6);

//// ожидаем завершения всех задач
//int[] results = await Task.WhenAll(task1, task2, task3);
//// получаем результаты:
//foreach (int result in results)
//    Console.WriteLine(result);

//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(1000);
//    return n * n;
//}

// У разі метод Square повертає число int - квадрат переданого метод числа.
// І змінна results міститиме результат виклику Task.WhenAll - по суті результати всіх трьох запущених завдань.
// Оскільки всі передані в Task.WhenAll завдання повертають int,
// то результат Task.WhenAll буде представляти масив значень int.

// Також після завершення завдання її результат можна отримати стандартним чином через властивість Result:

//// определяем и запускаем задачи
//var task1 = SquareAsync(4);
//var task2 = SquareAsync(5);
//var task3 = SquareAsync(6);

//await Task.WhenAll(task1, task2, task3);
//// получаем результат задачи task2
//Console.WriteLine($"task2 result: {task2.Result}"); // task2 result: 25

//async Task<int> SquareAsync(int n)
//{
//    await Task.Delay(1000);
//    return n * n;
//}

//
// Обробка помилок у асинхронних методах

// Обробка помилок в асинхронних методах, що використовують ключові слова asyncта await, має свої особливості.

// Для обробки помилок вираз await міститься в блок try:

//try
//{
//    await PrintAsync("Hello");
//    await PrintAsync("Hi");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//async Task PrintAsync(string message)
//{
//    // если длина строки меньше 3 символов, генерируем исключение
//    if (message.Length < 3)
//        throw new ArgumentException($"Invalid string length: {message.Length}");
//    await Task.Delay(100);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// У цьому випадку асинхронний метод PrintAsync генерує виняток ArgumentException,
// якщо методу передається рядок із довжиною менше 3 символів.

// Для обробки виключення в методі Main вираз await поміщений у блок try.
// У результаті під час виконання виклику await PrintAsync("Hi")буде згенеровано виняток, що привіт до генерації винятку.
// Однак програма не зупинить аварійно свою роботу, а опрацює виняток та продовжить подальші обчислення.

// Слід враховувати, що якщо асинхронний метод має тип void, то в цьому випадку виняток не передається,
// відповідно ми не зможемо обробити виняток при викликі методу:

//try
//{
//    PrintAsync("Hello");
//    PrintAsync("Hi");       // здесь программа сгенерирует исключение и аварийно остановится
//    await Task.Delay(1000); // ждем завершения задач
//}
//catch (Exception ex)    // исключение НЕ будет обработано
//{
//    Console.WriteLine(ex.Message);
//}

//async void PrintAsync(string message)
//{
//    // если длина строки меньше 3 символов, генерируем исключение
//    if (message.Length < 3)
//        throw new ArgumentException($"Invalid string length: {message.Length}");
//    await Task.Delay(100);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// В даному випадку, незважаючи на те, що асинхронні методи викликаються в блоці try,
// виняток не буде перехоплено та оброблено. У цьому вся один з мінусів застосування асинхронних void-методів.
// Щоправда, у разі ми можемо визначити обробку винятку у самому асинхронному методі:

//PrintAsync("Hello");
//PrintAsync("Hi");
//await Task.Delay(1000); // ждем завершения задач

//async void PrintAsync(string message)
//{
//    try
//    {
//        // если длина строки меньше 3 символов, генерируем исключение
//        if (message.Length < 3)
//            throw new ArgumentException($"Invalid string length: {message.Length}");
//        await Task.Delay(100);     // имитация продолжительной операции
//        Console.WriteLine(message);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//
// Дослідження виключення

// При виникненні помилки об'єкт Task, що представляє асинхронну задачу, в якій відбулася помилка,
// властивість IsFaulted має значення true. Крім того, властивість Exceptionоб'єкта Task містить всю інформацію про помилку.
// Проінспектуємо цю властивість:

//var task = PrintAsync("Hi");
//try
//{
//    await task;
//}
//catch
//{
//    Console.WriteLine(task.Exception?.InnerException?.Message); // Invalid string length: 2
//    Console.WriteLine($"IsFaulted: {task.IsFaulted}");  // IsFaulted: True
//    Console.WriteLine($"Status: {task.Status}");        // Status: Faulted
//}

//async Task PrintAsync(string message)
//{
//    // если длина строки меньше 3 символов, генерируем исключение
//    if (message.Length < 3)
//        throw new ArgumentException($"Invalid string length: {message.Length}");
//    await Task.Delay(1000);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// І якщо ми передамо метод рядок з довжиною менше 3 символів, то task.IsFaulted буде рівно true.

// Обробка кількох винятків. WhenAll

// Якщо ми очікуємо виконання відразу кількох завдань, наприклад, з допомогою Task.WhenAll,
// ми можемо отримати відразу кілька винятків одномоментно кожної виконуваної завдання.
// У цьому випадку ми можемо отримати всі винятки з якості Exception.InnerExceptions:

// определяем и запускаем задачи
//var task1 = PrintAsync("H");
//var task2 = PrintAsync("Hi");
//var allTasks = Task.WhenAll(task1, task2);
//try
//{
//    await allTasks;
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Exception: {ex.Message}");
//    Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
//    if (allTasks.Exception is not null)
//    {
//        foreach (var exception in allTasks.Exception.InnerExceptions)
//        {
//            Console.WriteLine($"InnerException: {exception.Message}");
//        }
//    }
//}

//async Task PrintAsync(string message)
//{
//    // если длина строки меньше 3 символов, генерируем исключение
//    if (message.Length < 3)
//        throw new ArgumentException($"Invalid string: {message}");
//    await Task.Delay(1000);     // имитация продолжительной операции
//    Console.WriteLine(message);
//}

// Тут у два виклики методу PrintAsync передаються явно некоректні значення.
// Таким чином, при обох викликах буде згенеровано помилку.

// Хоча блок catch через змінну Exception exотримуватиме один перехоплений виняток,
// але за допомогою колекції Exception.InnerExceptions ми зможемо отримати інформацію про всі винятки.

//////////////
// Асинхронні стрими

//Починаючи з версії C# 8.0 C# були додані асинхронні стрими , які спрощують роботу з потоками даних в асинхронному режимі.
//Хоча асинхронність у C# існує вже досить давно, проте асинхронні методи досі дозволяли отримувати один об'єкт,
//коли асинхронна операція була готова надати результат. Для повернення кількох значень C# можуть застосовуватися ітератори,
//але вони мають синхронну природу, блокують викликаючий потік і не можуть використовуватися в асинхронному контексті.
//Асинхронні стрими обходять цю проблему,
//дозволяючи отримувати безліч значень та повертати їх у міру готовності в асинхронному режимі.

//По суті асинхронний стрим представляє метод, який має три характеристики:

//метод має модифікатор async

//Метод повертає об'єкт IAsyncEnumerable<T> . Інтерфейс IAsyncEnumerable визначає метод GetAsyncEnumerator,
//який повертає IAsyncEnumerator:

//public interface IAsyncEnumerable<out T>
//{
//    IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default);
//}

//public interface IAsyncEnumerator<out T> : IAsyncDisposable
//{
//    T Current { get; }
//    ValueTask<bool> MoveNextAsync();
//}
//public interface IAsyncDisposable
//{
//    ValueTask DisposeAsync();
//}

// метод містить вирази yield returnдля послідовного отримання елементів з асинхронного стриму

// Фактично асинхронний стрим поєднує асинхронність та ітератори. Розглянемо найпростіший приклад:

//await foreach (var number in GetNumbersAsync())
//{
//    Console.WriteLine(number);
//}

//async IAsyncEnumerable<int> GetNumbersAsync()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        await Task.Delay(100);
//        yield return i;
//    }
//}

// Отже, метод GetNumbersAsync() власне і представляє асинхронний стрим. Цей метод є асинхронним.
// Його тип, що повертається - IAsyncEnumerable<int>. А його суть зводиться до того,
// що він повертає за допомогою yield returnкожні 100 мілісекунд кілька..
// Тобто фактично метод повинен повернути 10 чисел від 0 до 9 із проміжком у 100 мілісекунд.

//Для отримання даних зі стриму в методі Main використовується цикл foreach:

//await foreach (var number in GetNumbersAsync())

//Важливо, що він передує оператору await .
//У результаті, щоразу коли асинхронний стрим повертатиме чергове число, цикл його одержуватиме і виводитиме на консоль.

//Де можна використовувати асинхронні стрими? Асинхронні стрими можуть застосовуватися
//для отримання даних із якогось зовнішнього сховища. Наприклад, нехай є наступний клас деякого сховища:

//class Repository
//{
//    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
//    public async IAsyncEnumerable<string> GetDataAsync()
//    {
//        for (int i = 0; i < data.Length; i++)
//        {
//            Console.WriteLine($"Получаем {i + 1} элемент");
//            await Task.Delay(500);
//            yield return data[i];
//        }
//    }
//}

// Для спрощення прикладу дані представлені у вигляді простого внутрішнього масиву рядків.
// Для імітації затримки отримання застосовується метод Task.Delay.

// Отримаємо ці дані у програмі:

//Repository repo = new Repository();
//IAsyncEnumerable<string> data = repo.GetDataAsync();
//await foreach (var name in data)
//{
//    Console.WriteLine(name);
//}

//class Repository
//{
//    string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };
//    public async IAsyncEnumerable<string> GetDataAsync()
//    {
//        for (int i = 0; i < data.Length; i++)
//        {
//            Console.WriteLine($"Получаем {i + 1} элемент");
//            await Task.Delay(500);
//            yield return data[i];
//        }
//    }
//}

//////////////////////
// Введення у Parallel LINQ. Метод AsParallel

//За замовчуванням всі елементи колекції в LINQ обробляються послідовно,
//але починаючи з .NET 4.0 в простір імен System.Linq був доданий клас ParallelEnumerable ,
//який інкапсулює функціональність PLINQ (Parallel LINQ) і дозволяє звертатися до колекції в паралельному режимі.

//Під час обробки колекції PLINQ використовує можливості всіх процесорів у системі.
//Джерело даних поділяється на сегменти, кожен сегмент обробляється в окремому потоці.
//Це дозволяє зробити запит на багатоядерних машинах набагато швидше.

//У той же час, за замовчуванням PLINQ вибирає послідовну обробку даних.
//Перехід до паралельної обробки здійснюється у тому випадку, якщо це призведе до прискорення роботи.
//Проте, зазвичай, при паралельних операціях зростають додаткові витрати.
//Тому якщо паралельна обробка потенційно потребує великих витрат ресурсів,
//то PLINK у разі може вибрати послідовну обробку, якщо вона вимагає великих витрат ресурсів.

//Тому зміст застосування PLINQ є переважно на великих колекціях або при складних операціях,
//де дійсно вигода від розпаралелювання запитів може перекрити витрати, що виникають при цьому.

//Також слід враховувати, що при доступі до загального стану в паралельних операціях
//буде неявно використовуватися синхронізація, щоб уникнути взаємоблокування доступу до цих загальних ресурсів.
//Витрати на синхронізацію ведуть до зниження продуктивності,
//тому бажано уникати або обмежувати застосування в паралельних операціях ресурсів, що розділяються.

//Метод AsParallel
//Метод AsParallel() дозволяє розпаралелити запит до джерела даних.
//Він реалізований як метод розширення LINQ у масивів та колекцій.
//При виклик даного методу джерело даних поділяється на частини (якщо це можливо)
//і над кожною частиною окремо виконуються операції.

//Розглянемо найпростіший приклад знаходження квадратів чисел:

//int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };
//var squares = from n in numbers.AsParallel()
//              select Square(n);

//foreach (var n in squares)
//    Console.WriteLine(n);

//int Square(int n) => n * n;

//Фактично тут звичайний запит LINQ, тільки джерела даних застосовується метод AsParallel.

//Результат роботи програми свідчить, що дані вибиралися знаходження квадратів не послідовно.
//Тобто відбулося розпаралелювання роботи програми:

//Метод ForAll
//Вище розглянутий код обчислення квадрата числа можна ще більше оптимізувати з точки зору паралелізації.
//Зокрема для висновку результату паралельної операції використовується цикл foreach.
//Але його використання призводить до збільшення витрат -
//необхідно склеїти отримані різних потоках дані в один набір і потім їх перебрати в циклі.
//Більш оптимально в даному випадку було б використання методу ForAll() ,
//який виводить дані в тому ж потоці, в якому вони обробляються:

//int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };

//// с помощью операторов LINQ
//(from n in numbers.AsParallel() select Square(n)).ForAll(Console.WriteLine);

//// с помощью методов расширения LINQ
//numbers.AsParallel().Select(n => Square(n)).ForAll(Console.WriteLine);

//int Square(int n) => n * n;

// Метод ForAll() як параметр приймає делегат Action, який вказує на дію, що виконується.

// Метод AsOrdered

// При виконанні паралельного запиту порядок даних результуючої вибірки може бути не передбачуваним.
// Наприклад:

//int[] numbers = new int[] { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, };
//var squares = from n in numbers.AsParallel()
//              where n > 0
//              select Square(n);

//foreach (var n in squares)
//    Console.WriteLine(n);

//int Square(int n) => n * n;

// В даному випадку програма обчислює квадрати чисел, які більші за 0.
// Проте в результаті роботи програми ми можемо отримати невпорядкований висновок:

// Тобто дані склеюються у загальний набір невпорядковано.

// Якщо у запиті застосовуються оператори або методи сортування у запиті, дані автоматично впорядковуються:

//var squares = from n in numbers.AsParallel()
//              where n > 0
//              orderby n  // сортировка
//              select Square(n);

// Проте не завжди оператор orderbyчи метод OrderByвикористовуються у запитах.
// Більше того, вони впорядковують результуючу вибірку відповідно до результатів,
// а не відповідно до вихідної послідовності. У цих випадках ми можемо застосовувати метод AsOrdered() :

//var squares = from n in numbers.AsParallel().AsOrdered()
//              where n > 0
//              select Square(n);

// У цьому випадку результат вже буде впорядкованим відповідно до того, як елементи розміщуються у вихідній послідовності

//У той самий час треба розуміти, що впорядкування у паралельної операції призводить до збільшення витрат,
//тому такий запит виконуватиметься повільніше, ніж невпорядкований.
//І якщо завдання не вимагає повернення впорядкованого набору, краще не застосовувати метод AsOrdered.

//Крім того, якщо програма має якісь маніпуляції з отриманим набором, проте впорядкування більше не потрібно,
//ми можемо застосувати метод AsUnordered() :

//int[] numbers = new int[] { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, };
//var squares = from n in numbers.AsParallel().AsOrdered()
//              where n > 0
//              select Square(n);

//// выбираем числа больще 4 без упорядочивания результата
//var query = from n in squares.AsUnordered()
//            where n > 4
//            select n;

//foreach (var n in query)
//    Console.WriteLine(n);

//int Square(int n) => n * n;

////////////////////////////////////
// Обробка помилок та скасування операції

//При виконанні паралельних операцій можуть виникати помилки, обробка яких має свої особливості.
//При паралельній обробці колекція поділяється на частини, і кожна частина обробляється в окремому потоці.
//Однак якщо виникне помилка в одному з потоків, система перериває виконання всіх потоків.

//При генерації винятків усі вони агрегуються в одному винятку типу AggregateException

//Наприклад, нехай метод факторіалу передається масив об'єктів, який містить не тільки числа, а й рядки:

//object[] numbers = new object[] { 1, 2, 3, 4, 5, "6" };

//var squares = from n in numbers.AsParallel()
//              let x = (int)n
//              select Square(x);
//try
//{
//    squares.ForAll(n => Console.WriteLine(n));
//}
//catch (AggregateException ex)
//{
//    foreach (var e in ex.InnerExceptions)
//    {
//        Console.WriteLine(e.Message);
//    }
//}

//int Square(int n) => n * n;

///
//Запустимо проект без налагодження .
//Оскільки масив містить рядок, то спроба приведення закінчиться невдачею,
//і на консоль буде виведено повідомлення про помилку.
//Під час запуску програми Visual Studio у режимі налагодження виконання зупиниться на рядку перетворення.
//А після продовження також спрацює перехоплення виключення в блоці catch і на консоль буде виведено повідомлення про помилку.

//Переривання паралельної операції
//Цілком імовірно, що нам може знадобитися припинити операцію до її завершення.
//У цьому випадку ми можемо використовувати метод WithCancellation() ,
//якому як параметр передається токен CancellationToken :

//CancellationTokenSource cts = new CancellationTokenSource();
//// запускаем дополнительную задачу, в которой через 400 миллисек. прерываем операцию
//new Task(() =>
//{
//    Thread.Sleep(400);
//    cts.Cancel();
//}).Start();

//try
//{
//    int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };

//    var squares = from n in numbers.AsParallel().WithCancellation(cts.Token)
//                  select Square(n);

//    foreach (var n in squares)
//        Console.WriteLine(n);
//}
//catch (OperationCanceledException)
//{
//    Console.WriteLine("Операция была прервана");
//}
//catch (AggregateException ex)
//{
//    if (ex.InnerExceptions != null)
//    {
//        foreach (Exception e in ex.InnerExceptions)
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cts.Dispose();
//}
//int Square(int n)
//{
//    var result = n * n;
//    Console.WriteLine($"Квадрат числа {n} равен {result}");
//    Thread.Sleep(1000); // имитация долгого вычисления
//    return result;
//}

// У паралельній запущеній задачі викликається метод cts.Cancel(),
// що призводить до завершення операції та генерації виключення OperationCanceledException

// При цьому також має сенс обробляти виняток AggregateException,
// тому що якщо паралельно виникає ще один виняток, то це виняток,
// а також OperationCanceledException поміщаються всередину одного об'єкта AggregateException.
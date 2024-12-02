using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.UseWelcomePage();   // подключение WelcomePageMiddleware

app.MapGet("/", () => "Hello World!");

// app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));

//int x = 2;
//app.Run(async (context) =>
//{
//    x = x * 2;  //  2 * 2 = 4
//    await context.Response.WriteAsync($"Result: {x}");
//});

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
//    await response.WriteAsync("Hi World!");
//});

//app.Run(async (context) =>
//{
//    context.Response.StatusCode = 404;
//    await context.Response.WriteAsync("Resource Not Found");
//});

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2 style='color: green;'>Hello World!</h2><h3>Welcome to ASP.NET Core</h3>");
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

// app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));

app.Run(async (context) =>
{
    var path = context.Request.Path;
    var now = DateTime.Now;
    var response = context.Response;

    if (path == "/date")
        await response.WriteAsync($"Date: {now.ToShortDateString()}");
    else if (path == "/time")
        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
    else
        await response.WriteAsync("Hello World!");
});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//}); // https://localhost:7020/users?name=Tom&age=37

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

// or

//app.Run(async (context) =>
//{
//    string? name = context.Request.Query["name"];
//    string? age = context.Request.Query["age"];
//    await context.Response.WriteAsync($"{name} - {age}");
//});

//
//string date = "";

//app.Use(async (context, next) =>
//{
//    date = DateTime.Now.ToShortDateString();
//    await next.Invoke();                 // вызываем middleware из app.Run
//    Console.WriteLine($"Current date: {date}");  // Current date: 08.12.2021
//});

//app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));
//

//
//app.UseWhen(
//    context => context.Request.Path == "/time", // если путь запроса "/time"
//    appBuilder =>
//    {
//        // логгируем данные - выводим на консоль приложения
//        appBuilder.Use(async (context, next) =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            Console.WriteLine($"Time: {time}");
//            await next();   // вызываем следующий middleware
//        });

//        // отправляем ответ
//        appBuilder.Run(async context =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            await context.Response.WriteAsync($"Time: {time}");
//        });
//    });

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello World!");
//});
//

app.Run();


//Це так зване Minimal API - спрощена мінізована модель для запуску веб-програми в ASP.NET.

//Додаток в ASP.NET Core представляє об'єкт Microsoft.AspNetCore.Builder.WebApplication. 
//Цей об'єкт налаштовує всю конфігурацію програми, його маршрути, використовувані залежності і т.д.

//Для створення об'єкта WebApplication потрібен спеціальний клас-будівельник - WebApplicationBuilder. 
//І у файлі Program.cs спочатку створюється даний об'єкт за допомогою статичного методу WebApplication.CreateBuilder:

//var builder = WebApplication.CreateBuilder(args);

//В якості параметра метод передаються аргументи, які передаються додатку при запуску.

//Отримавши об'єкт WebApplicationBuilder , у нього викликається метод Build() , який власне і створює об'єкт WebApplication:

// var app = builder.Build();

// За допомогою об'єкта WebApplication можна налаштувати всю інфраструктуру програми - конфігурацію, маршрути і так далі.
// У файлі Program.cs за промовчанням для програми визначається один маршрут:

// app.MapGet("/", () => "Hello World!");

//Метод MapGet() як перший параметр приймає шлях, яким можна звернутися до додатку.
//В даному випадку це шлях "/", тобто по суті корінь веб-додатку - ім'я домену та порту, після яких може йти сліш,
//наприклад,https://localhost:7256/

//Як другий параметр метод MapGet() передаються обробник запиту по цьому маршруту у вигляді функції.
//Тут це лямбда-вираз, який повертає рядок "Hello World!".
//Саме тому при зверненні до програми ми побачимо цей рядок у браузері.

//І наприкінці необхідно запустити програму. Для цього клас WebApplication викликає метод Run():

//app.Run();

// В результаті запуститься програма у вигляді консолі, і ми зможемо звертатися до програми з різних браузерів.

////////////////////////////////////////////////////
//Структура проекту ASP.NET Core
//Розглянемо базову структуру стандартного проекту ASP.NET Core у Visual Studio.

//Проект ASP.NET Core Empty містить дуже просту структуру - необхідний мінімум для запуску програми:

//Connected Services: підключені сервіси з Azure

//Dependencies: всі додані до проекту пакети та бібліотеки, інакше кажучи залежності

//Properties: вузол, який містить деякі параметри проекту.
//Зокрема, у файлі launchSettings.json описані налаштування запуску проекту, наприклад, адреси, за якими запускатиметься програма.

//appsettings.json: файл конфігурації проекту у форматі json

//appsettings.Development.json: версія файлу конфігурації програми, яка використовується в процесі розробки

//Program.cs: головний файл програми, з якого починається його виконання.
//Код цього файлу налаштовує та запускає веб-додаток

/////////////////////////////////////////
// У центрі програми ASP.NET знаходиться клас WebApplication

//Змінна appв цьому коді представляє об'єкт WebApplication.
//Однак для створення цього об'єкта необхідний інший об'єкт - WebApplicationBuilder, який в даному коді представлений змінною builder.

// Створення програми за замовчуванням фактично починається з класу WebApplicationBuilder

// Для створення об'єкта цього класу викликається статичний метод WebApplication.CreateBuilder()
// WebApplicationBuilder builder = WebApplication.CreateBuilder();

// Для ініціалізації об'єкта WebApplicationBuilder у цей метод можуть передаватися аргументи командного рядка,
// вказані при запуску програми (доступні через неявно певний параметр args):
//WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Або можна передавати об'єкт WebApplicationOption
//WebApplicationOptions options = new() { Args = args };
//WebApplicationBuilder builder = WebApplication.CreateBuilder(options);

//Крім створення об'єкта WebApplication, клас WebApplicationBuilder виконує ще ряд завдань, серед яких можна виділити наступні:

// - Встановлення конфігурації програми

// - Додавання сервісів

// - Налаштування логування в програмі

// - Встановлення оточення програми

// - Конфігурація об'єктів IHostBuilder та IWebHostBuilder, які використовуються для створення хоста програми

// Для реалізації цих завдань у класі WebApplicationBuilder визначено такі властивості:

// - Configuration: представляє об'єкт ConfigurationManager, який застосовується для додавання конфігурації до програми.

// - Environment: надає інформацію про оточення, в якому запущено програму.

// - Host: об'єкт IHostBuilder, який застосовується для налаштування хоста.

// - Logging: дозволяє визначити налаштування логування в програмі.

// - Services: представляє колекцію сервісів та дозволяє додавати сервіси до програми.

// - WebHost: об'єкт IWebHostBuilder , який дозволяє налаштувати окремі параметри сервера.

////
// Метод build() класу WebApplicationBuilder створює об'єкт WebApplication

//WebApplicationBuilder builder = WebApplication.CreateBuilder();
//WebApplication app = builder.Build();

// Клас WebApplication застосовується керувати обробкою запиту, установки маршрутів, отримання сервісів тощо.

//Клас WebApplication застосовує три інтерфейси:

// - IHost: застосовується для запуску та зупинки хоста, який прослуховує вхідні запити

// - IApplicationBuilder: застосовується для встановлення компонентів, які беруть участь у обробці запиту

// - IEndpointRouteBuilder: застосовується для встановлення маршрутів, які зіставляються із запитами

//Для отримання доступу до функціональності програми можна використовувати властивості класу WebApplication:

// - Configuration: представляє конфігурацію програми у вигляді об'єкта IConfiguration

// - Environment: представляє оточення програми у вигляді IWebHostEnvironment

// - Lifetime: дозволяє отримувати повідомлення про події життєвого циклу програми

// - Logger: представляє логгер програми за замовчуванням

// - Services: представляє послуги програми

// - Urls: представляє набір адрес, які використовує сервер

//Для керування хостом клас WebApplication визначає такі методи:

// - Run(): запускає програму

// - RunAsync(): асинхронно запускає програму

// - Start(): запускає програму

// - StartAsync(): запускає програму

// - StopAsync(): зупиняє програму

// Таким чином, після виклику метод Run/Start/RunAsync/StartAsync додаток буде заущено, і ми зможемо до нього звертатися:

//WebApplicationBuilder builder = WebApplication.CreateBuilder();
//WebApplication app = builder.Build();
//app.Run();

// За необхідності за допомогою методу StopAsync() можна програмним способом завершити виконання програми:

//WebApplicationBuilder builder = WebApplication.CreateBuilder();

//WebApplication app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//await app.StartAsync();
//await Task.Delay(10000);
//await app.StopAsync();  // через 10 секунд завершаем выполнение приложения

///////////////////////////////////////////////////////
// Конвеєр обробки запиту та middleware

//Одне з основних завдань програми - це обробка запитів, що входять.
//Обробка запиту ASP.NET Core влаштована за принципом конвеєра, який складається з компонентів.
//Подібні компоненти ще називаються middleware

//При отриманні запиту спочатку дані запиту отримує перший компонент конвеєрі.
//Після обробки запиту компонент middleware може закінчити обробку запиту -
//такий компонент ще називається термінальним компонентом (terminal middleware ).
//Або він може передати дані запиту для обробки далі конвеєром - наступному в конвеєрі компоненту і так далі.
//Після обробки запиту останнім компонентом дані запиту повертаються до попереднього компонента.

// Дивитись зображення #images/1.png

//Компоненти middleware вбудовуються за допомогою методів розширеньRun та Mapінтерфейсу UseIApplicationBuilder.
//Клас WebApplication реалізує цей інтерфейс і тому дозволяє додавати компоненти middleware за допомогою даних методів.

//Кожен компонент middleware може бути визначений як метод (вбудований inline компонент), або може бути винесений в окремий клас.

//Для створення компонентів middleware використовується делегат RequestDelegate,
//який виконує деяку дію та приймає контекст запиту-об'єкт HttpContext:

// public delegate Task RequestDelegate(HttpContext context);

//При отриманні запиту сервер формує на його основі об'єкт HttpContext, який містить усю необхідну інформацію про запит.
//Ця інформація за допомогою об'єкта HttpContext передається всім компонентам middleware у додатку.

//Розглянемо яку інформацію ми можемо отримати з HttpContext. Для цього пройдемося за його властивостями:

// - Connection: надає інформацію про підключення, яке встановлено для даного запиту

// - Features: отримує колекцію HTTP-функціональностей, які доступні для цього запиту

// - Items: одержує або встановлює колекцію пар ключ-значення для зберігання деяких даних для поточного запиту

// - Request: повертає об'єкт HttpRequest , який зберігає інформацію про поточний запит

// - RequestAborted: повідомляє програму, коли підключення переривається, і відповідно обробка запиту має бути скасована

// - RequestServices: отримує або встановлює об'єкт IServiceProvider , який надає доступ до контейнера сервісів запиту

// - Response: повертає об'єкт HttpResponse , який дозволяє керувати відповіддю клієнту

// - Session: зберігає дані сесії для поточного запиту

// - TraceIdentifier: представляє унікальний ідентифікатор запиту для логів трасування

// - User: представляє користувача, асоційованого з цим запитом

// - WebSockets: повертає об'єкт для керування підключеннями WebSocket для цього запиту

//Використовуючи ці властивості, ми можемо в компоненті middleware отримати якщо не все,
//то більшу частину необхідних даних про запит і надіслати назад клієнту певну відповідь.

//Вбудовані компоненти middleware
//Варто зазначити, що ASP.NET Core вже за умовчанням надає ряд вбудованих компонентів middleware для задач, що часто зустрічаються:

// - Authentication: надає підтримку автентифікації

// - Authorization: надає підтримку авторизації

// - Cookie Policy: відстежує згоду користувача на зберігання пов'язаної з ним інформації в куках

// - CORS: забезпечує підтримку кросдоменних запитів.

// - DeveloperExceptionPage: генерує веб-сторінку з інформацією про помилку під час роботи в режимі розробки

// - Diagnostics: набір middleware, який надає сторінки статусних кодів, функціонал обробки винятків, сторінку виключень розробника

// - Forwarded Headers: перенаправляє заголовки запиту

// - Health Check: перевіряє працездатність програми asp.net core

// - Header Propagation: забезпечує передачу заголовків із HTTP-запиту

// - HTTP Logging: логує інформацію про вхідні запити та генеровані відповіді

// - HTTP Method Override: дозволяє вхідному запиту POST перевизначити метод

// - HTTPS Redirection: перенаправляє всі запити HTTP на HTTPS

// - HTTP Strict Transport Security (HSTS): для покращення безпеки програми додає спеціальний заголовок відповіді

// - MVC: забезпечує функціонал фреймворку MVC.

// - OWIN: забезпечує взаємодію з програмами, серверами та компонентами, побудованими на основі специфікації OWIN.

// - Request Localization: забезпечує підтримку локалізації

// - Response Caching: дозволяє кешувати результати запитів

// - Response Compression: забезпечує стиснення відповіді клієнту

// - URL Rewrite: надає функціональність URL Rewriting

// - Endpoint Routing: надає механізм маршрутизації

// - Session: надає підтримку сесій

// - SPA: обробляє всі запити, повертаючи сторінку за замовчуванням для програми SPA (односторінкової програми)

// - Static Files: надає підтримку для обробки статичних файлів.

// - WebSockets: додає підтримку протоколу WebSockets

// - W3CLogging: генерує логи доступу відповідно до формату W3C Extended Log File Format

//Для вбудовування цих компонентів у конвеєр обробки запиту для інтерфейсу IApplicationBuilder визначено методи розширення типу UseXXX.

// Наприклад, фреймворк ASP.NET Core за промовчанням надає такий middleware як WelcomePageMiddleware,
// який надсилає клієнту деяку стандартну веб-сторінку.
// Для підключення цього компонента до конвеєра запиту застосовується метод розширення UseWelcomePage()
///////////////////////////////

// Найпростіший спосіб додавання middleware до конвеєра обробки запиту в ASP.NET Core представляє метод Run(),
// який визначений як метод розширення для інтерфейсу IApplicationBuilder (відповідно його підтримує і клас WebApplication):

// IApplicationBuilder.Run(RequestDelegate handler)

//Метод Runдодає термінальний компонент – такий компонент, який завершує обробку запиту.
//Тому відповідно він не викликає жодних інших компонентів та обробки запиту далі - наступним у конвеєрі компонентам не передає.
//Тому цей метод слід викликати наприкінці побудови конвеєра обробки запиту.
//До нього можуть бути поміщені інші методи, які додають компоненти middleware.

// Як параметр метод Run приймає делегат RequestDelegate. Цей делегат має таке визначення:
// public delegate Task RequestDelegate(HttpContext context);

//Він приймає як параметр контексту запиту HttpContext і повертає об'єкт Task.

//Використовуємо цей метод для визначення найпростішого компонента:

//var builder = WebApplication.CreateBuilder();

//var app = builder.Build();

//app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));
//app.Run();

// Тут для делегата RequestDelegate передається лямбда-вираз, параметр якого – HttpContext можна використовувати для надсилання відповіді.
// Зокрема, метод context.Response.WriteAsync()дозволяє відправити клієнту певну відповідь - у цьому випадку відправляється простий рядок.

//Тут слід зробити кілька зауважень. Насамперед, не варто плутати метод Run(),
//який визначений у класі WebApplication і який запускає програму, і метод розширення Run(),
//який вбудовує компонент middleware. Це два різні методи, які виконують різні завдання. І, як видно з коду вище, викликаються обидва ці методи.

//Другий момент - метод Run() , який запускає програму, викликається після додавання компонента middleware. І ми НЕ можемо написати так:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();
//app.Run();  // приложение запущено
//// в этой строке уже нет смысла
//app.Run(async (context) => await context.Response.WriteAsync("Hello World!"));

// При необхідності природно ми можемо винести код middleware в окремий метод:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();
//app.Run(HandleRequst);
//app.Run();

//async Task HandleRequst(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello World!");
//}

//// Життєвий цикл middleware

//Компоненти middleware створюються один раз і існують протягом усього життєвого циклу програми.
//Тобто для подальшої обробки запитів використовуються ті самі компоненти.
//Наприклад, визначимо у файлі Program.cs наступний код:

//var builder = WebApplication.CreateBuilder();

//var app = builder.Build();

//int x = 2;
//app.Run(async (context) =>
//{
//    x = x * 2;  //  2 * 2 = 4
//    await context.Response.WriteAsync($"Result: {x}");
//});
//app.Run();

// При запуску програми ми природно очікуємо, що браузер виведе число 4 як результат
// Однак при наступних запитах ми побачимо, що результат змінної х не дорівнює 4, а 8
//////////////////////////////

// HttpResponse. Надсилання відповіді

// Всі дані запиту передаються в middleware через об'єкт Microsoft.AspNetCore.Http.HttpContext.
// Цей об'єкт інкапсулює інформацію про запит, дозволяє керувати відповіддю та, крім того, має ще багато іншої функціональності.

//Тут параметр context, який передається в middleware в методі app.Run()якраз представляє об'єкт HttpContext.
//І через цей об'єкт, точніше через його властивість Response ми можемо надіслати клієнту певну відповідь:
//context.Response.WriteAsync($"Hello World!").

//Властивість Response об'єкта HttpContext представляє об'єкт HttpResponse і встановлює, що отруюватиметься у вигляді відповіді.
//Для встановлення різних аспектів відповіді клас HttpResponse визначає такі властивості:

//Body: отримує або встановлює тіло відповіді як об'єкт Stream

//BodyWriter : повертає об'єкт типу PipeWriter для запису відповіді

//ContentLength : отримує або встановлює заголовокContent-Length

//ContentType : отримує або встановлює заголовокContent-Type

//Cookies : повертає куки, що надсилаються у відповіді

//HasStarted : повертає true, якщо відправка відповіді вже почалася

//Headers : повертає заголовки відповіді

//Host : отримує або встановлює заголовокHost

//HttpContext : повертає об'єкт HttpContext , пов'язаний з цим об'єктом Response

//StatusCode : повертає або встановлює статусний код відповіді

//Щоб надіслати відповідь, ми можемо використовувати низку методів класу HttpResponse:

//Redirect() : виконує переадресацію(тимчасову або постійну) на інший ресурс

//WriteAsJson()/ WriteAsJsonAsync() : надсилає відповідь у вигляді об'єктів у форматі JSON

//WriteAsync() : надсилає деякий вміст. Одна з версій методу дозволяє вказати кодування.
//Якщо кодування не вказано, за замовчуванням застосовується кодування UTF-8

//SendFileAsync() : надсилає файл

// Найпростіший спосіб відправки відповіді представляє метод WriteAsync(), який передається дані, що відправляються.
// Як додатковий параметр ми можемо вказати кодування:

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World!", System.Text.Encoding.Default);
//});

// Встановлення заголовків

//Для встановлення заголовків застосовується властивість Headers , яка представляє тип IHeaderDictionary.
//Для більшості стандартних заголовків HTTP у цьому інтерфейсі визначено однойменні властивості,
//наприклад, для заголовка "content-type" визначено властивість ContentType.
//Інші, у тому числі свої кастомні заголовки, можна додати через метод Append().
//Наприклад:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
//    await response.WriteAsync("Привет World!");
//});

//app.Run();

// Варто зазначити, що для виведення кирилиці бажано встановлювати заголовок ContentType, у тому числі кодування,
// яке застосовується в вмісті, що відправляється (у прикладі вище це "text/plain; charset=utf-8").

// Також варто зазначити, що замість
// response.Headers.ContentType = "text/plain; charset=utf-8";
// можна було б написати
// response.ContentType = "text/plain; charset=utf-8";

//// Встановлення кодів статусу
// Для встановлення статусних кодів застосовується властивість StatusCode , якому передається числовий код статусу:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    context.Response.StatusCode = 404;
//    await context.Response.WriteAsync("Resource Not Found");
//});

//app.Run();

///// Надсилання html-коду
// Якщо необхідно відправити html-код, то для цього необхідно встановити для заголовка Content-Typeзначення text/html:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2>Hello World!</h2><h3>Welcome to ASP.NET Core</h3>");
//});

//app.Run();

//////////////////////////////////
// HttpRequest. Отримання даних запиту

//Властивість Request об'єкта HttpContext представляє об'єкт HttpRequest і зберігає інформацію про запит у вигляді наступних властивостей:

// - Body: надає тіло запиту у вигляді об'єкту Stream

// - BodyReader: повертає об'єкт типу PipeReader для читання тіла запиту

// - ContentLength: отримує або встановлює заголовокContent-Length

// - ContentType: отримує або встановлює заголовокContent-Type

// - Cookies: повертає колекцію cookie (об'єкт Cookies), асоційованих з цим запитом

// - Form: отримує або встановлює тіло запиту у вигляді форм

// - HasFormContentType: перевіряє наявність заголовкаContent-Type

// - Headers: повертає заголовки запиту

// - Host: отримує або встановлює заголовокHost

// - HttpContext: повертає пов'язаний з цим запитом об'єкт HttpContext

// - IsHttps: повертає true, якщо застосовується протокол https

// - Method: отримує або встановлює метод HTTP

// - Path: отримує або встановлює шлях запиту як об'єкт RequestPath

// - PathBase: отримує або встановлює базовий шлях запиту. Такий шлях не повинен містити завершальний сліш

// - Protocol: отримує або встановлює протокол, наприклад, HTTP

// - Query: повертає колекцію параметрів із рядка запиту

// - QueryString: отримує або встановлює рядок запиту

// - RouteValues ​: отримує дані маршруту для поточного запиту

// - Scheme: отримує або встановлює схему запиту HTTP

//// Отримання заголовків запиту

// Для отримання заголовків застосовується властивість Headers , яка представляє тип IHeaderDictionary.
// Наприклад, отримаємо всі заголовки запиту та виведемо їх на веб-сторінку:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//app.Run();

// Отримання шляху запиту

// Властивість path дозволяє отримати запитаний шлях, тобто адресу, до якої звертається клієнт:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));

//app.Run();

// Властивість path дозволяє отримати запитаний шлях, тобто адресу, до якої звертається клієнт:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var now = DateTime.Now;
//    var response = context.Response;

//    if (path == "/date")
//        await response.WriteAsync($"Date: {now.ToShortDateString()}");
//    else if (path == "/time")
//        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
//    else
//        await response.WriteAsync("Hello World!");
//});

//app.Run();

////
// Властивість QueryString дозволяє отримати рядок запиту.
// Рядок запиту є частиною запитаної адреси, яка йде після символу ? і представляє набір параметрів, розділених символом амперсанда &

// Слід зазначити, що рядок запиту (query string) НЕ входить у шлях запиту (path):

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//app.Run();

// За допомогою властивості Query можна отримати всі параметри рядка запиту у вигляді словника:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//app.Run();

//////////////////////////////////////////////////////////////////////////////////////

//Метод розширення Use() додає компонент middleware, який дозволяє передати обробку запиту далі наступним компонентам в конвеєрі.
//Він має такі версії

//public static IApplicationBuilder Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware);
//public static IApplicationBuilder Use(this IApplicationBuilder app, Func<HttpContext, RequestDelegate, Task> middleware)

//Метод Use() реалізований як метод розширення типу IApplicationBuilder ,
//відповідно ми можемо викликати даний метод у об'єкта WebApplication для додавання middleware в додаток.
//В обох версіях метод Use приймає деяку дію, яка має два параметри та повертає об'єкт Task.

//Перший параметр делегата Func, який передається метод Use() , представляє об'єкт HttpContext .
//Цей об'єкт дозволяє отримати дані запиту та керувати відповіддю клієнту.

//Другий параметр делегата представляє інший делегат - Func<Task> або RequestDelegate .
//Цей делегат представляє наступний у конвеєрі компонент middleware, якому передаватиметься обробка запиту.

//У загальному випадку застосування методу Use() виглядає так:

//app.Use(async (context, next) =>
//{
//    // действия перед передачи запроса в следующий middleware
//    await next.Invoke();
//    // действия после обработки запроса следующим middleware
//});

//Робота middleware розбивається на дві частини:

//Middleware виконує деяку початкову обробку запиту перед викликомawait next.Invoke()

//Потім викликається метод next.Invoke(), який передає обробку запиту наступному компоненту конвеєрі

//Коли наступний у конвеєрі компонент закінчив обробку запит повертається назад у поточний компонент, 
//і виконуються дії, які йдуть після викликуawait next.Invoke(

//Таким чином, middleware в методі Use виконує дії до наступного в конвеєрі компонента і після нього.

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//string date = "";

//app.Use(async (context, next) =>
//{
//    date = DateTime.Now.ToShortDateString();
//    await next.Invoke();                 // вызываем middleware из app.Run
//    Console.WriteLine($"Current date: {date}");  // Current date: 08.12.2021
//});

//app.Run(async (context) => await context.Response.WriteAsync($"Date: {date}"));

//app.Run();

////////////////////////////////
// Створення гілки конвеєра. UseWhen та MapWhen

// Метод UseWhen() на підставі деякої умови дозволяє створити відгалуження конвеєра при обробці запиту:

// public static IApplicationBuilder UseWhen (this IApplicationBuilder app, Func<HttpContext,bool> predicate, Action<IApplicationBuilder> configuration);

//Як і Use(), метод UseWhen() реалізований як метод розширення типу IApplicationBuilder.

//Як параметр він приймає делегат Func>HttpContext,bool>– деяка умова, якій має відповідати запит.
//У цей делегат передається об'єкт HttpContext.
//А типом, що повертається, повинен бути тип bool- якщо запит відповідає умові,
//то повертається true, інакше повертається false.

//Останній параметр методу - делегат Action<IApplicationBuilder>представляє деякі дії над об'єктом IApplicationBuilder,
//який передається в делегат як параметр.

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.UseWhen(
//    context => context.Request.Path == "/time", // если путь запроса "/time"
//    appBuilder =>
//    {
//        // логгируем данные - выводим на консоль приложения
//        appBuilder.Use(async (context, next) =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            Console.WriteLine($"Time: {time}");
//            await next();   // вызываем следующий middleware
//        });

//        // отправляем ответ
//        appBuilder.Run(async context =>
//        {
//            var time = DateTime.Now.ToShortTimeString();
//            await context.Response.WriteAsync($"Time: {time}");
//        });
//    });

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello World!");
//});

//app.Run();

// Метод MapWhen() , як і метод UseWhen(), на підставі деякої умови дозволяє створити відгалуження конвеєра:

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.MapWhen(
//    context => context.Request.Path == "/time", // условие: если путь запроса "/time"
//    appBuilder => appBuilder.Run(async context =>
//    {
//        var time = DateTime.Now.ToShortTimeString();
//        await context.Response.WriteAsync($"current time: {time}");
//    })
//);

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello World!");
//});

//app.Run();

////////////////////
// Метод Map() застосовується для створення гілки конвеєра, яка оброблятиме запит по певному шляху.
// Цей метод реалізований як метод розширення типу IApplicationBuilder і має ряд перевантажених версій.

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/index", appBuilder =>
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
//});
//app.Map("/about", appBuilder =>
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
//});

//app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

//app.Run();

// Вкладені методи Map

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();

//app.Map("/home", appBuilder =>
//{
//    appBuilder.Map("/index", Index); // middleware для "/home/index"
//    appBuilder.Map("/about", About); // middleware для "/home/about"
//    // middleware для "/home"
//    appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));
//});

//app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

//app.Run();

//void Index(IApplicationBuilder appBuilder)
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
//}
//void About(IApplicationBuilder appBuilder)
//{
//    appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
//}

//////////////////////////////

// IWebHostEnvironment та оточення

//Для взаємодії з оточенням, у якому запущено програму, фреймфорк ASP.NET Core надає інтерфейс IWebHostEnvironment .
//Цей інтерфейс пропонує ряд властивостей, за допомогою яких ми можемо отримати інформацію про оточення:

//ApplicationName: зберігає ім'я програми

//EnvironmentName: зберігає назву середовища, в якому хостується програма

//ContentRootPath : зберігає шлях до кореневої папки програми

//WebRootPath : зберігає шлях до папки, де зберігається статичний контент програми. За промовчанням це папка wwwroot

//ContentRootFileProvider : повертає реалізацію інтерфейсу Microsoft.AspNetCore.FileProviders.IFileProvider,
//яка може використовуватися для читання файлів з папки ContentRootPath

//WebRootFileProvider : повертає реалізацію інтерфейсу Microsoft.AspNetCore.FileProviders.IFileProvider,
//який можна використовувати для читання файлів з папки WebRootPath

//При створенні ми можемо використовувати ці характеристики. Але найчастіше при розробці доведеться стикатися з
//властивістю EnvironmentName . За замовчуванням є три варіанти значень при цьому властивості:
//Development, Staging і Production. У проекті ця властивість задається
//через встановлення змінного середовища ASPNETCORE_ENVIRONMENT.
//Поточне значення даного параметра задається у файлі launchSettings.json , який знаходиться в проекті в папці Properties .

//{
//  "iisSettings": {
//    "windowsAuthentication": false,
//    "anonymousAuthentication": true,
//    "iisExpress": {
//        "applicationUrl": "http://localhost:56234",
//      "sslPort": 44384
//    }
//},
//  "profiles": {
//    "HelloApp": {
//        "commandName": "Project",
//      "dotnetRunMessages": true,
//      "launchBrowser": true,
//      "applicationUrl": "https://localhost:7256;http://localhost:5256",
//      "environmentVariables": {
//            "ASPNETCORE_ENVIRONMENT": "Development"
//      }
//    },
//    "IIS Express": {
//        "commandName": "IISExpress",
//      "launchBrowser": true,
//      "environmentVariables": {
//            "ASPNETCORE_ENVIRONMENT": "Development"
//      }
//    }
//}
//}

//Тут можна побачити, що змінна "ASPNETCORE_ENVIRONMENT" зустрічається двічі - для запуску через
//IISExpress та для запуску через Kestrel. В обох випадках вона має значення розвитку.
//Але ми можемо змінити значення цієї змінної.

//Для визначення значення цієї змінної для інтерфейсу IWebHostEnvironment визначено спеціальні методи розширення:

//IsEnvironment(string envName) : повертає true, якщо ім'я середовища дорівнює значенню параметра envName

//IsDevelopment() : повертає true, якщо ім'я середовища - Development

//IsStaging() : повертає true, якщо ім'я середовища - Staging

//IsProduction() : повертає true, якщо ім'я середовища - Production

//Ця функціональність дозволяє нам виконувати певний код залежно від того, на якій стадії знаходиться програма.
//Якщо програма в процесі розробки, то ми можемо виконувати один код,
//а при розгалуженні для повноцінного використання інший код:

//var builder = WebApplication.CreateBuilder();
//WebApplication app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.Run(async (context) => await context.Response.WriteAsync("In Development Stage"));
//}
//else
//{
//    app.Run(async (context) => await context.Response.WriteAsync("In Production Stage"));
//}
//Console.WriteLine($"{app.Environment.EnvironmentName}");

//app.Run();

//////////////////////////////////////////////
///
// Dependency Injection

// Впровадження залежностей та IServiceCollection

//Dependency injection(DI) чи впровадження залежностей представляє механізм,
//який дозволяє зробити взаємодіючі у додатку об'єкти слабопов'язаними.
//Такі об'єкти пов'язані між собою через абстракції, наприклад, через інтерфейси,
//що робить всю систему більш гнучкою, адаптованою і розширюваною.

//У центрі подібного механізму знаходиться поняття залежність – деяка сутність, від якої залежить інша сутність.


//class Logger
//{
//    public void Log(string message) => Console.WriteLine(message);
//}
//class Message
//{
//    Logger logger = new Logger();
//    public string Text { get; set; } = "";
//    public void Print() => logger.Log(Text);
//}

//Тут сутність Message, яка представляє деяке повідомлення, залежить від іншої сутності – Logger, яка представляє логер.
//У методіPrint() класу Message імітується логування тексту повідомлення шляхом виклику у об'єкта Logger методу Log,
//який виводить повідомлення на консоль. Однак тут клас Message тісно пов'язаний із класом Loger.
//Клас Message відповідає за створення об'єкта Logger. Це має низку недоліків.
//Насамперед, якщо ми захочемо замість класу Logger використовувати інший тип тип логера,
//наприклад, логгувати у файл, а чи не на консоль, нам доведеться змінювати клас Message.
//Один клас не важко змінити, але якщо в проекті таких класів багато, то поміняти у всіх клас
//Logger на інший буде важче. Крім того, клас Logger може мати свої залежності, які також може знадобитися змінити.
//У результаті такими системами важче керувати та важче тестувати.

//Щоб відв'язати об'єкт Logger від класу Message, ми можемо створити абстракцію, яка представлятиме логер,
//і передавати її ззовні в об'єкт Message:

//interface ILogger
//{
//    void Log(string message);
//}
//class Logger : ILogger
//{
//    public void Log(string message) => Console.WriteLine(message);
//}
//class Message
//{
//    ILogger logger;
//    public string Text { get; set; } = "";
//    public Message(ILogger logger)
//    {
//        this.logger = logger;
//    }
//    public void Print() => logger.Log(Text);
//}

//Тепер клас Message залежить від конкретної реалізації класу Logger - це може бути будь-яка реалізація інтерфейсу ILogger.
//Крім того, створення об'єкта логера виноситься у зовнішній код. Клас Message більше нічого не знає про логер крім того,
//що у нього є метод Log, який дозволяє логувати його текст.

//Тим не менш, залишається проблема управління подібними залежностями, особливо якщо це стосується великих додатків.
//Нерідко для встановлення залежностей у подібних системах використовуються спеціальні контейнери –
//IoC-контейнери (Inversion of Control). Такі контейнери є свого роду фабриками,
//які встановлюють залежності між абстракціями та конкретними об'єктами і, як правило, керують створенням цих об'єктів.

//Перевагою ASP.NET Core у цьому відношенні є те, що фреймворк вже за замовчуванням має вбудований контейнер
//впровадження залежностей, представлений інтерфейсом IServiceProvider . А самі залежності ще називаються сервісами,
//тому контейнер можна назвати провайдером сервісів . Цей контейнер відповідає за зіставлення залежностей
//з конкретними типами та за впровадження залежностей у різні об'єкти.

// За керування сервісами в додатку в класі WebApplicationBuilder визначено властивість Services ,
// яке представляє об'єкт IServiceCollection - колекцію сервісів:

//WebApplicationBuilder builder = WebApplication.CreateBuilder();
//IServiceCollection allServices = builder.Services;  // коллекция сервисов

//І навіть якщо ми не додаємо до цієї колекції жодних сервісів, IServiceCollection вже містить низку сервісів за замовчуванням

//Кожен сервіс у колекції IServiceCollection представляє об'єкт ServiceDescriptor , який несе деяку інформацію.
//Зокрема, найважливіші властивості цього об'єкта:

//ServiceType: тип сервісу

//ImplementationType: тип реалізації сервісу

//Lifetime : життєвий цикл сервісу

// Реєстрація вбудованих сервісів ASP.NET Core

// Наприклад
//var builder = WebApplication.CreateBuilder();
//builder.Services.AddMvc();

// Життєвий цикл залежностей

//ASP.NET Core дозволяє керувати життєвим циклом сервісів, що впроваджуються в додатку.
//З погляду життєвого циклу послуги можуть представляти один із таких типів:

//Transient: під час кожного звернення до сервісу створюється новий об'єкт сервісу.
//Протягом одного запиту може бути кілька звернень до сервісу, відповідно при кожному зверненні створюватиметься новий об'єкт.
//Подібна модель життєвого циклу найбільше підходить для легковажних сервісів, які не зберігають даних про стан

//Scoped : для кожного запиту створюється об'єкт сервісу. Тобто якщо протягом одного запиту є кілька звернень до одного сервісу,
//то при всіх цих зверненнях використовуватиметься той самий об'єкт сервісу.

//Singleton : об'єкт сервісу створюється при першому зверненні до нього,
//всі наступні запити використовують той самий раніше створений об'єкт сервісу

//Для створення кожного типу сервісу призначений відповідний метод AddTransient() , AddScoped() та AddSingleton() .

// http://sergeyteplyakov.blogspot.com/2014/11/di-vs-dip-vs-ioc.html
// http://sergeyteplyakov.blogspot.com/2012/12/di-constructor-injection.html
// http://sergeyteplyakov.blogspot.com/2013/02/di-method-injection.html
// http://sergeyteplyakov.blogspot.com/2013/01/di-property-injection.html

// https://developer.mozilla.org/en-US/docs/Web/HTTP/Status
// https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods

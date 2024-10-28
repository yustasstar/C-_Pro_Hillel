using System.Text.Json;
using System.Text.Json.Serialization;
///////////////////////////////////////////////////////////////////////
//// JSON(JavaScript Object Notation) є одним із найбільш популярних форматів для зберігання та передачі даних.
//// І платформа .NET надає функціонал для роботи із JSON.
//// Основна функціональність роботи з JSON зосереджена у просторі імен System.Text.Json.
//// Ключовим типом є клас JsonSerializer, який дозволяє серіалізувати об'єкт в json і, навпаки,
//// десеріалізувати код json в об'єкт C#.

//// Для збереження об'єкта в json у класі JsonSerializer визначено статичний метод Serialize()
//// та його асинхронний двійник SerializeAsyc(), які мають низку перевантажених версій. Деякі з них:

//// string Serialize(Object obj, Type type, JsonSerializerOptions options):
////        серіалізує об'єкт obj типу type і повертає код json у вигляді рядка.
////        Останній необов'язковий параметр options дозволяє встановити додаткові опції серіалізації
//// string Serialize<T>(T obj, JsonSerializerOptions options):
////        типізована версія серіалізує об'єкт obj типу T і повертає код json у вигляді рядка.
//// Task SerializeAsync(Stream utf8Json, Object obj, Type type, JsonSerializerOptions options):
////        серіалізує об'єкт obj типу type і записує його в потік utf8Json.
////        Останній необов'язковий параметр options дозволяє встановити додаткові опції серіалізації
//// Task SerializeAsync<T>(Stream utf8Json, T obj, JsonSerializerOptions options):
////        типізована версія серіалізує об'єкт obj типу T у потік utf8Json.

//// Для десеріалізації коду json в об'єкт C# застосовується метод Deserialize()
//// та його асинхронний двійник DeserializeAsync(), які мають різні версії. Деякі з них:

//// object? Deserialize(string json, Type type, JsonSerializerOptions options):
////        десеріалізує рядок json в об'єкт типу type та повертає десеріалізований об'єкт.
////        Останній необов'язковий параметр options дозволяє встановити додаткові опції десеріалізації
//// T? Deserialize<T>(string json, JsonSerializerOptions options):
////        десеріалізує рядок json в об'єкт типу T і повертає його.
//// ValueTask<object?> DeserializeAsync(Stream utf8Json, Type type, JsonSerializerOptions options, CancellationToken token):
////        десеріалізує дані з потоку utf8Json, який представляє об'єкт JSON, в об'єкт типу type.
////        Останні два параметри необов'язкові: options дозволяє встановити додаткові опції десеріалізації,
////        а token встановлює CancellationToken для скасування завдання. 
////        Повертається десеріалізований об'єкт, загорнутий у ValueTask
//// ValueTask<T?> DeserializeAsync<T>(Stream utf8Json, JsonSerializerOptions options, CancellationToken token):
////        десеріалізує дані з потоку utf8Json, який представляє об'єкт JSON, в об'єкт типу T.
////        Повертається десеріалізований об'єкт, обернутий у Value
//// Розглянемо застосування класу простому прикладі. Серіалізуємо та десеріалізуємо найпростіший об'єкт:

///////////////////////////////////////////////////////////////////////

//Person tom = new Person("Tom", 37);
//                                                                      // Options for the json beatificator
//string json = JsonSerializer.Serialize(tom, new JsonSerializerOptions { WriteIndented = true });
//Console.WriteLine(json);
//Person? restoredPerson = JsonSerializer.Deserialize<Person>(json);
//Console.WriteLine($"Name = {restoredPerson?.Name}; Age = {restoredPerson?.Age}"); // Name = Tom; Age = 37

//class Person
//{
//    public string Name { get; }
//    public int Age { get; set; }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// * Деякі зауваження щодо серіалізації/десеріалізації:
//// Об'єкт, який піддається десеріалізації, повинен мати: 
////    або конструктор без параметрів, 
////    або конструктор, для всіх параметрів якого в json-об'єкті, що десеріалізується, 
////    є значення (відповідність між параметрами конструктора і властивостями json-об'єкта 
////    встановлюється на основі назв, причому регістр не грає значення).
//// Серіалізації підлягають лише public характеристики об'єкта (з модифікатором public).

//// * Запис та читання файлу json:
//// Оскільки методи SerializeAsyc/DeserializeAsync можуть приймати потік типу Stream,
//// то ми можемо використовувати файловий потік для збереження і подальшого вилучення даних:
///////////////////////////////////////////////////////////////////////

//using (var fs = new FileStream("../../../user.json", FileMode.OpenOrCreate))
//{
//Person tom = new Person("Tom", 37);
//await JsonSerializer.SerializeAsync<Person>(fs, tom);                     // * сохранение данных:
//Console.WriteLine("Data has been saved to file");
//}

//using (var fs = new FileStream("../../../user.json", FileMode.OpenOrCreate))
//{
//Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);       // * чтение данных:
//Console.WriteLine($"Name: {person?.Name};  Age: {person?.Age}");
//}

//class Person
//{
//    public string Name { get; }
//    public int Age { get; set; }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// Налаштування серіалізації за допомогою JsonSerializerOptions:
//// За замовчуванням JsonSerializer серіалізує об'єкти мініміфікованого коду.
//// За допомогою додаткового параметра JsonSerializerOptions можна налаштувати механізм серіалізації/десеріалізації,
//// використовуючи властивості JsonSerializerOptions. Деякі з його властивостей:

//// AllowTrailingCommas: встановлює, чи потрібно додавати після останнього елемента в json кому. Якщо одно true, кома додається
//// DefaultIgnoreCondition: встановлює, чи серіалізуватиметься/десеріалізуватиметься в json властивості зі значеннями за умовчанням
//// IgnoreReadOnlyProperties: аналогічно встановлює, чи серіалізуватимуться властивості, призначені тільки для читання
//// WriteIndented: встановлює, чи додаватимуться в json пробіли (умовно кажучи, для краси). Якщо одно true встановлюються додаткові прогалини
///////////////////////////////////////////////////////////////////////

//var tom = new Person("Tom", 37);

//var options = new JsonSerializerOptions
//{
//    WriteIndented = true
//};
//string json = JsonSerializer.Serialize(tom, options);
//Console.WriteLine(json);
//var restoredPerson = JsonSerializer.Deserialize<Person>(json);
//Console.WriteLine(restoredPerson?.Name);

//class Person
//{
//    public string Name { get; }
//    public int Age { get; set; }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// * Налаштування серіалізації за допомогою атрибутів:
///////////////////////////////////////////////////////////////////////
//// За умовчанням серіалізації підлягають усі public характеристики.
//// Крім того, у вихідному об'єкті json усі назви властивостей відповідають назвам властивостей об'єкта C#.
//// Однак за допомогою атрибутів JsonIgnore та JsonPropertyName.
//// JsonIgnore         - дозволяє виключити із серіалізації певну властивість.
//// JsonPropertyName   - дозволяє замінювати оригінальну назву властивості.
//// Приклад використання:
///////////////////////////////////////////////////////////////////////

//var tom = new Person("Tom", 37);

//var json = JsonSerializer.Serialize(tom);
//Console.WriteLine(json);
//var person = JsonSerializer.Deserialize<Person>(json);
//Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");


//class Person
//{
//    [JsonPropertyName("firstname")]
//    public string Name { get; }
//    [JsonIgnore]
//    public int Age { get; set; }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
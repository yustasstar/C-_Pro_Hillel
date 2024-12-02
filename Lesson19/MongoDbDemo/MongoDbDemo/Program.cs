// https://www.mongodb.com/docs/drivers/csharp/current/
// https://www.mongodb.com/docs/drivers/csharp/current/usage-examples/

//MongoDB є однією з найпопулярніших баз даних, яка характеризується швидкодією, масштабованістю, відносною простотою. 
//І для мови програмування C# та платформи .NET є всі необхідні інструменти для роботи з цією СУБД.

// dotnet add package MongoDB.Driver

//ListDatabaseNames() / ListDatabaseNamesAsync() : повертає імена всіх баз даних на сервері

//ListDatabases()/ ListDatabasesAsync() : повертає інформацію про всі бази даних на сервері

//GetDatabase() : повертає базу даних у вигляді об'єкта IMongoDatabase

//DropDatabase()/ DropDatabaseAsync() : видаляє базу даних за певним ім'ям

// Наприклад, отримаємо список всіх бд на сервері MongoDB за допомогою методу ListDatabasesAsync():

//using MongoDB.Driver;

//var client = new MongoClient("mongodb://localhost:27017");

//using (var cursor = await client.ListDatabasesAsync())
//{
//    var databases = cursor.ToList();
//    foreach (var database in databases)
//    {
//        Console.WriteLine(database);
//    }
//}

////
//using (var cursor = await client.ListDatabaseNamesAsync())
//{
//    var databaseNames = cursor.ToList();
//    foreach (string databaseName in databaseNames)
//    {
//        Console.WriteLine(databaseName);
//    }
//}

// Звернення до бази даних
// получаем базу данных test
//IMongoDatabase database = client.GetDatabase("test");

// Видалення бази даних
//await client.DropDatabaseAsync("test2");

// Колекції

//Для роботи з колекціями тип IMongoDatabase надає низку методів:

//CreateCollection() / CreateCollectionAsync() : створює нову колекцію

//RenameCollection()/ RenameCollectionAsync() : перейменовує колекцію

//GetCollection() : повертає колекцію

//DropCollection()/ DropCollectionAsync() : видаляє колекцію

//ListCollections()/ ListCollectionsAsync() : повертає список усіх колекцій

//ListCollectionNames()/ ListCollectionNamesAsync() : повертає список імен усіх колекцій

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");
//var db = client.GetDatabase("test");

// Створення колекції
//try
//{
//    await db.CreateCollectionAsync("people");  // создаем коллекцию "people"
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

// Отримання списку колекцій

//var collections = await db.ListCollectionsAsync();
//foreach (var collection in collections.ToList())
//{
//    Console.WriteLine(collection);
//}

// Якщо нас цікавлять лише імена колекцій,
// ми можемо використовувати інший метод - ListCollectionNames()/ListCollectionNamesAsync() :

//var collections2 = await db.ListCollectionNamesAsync();
//foreach (var collection in collections2.ToList())
//{
//    Console.WriteLine(collection);
//}

// Перейменування колекції

//await db.RenameCollectionAsync("people", "users"); // из people в users

// Видалення колекції

// await db.DropCollectionAsync("users");  // удаляем коллекцию "users"

// Отримання колекції

//await db.CreateCollectionAsync("users"); // создаем users
//// получаем коллекцию users 
//IMongoCollection<BsonDocument> users = db.GetCollection<BsonDocument>("users");

///////////////

//Оскільки MongoDB представляє документо-орієнтовані бази даних, всі дані у ній зберігаються як документів. 
//Таким чином, база даних складається з колекцій, а колекції – з документів. 
//Кожен документ, своєю чергою, складається з елементів , 
//кожен із яких представляє пару key-value.

//На рівні драйвера MongoDB для .NET елементи представляє структура BsonElement із простору імен MongoDB.BSON . 
//Для створення та ініціалізації структури можна використовувати її конструктор, який приймає два параметри:

//public BsonElement(string name, BsonValue value)

//Перший параметр є ім'ям елемента, а другий - його значення. Причому як значення приймається об'єкт типу BsonValue . 
//Однак оскільки BsonValue - абстрактний клас, ми передаватимемо значення його спадкоємців. 
//Найбільш поширені з них:

//BsonArray: представляє масив

//BsonBinaryData: представляє набір бінарних даних

//BsonBoolean: представляє логічне значення, аналогічний типу bool

//BsonDateTime: представляє дату та час, аналогічний типу DateTime

//BsonDecimal128: представляє числове дробове значення, аналогічний типу decimal

//BsonDouble: представляє число з плаваючою точок, аналогічний типу double

//BsonInt32: представляє 32-бітове ціле значення, аналогічний типу int

//BsonInt64: представляє 64-бітове ціле значення, аналогічний типу long

//BsonNull: представляє значення null

//BsonObjectId: представляє унікальний ідентифікатор

//BsonString: представляє рядок, аналогічний типу string

//using MongoDB.Bson;

//BsonElement el = new BsonElement("name", new BsonString("Tom"));

//Console.WriteLine(el); // name = Tom
//Console.WriteLine(el.Name); // name
//Console.WriteLine(el.Value); // Tom


//BsonElement nameElement = new BsonElement("name", "Tom");
//BsonElement ageElement = new BsonElement("age", 38);

//Console.WriteLine(nameElement); // name = Tom 
//Console.WriteLine(ageElement); // age = 38

// Колекції в базах даних зберігають документи, які представлені класом BsonDocument із простору імен MongoDB.BSON .

//using MongoDB.Bson;

//// v1
//BsonElement name = new BsonElement("name", "Tom");
//BsonDocument doc = new BsonDocument(name);

//Console.WriteLine(doc); // { "name" : "Tom" }

// v2
//BsonDocument doc = new BsonDocument
//{
//    {"name","Tom"},
//    {"age", 38},
//    { "company", new BsonDocument{{"name" , "microsoft"}}},
//    {"languages", new BsonArray{"english", "german", "spanish" } }
//};

//Console.WriteLine(doc);

// v3
//BsonDocument doc = new BsonDocument
//{
//    {"name","Tom"},
//    {"age", 38},
//    { "company",new BsonDocument{{"name" , "microsoft"}}},
//    {"languages", new BsonArray{"english", "german", "spanish" } }
//};
//// получаем значение поля name
//Console.WriteLine(doc["name"]);         // Tom
//// получаем значение поля languages
//Console.WriteLine(doc["languages"]);    // [english, german, spanish]

//// изменяем значение поля age
//doc["age"] = 22;
//Console.WriteLine(doc["age"]);      // 22

// 
//Керування елементами
//За допомогою методів класу BsonDocument ми можемо керувати елементами всередині документа:

//Add() : додає елемент до документа

//AddRange() : додає набір елементів до документа

//Clear() : видаляє всі елементи документа

//Contains() : повертає true, якщо документ містить елемент з певним ім'ям

//ContainsValue() : повертає true, якщо документ містить елемент з певним значенням

//GetValue() : повертає значення певного елемента на ім'я або на позицію

//Remove() : видаляє елемент із документа

//using MongoDB.Bson;

//BsonDocument doc = new BsonDocument { { "name", "Bob" } };

//BsonElement email = new BsonElement("email", "bob@localhost.com");
//// добавляем элемент email
//doc.Add(email);

//Console.WriteLine(doc);    // { "name" : "Bob", "email" : "bob@localhost.com" }


//// удаляем элемент name
//doc.Remove("name");
//Console.WriteLine(doc);  // { "email" : "bob@localhost.com" }

////////////

// Моделі даних

//using MongoDB.Bson;
//using MongoDB.Bson.Serialization;

//Person person = new Person { Name = "Tom", Age = 38 };
//person.Company = new Company { Name = "Microsoft" };

//Console.WriteLine(person.ToJson());

////
//BsonDocument doc = new BsonDocument
//{
//    {"Name","Tom"},
//    {"Age", 38},
//    {"Company", new BsonDocument{ {"Name" , "Microsoft"}} },
//    {"Languages", new BsonArray{"english", "german", "spanish"} }
//};
//Person person2 = BsonSerializer.Deserialize<Person>(doc);
//Console.WriteLine(person2.ToJson());

////
//Person person3 = new Person
//{
//    Name = "Tom",
//    Age = 38,
//    Company = new Company { Name = "Microsoft" },
//    Languages = { "english", "german", "spanish" }
//};

//BsonDocument doc2 = person3.ToBsonDocument();
//Console.WriteLine(doc2);

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string? Name { get; set; }
//    public int Age { get; set; }
//    public Company? Company { get; set; }
//    public List<string>? Languages { get; set; } = new List<string>();
//}
//class Company
//{
//    public string? Name { get; set; }
//}

/////////////
// Налаштування моделі за допомогою атрибутів

//using MongoDB.Bson;
//using MongoDB.Bson.Serialization;
//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Bson.Serialization.Conventions;

//// Для налаштування зіставлення класів C# з колекціями MongoDB можна використовувати клас BsonClassMap ,
//// який реєструє принципи зіставлення. 

//BsonClassMap.RegisterClassMap<Person>(cm =>
//{
//    cm.AutoMap();
//    cm.MapMember(p => p.Name).SetElementName("username");
//});
//Person tom = new Person { Name = "Tom", Age = 38 };
//Console.WriteLine(tom.ToBsonDocument()); // { "username" : "Tom", "Age" : 38 }

////За допомогою методу RegisterClassMap() визначається карта зіставлення об'єктів Person та BsonDocument. 
////Зокрема, в даному випадку для властивості Name буде зіставлятися з полем username.

////
//// Конвенції поряд з атрибутами та BsonClassMap представляють ще один спосіб визначення
//// зіставлення класів та об'єктів BsonDocument. Конвенції визначаються у вигляді набору-об'єкта ConventionPack .
//// Цей об'єкт може містити набір конвенцій. Кожна конвенція представляє об'єкт класу, похідного від ConventionBase.
//// Наприклад, переведемо всі імена елементів у BsonDocument в нижній регістр:

//var conventionPack = new ConventionPack
//{
//    new CamelCaseElementNameConvention()
//};
//ConventionRegistry.Register("camelCase", conventionPack, t => true);
//Person tom1 = new Person { Name = "Tom", Age = 38 };
//Console.WriteLine(tom1.ToBsonDocument()); // { "name" : "Tom", "age" : 38 }

//class Person
//{
//    [BsonId] // Встановлення Id
//    public int PersonId { get; set; }
//    public string Name { get; set; } = "";
//    [BsonIgnore] // Виняток властивостей
//    public string Email { get; set; } = "";
//    [BsonElement("Login")] // BsonElement
//    public string UserName { get; set; } = "";
//    [BsonIgnoreIfDefault] // Ігнорування значень за умовчанням
//    public int Age { get; set; }
//    [BsonIgnoreIfNull]
//    public Company? Company { get; set; }
//    [BsonRepresentation(BsonType.String)] // BsonRepresentation відповідає за представлення якості у базі даних.
//    public int Phone { get; set; }
//}

//class Company
//{
//    public string Name { get; set; } = "";
//}

/////////////////////////

// Збереження документів до бази даних

// Для додавання даних до колекції об'єкта IMongoCollection застосовуються методи:
// InsertOneAsync (для додавання одного документа) і InsertManyAsync() (для додавання набору документів).

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users 
//var users = db.GetCollection<BsonDocument>("users");
//// документ для добавления
//BsonDocument tom = new BsonDocument
//{
//    {"Name", "Tom"},
//    {"Age", 38}
//};

//// добавляем в коллекцию users документ
//await users.InsertOneAsync(tom);

//Console.WriteLine(tom);

////

//// документы для добавления
//BsonDocument bob = new BsonDocument { { "Name", "Bob" }, { "Age", 42 } };
//BsonDocument sam = new BsonDocument { { "Name", "Sam" }, { "Age", 25 } };

//// добавляем в коллекцию users список документов
//await users.InsertManyAsync(new List<BsonDocument> { bob, sam });

//Console.WriteLine(bob);
//Console.WriteLine(sam);

///////

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users 
//// коллекция типизируется типом Person
//var users = db.GetCollection<Person>("users");
//// объект для добавления
//Person alice = new Person { Name = "Alice", Age = 33 };

//// добавляем в коллекцию users
//await users.InsertOneAsync(alice);

//Console.WriteLine(alice.Id);  // получаем сгенерированный Id

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }
//}

//////////////////

// Отримання документів із бази даних

// Для отримання документів із бази даних застосовуються методи Find()/FindAsync() ,
// які визначені в інтерфейсі IMongoCollection. Як обов'язковий параметр ці методи приймають об'єкт BsonDocument,
// який визначає критерії запиту.

// Метод Find()повертає об'єкт IFindFluent . Для отримання результату вибірки з цього об'єкта можна
// використовувати методи ToList()/ ToListAsync() , які повертають список документів, що витягли з колекції. 

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users
//var collection = db.GetCollection<BsonDocument>("users");
//// получаем список всех данных
//List<BsonDocument> users = await collection.Find(new BsonDocument()).ToListAsync();

//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// Метод FindAsync()надає результат у вигляді об'єкта IAsyncCursor , який є курсором, який здійснює перебір об'єктів.
// Застосувавши методи ToList()/ToListAsync()також можна отримати список об'єктів:

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users
//var collection = db.GetCollection<BsonDocument>("users");
//// получаем курсор
//using var cursor = await collection.FindAsync(new BsonDocument());
//// из курсора получаем список данных
//List<BsonDocument> users = cursor.ToList();

//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

//
// or
// var users = await collection.Find("{}").ToListAsync();

//////////////////
// Отримання об'єктів класів

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users
//var collection = db.GetCollection<Person>("users");
//// получаем курсор
//using var cursor = await collection.FindAsync(new BsonDocument());
//// из курсора получаем список данных
//List<Person> users = cursor.ToList();

//foreach (var user in users)
//{
//    Console.WriteLine($"{user.Name} - {user.Age}");
//}

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }
//}

// v2
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//// получаем базу данных test
//var db = client.GetDatabase("test");
//// получаем из бд коллекцию users
//var collection = db.GetCollection<Person>("users");
//// получаем список данных
//List<Person> users = await collection.Find(new BsonDocument()).ToListAsync();

//foreach (var user in users)
//{
//    Console.WriteLine($"{user.Name} - {user.Age}");
//}

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }
//}

// v3
//using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Person>("users");

//var users = await collection.Find("{}").ToListAsync();
//foreach (var user in users) Console.WriteLine(user.Name);

//[BsonIgnoreExtraElements]
//class Person
//{
//    public string Name { get; set; } = "";
//}

// v4
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//long count = await collection.CountDocumentsAsync(new BsonDocument());
//Console.WriteLine(count);

//// or
//long count = await collection.Find(new BsonDocument()).CountDocumentsAsync();

//// or
//long count = await collection.CountDocumentsAsync(new BsonDocument("Name", "Tom"));

////////////////////

// Фільтрування даних

// При вибірці даних методи Find()/FindAsync() передається об'єкт BsonDocument, який встановлює параметри фільтрації.
// Порожній BsonDocument дозволяє вибрати всі документи. Але ми можемо конкретизувати вибірку.

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - находим все документы, где Name = "Tom"
//var filter = new BsonDocument { { "Name", "Tom" } };

//List<BsonDocument> users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// v2
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - находим все документы, где Name = "Tom" и "Age" = 33
//var filter = new BsonDocument { { "Name", "Tom" }, { "Age", 33 } };

//List<BsonDocument> users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

//Оператори вибірки
//Крім використання властивостей, ми також можемо застосовувати у фільтрах спеціальні умовні оператори. 
//Вони задають умову, якій має відповідати значення поля документа:

//$eq(рівно)

//$ne(не дорівнює)

//$gt(більше ніж)

//$lt(менше ніж)

//$gte(більше чи одно)

//$lte(менше чи одно)

//$in визначає масив значень, одне з яких повинно мати поле документа

//$nin визначає масив значень, які повинні мати поле документа

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - находим все документы, где Name != "Tom"
//var filter = new BsonDocument { { "Name", new BsonDocument("$ne", "Tom") } };

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// more examples:

// var filter = new BsonDocument { { "Name", new BsonDocument("$ne", "Tom") } };
//var filter = new BsonDocument { { "Age", new BsonDocument("$gt", 33) } };
//var users = await collection.Find(filter).ToListAsync();
//var filter = new BsonDocument { { "Age", new BsonDocument("$gt", 33) }, { "Name", new BsonDocument("$ne", "Tom") } };
//var filter = new BsonDocument { { "Age", new BsonDocument("$in", new BsonArray { 33, 25 }) } };

//Логічні оператори
//Логічні оператори виконуються за умовами вибірки:

//$or: з'єднує дві умови, і документ повинен відповідати одній з цих умов

//$and: з'єднує дві умови, і документ повинен відповідати обом умовам

//$not: документ повинен НЕ відповідати умові

//$nor : з'єднує дві умови, і документ повинен не відповідати обом умовам

// examples:

// v1

//var filter = new BsonDocument("$or", new BsonArray{

//    new BsonDocument("Age",new BsonDocument("$gte", 33)),
//    new BsonDocument("Name", "Tom")
//});

//var users = await collection.Find(filter).ToListAsync();

//// v2
//var filter = new BsonDocument("$and", new BsonArray{

//    new BsonDocument("Age",new BsonDocument("$gte", 33)),
//    new BsonDocument("Name", "Tom")
//});

//var users = await collection.Find(filter).ToListAsync();

//
// Перевірити відсутність поля. Оператор $exists

//using MongoDB.Bson;

//var filter = new BsonDocument("Languages", BsonNull.Value); // где Languages отсутствует

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// more examples:
// var filter = new BsonDocument("Languages", new BsonDocument { {"$ne", BsonNull.Value } });
//var filter = new BsonDocument("Languages", new BsonDocument { { "$exists", false } });
//var filter = new BsonDocument("Languages", new BsonDocument { { "$exists", true } });

// Пошук по масивам

//Ряд операторів призначені для роботи з масивами:

//$all: визначає набір значень, які мають бути в масиві

//$size : визначає кількість елементів, які мають бути в масиві

//$elemMatch : визначає умову, якою повинні відповідати елементи в масиві

//using MongoDB.Bson;

//var filter = new BsonDocument("Languages", new BsonDocument { { "$all", new BsonArray { "english", "spanish" } } });

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// Відповідність регулярному виразу. Оператор $regex

//using MongoDB.Bson;

//var filter = new BsonDocument("Name", new BsonDocument { { "$regex", "m$" } });

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

////

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Person>("users");

//// определяем фильтр - находим все документы, где Name = "Tom"
//var users = await collection.Find(new BsonDocument("Name", "Tom")).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine($"{user.Name} - {user.Age}");
//    if (user.Languages != null)
//        Console.WriteLine(string.Join(",", user.Languages));
//}

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }

//    public List<string>? Languages { get; set; }
//}

/////////////////////////

// FilterDefinitionBuilder та визначення фільтрів


//Операції порівняння
//Eq : вибирає ті документи, у яких значення певного поля дорівнює деякому значенню

//Ne : вибирає ті документи, у яких значення певного поля не дорівнює деякому значенню

//Gt : вибирає лише ті документи, у яких значення певного поля більше певного значення

//Gte : вибирає лише ті документи, у яких значення певного поля більше або дорівнює деякому значенню

//Lt : вибирає лише ті документи, у яких значення певного поля менше деякого значення

//Lte : вибирає лише ті документи, у яких значення певного поля менше або дорівнює деякому значенню

//In : отримує всі документи, у яких значення поля може приймати одне із зазначених значень

//Nin : протилежність оператору In- вибирає всі документи, у яких значення поля не набуває одного із зазначених значень

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");
//// определяем построитель фильтров
//var builder = Builders<BsonDocument>.Filter;

//// определяем фильтр - находим все документы, где Name = "Tom"
//var filter = builder.Eq("Name", "Tom");

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

// v2
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Person>("users");

//var builder = Builders<Person>.Filter;
//var filter = builder.Eq("Name", "Tom");

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user.Name);
//}

//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }

//    public List<string>? Languages { get; set; }
//}

//Логічні операції
//За допомогою стандартних операцій програмування кон'юнкції, диз'юнкції та логічного заперечення,
//а також відповідних методів можна комбінувати запити:

//Операція! та метод Not повертають документи, які НЕ відповідають певній умові.

//Операція | і метод Or повертають документи, які відповідають щонайменше одному з фільтрів з набір.

//Операція & та метод And повертають документи, які відповідають усім фільтрам із набору

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var builder = Builders<BsonDocument>.Filter;
//var filter = builder.Or(builder.Eq("Name", "Tom"), builder.Gte("Age", 33));

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

///
//Операції з елементами
//Exists : вибирає з бд ті документи, в яких є певне поле

//NotExists : вибирає з бд ті документи, в яких немає певного поля

//using MongoDB.Bson;
//using MongoDB.Driver;
/////
//var builder = Builders<BsonDocument>.Filter;
//var filter = builder.Exists("Languages");

// Метод Regex

//using MongoDB.Bson;
/////
//using MongoDB.Driver;
/////
//var builder = Builders<BsonDocument>.Filter;
//var filter = builder.Regex("Name", new BsonRegularExpression("m$"));

// Метод Where

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var builder = Builders<BsonDocument>.Filter;
//var filter = builder.Where(d => d["Age"] < 30);

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

//Операції з масивами
//All : вибирає всі документи, які містять всі елементи масиву

//Size : вибирає всі документи, які містять певну кількість елементів

//using MongoDB.Bson;
//using MongoDB.Driver;
/////
//var builder = Builders<BsonDocument>.Filter;
//var filter = builder.All("Languages", new string[] { "english", "spanish" });

//var users = await collection.Find(filter).ToListAsync();
//foreach (var user in users)
//{
//    Console.WriteLine(user);
//}

/////////////////////////

// Сортування

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var users = await collection.Find(new BsonDocument { }).Sort(new BsonDocument("Age", 1)).ToListAsync();

//foreach (var user in users) Console.WriteLine(user);

// v2
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");
//// сортировка по полю Name
//var users = await collection.Find("{}").SortBy(d => d["Name"]).ToListAsync();

//foreach (var user in users) Console.WriteLine(user);

// v3
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Person>("users");

//var users = await collection.Find("{}")
//    .SortBy(p => p.Name)              // сортировка по возрастанию по Name
//    .ToListAsync();
//foreach (var user in users) Console.WriteLine($"{user.Name} - {user.Age}");


//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }

//    public List<string>? Languages { get; set; }
//}

// v4 Клас SortDefinitionBuilder дозволяє послідовно застосувати декілька критеріїв сортування:
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// сначала сортируем по Name во возврастанию, а затем по Age по убыванию
//var sortDefinition = Builders<BsonDocument>.Sort.Ascending("Name").Descending("Age");
//var users = await collection.Find("{}").Sort(sortDefinition).ToListAsync();

//foreach (var user in users) Console.WriteLine(user);

// v5
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Person>("users");

//// сначала сортируем по Name во возврастанию, а затем по Age по убыванию
//var sortDefinition = Builders<Person>.Sort.Ascending(p => p.Name).Descending(p => p.Age);
//var users = await collection.Find("{}").Sort(sortDefinition).ToListAsync();

//foreach (var user in users) Console.WriteLine($"{user.Name} - {user.Age}");


//class Person
//{
//    public ObjectId Id { get; set; }
//    public string Name { get; set; } = "";
//    public int Age { get; set; }

//    public List<string>? Languages { get; set; }
//}

// or
// var users = await collection.Find("{}").Sort("{Name:1, Age:-1}").ToListAsync();

//////////////////////
// Отримання одного документа та частини колекції

//Отримання одного документа
//Для отримання документа застосовуються методи 
//First()/ FirstAsync(), 
//Single() / SingleAsync(), 
//FirstOrDefault() / FirstOrDefaultAsync(), 
//SingleOrDefault() / SingleOrDefaultAsync().
//При цьому якщо вибірка не містить документів, то методи First()/ FirstAsync() / Single() / SingleAsync() генерують виняток, 
//а FirstOrDefault()/ FirstOrDefaultAsync() / SingleOrDefault() / SingleOrDefaultAsync()повертають значення за замовчуванням.

// отримаємо один документ
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// получаем первый документ
//var user = await collection.Find("{}").FirstAsync();
//Console.WriteLine(user);

//// получаем первый документ, у которого Age = 33
//var user33 = await collection.Find(new BsonDocument("Age", 33)).FirstAsync();
//Console.WriteLine(user33);

// Метод Skip() пропускає при вибірці певну кількість документів. Наприклад, пропустимо 3 перші документи:

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// пропускаем 3 первых документа
//var users = await collection.Find("{}").Skip(3).ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

//// метод Limit() встановлює максимальну кількість документів, які можна отримати. Наприклад, отримаємо перші три документи:

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// выбираем 3 первых документа
//var users = await collection.Find("{}").Limit(3).ToListAsync();
//foreach (var user in users) Console.WriteLine(user);


//// using MongoDB.Driver;

//using MongoDB.Bson;
/////
//using MongoDB.Driver;
/////
//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// пропускаем 3 первых документа
//var users = await collection.Find("{}").Skip(3).ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

//// метод Limit() встановлює максимальну кількість документів, які можна отримати. Наприклад, отримаємо перші три документи:

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// выбираем 3 первых документа
//var users = await collection.Find("{}").Limit(3).ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

// Якщо необхідно витягти документи з кінця колекції, перед вилученням можна провести сортування:

//var users = await collection.Find("{}")
//    .Sort("{_id:-1}")    // сортировка по убыванию по полю _id
//    .Limit(3)       // извлекаем последние 3 документа
//    .ToListAsync();

// Посторінкова навігація
// Комбінація методів Skip()дозволяє Limit()вилучити певну частину колекції. Наприклад, отримаємо з 3 по 5 документи:

//var users = await collection.Find("{}")
//    .Skip(2)        // пропускаем 2 документа
//    .Limit(3)       // извлекаем следующие 3 документа
//    .ToListAsync();

//////////////////////////////

// Проекція

//Якщо документи мають складну структуру, яка нам не дуже підходить для виведення, ми можемо використовувати проекції, 
//тобто з початкових документів колекції отримати зовсім інші дані. Для створення проекції використовується 
//будівельник проекції Builders.Projection . Цей клас надає два методи для керування проекцією:

//Include() : додає поле у ​​вихідний результат

//Exclude() : виключає поле з вихідного результату

//Ці методи повертають визначення проекції у вигляді об'єкта ProjectionDefinition

//Для виконання самої проекції викликається метод Projection() , який передається об'єктProjectionDefinition

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var projection = Builders<BsonDocument>.Projection.Include("Name").Include("Age").Exclude("_id");
//var users = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

//foreach (var user in users) Console.WriteLine(user);

//
// var projection = Builders<BsonDocument>.Projection.Include("Name").Include("Age").Exclude("_id");
// var users = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

// v2
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var users = await collection.Find("{}").Project("{Name:1, Age:1, _id:0}").ToListAsync();

//foreach (var user in users) Console.WriteLine(user);

// v3
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var users = await collection.Find("{}")
//    .Project(doc => new Person(doc["Name"].ToString()))
//    .ToListAsync();

//foreach (var user in users)
//    Console.WriteLine(user.Name);


//record Person(string? Name);

//////////////////////////
// Угруповання

// Угруповання дозволяє згрупувати документи у вибірці за певним критерієм.
// Для угруповання об'єкта IMongoCollection застосовується метод Aggregate,
// а його результат - об'єкта IAggregateFluent викликається метод Group() .

// v1
//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("employees");

//var employees = await collection.Aggregate()
//    .Group(new BsonDocument {
//        { "_id", "$Company.Title" },               // группируем по имени компании
//        { "count", new BsonDocument("$sum", 1) }, // получаем количество документов в группе
//    })
//    .ToListAsync();

//foreach (var employeeGroup in employees)
//    Console.WriteLine(employeeGroup);

//Доступні оператори:

//$sum обчислює суму

//$avg обчислює середнє значення

//$first отримує значення поля з першого документа групи

//$last отримує значення поля з останнього документа групи

//$max обчислює максимальне значення

//$min обчислює мінімальне значення

//$push додає значення масив

//$addToSet додає значення до набору

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<Employee>("employees");


//var companies = await collection.Aggregate()
//    .Group(emp => emp.Company!.Title,   // группировка по свойству Company.Title
//    g => new     // из группы создаем анонимный объект
//    {
//        CompanyName = g.Key,
//        Employees = g.Select(e => e.Name).ToList(), // выбираем в список имена сотрудников
//        SumAge = g.Sum(e => e.Age),
//        MinAge = g.Min(e => e.Age),
//        MaxAge = g.Max(e => e.Age),
//        AvgAge = g.Average(e => e.Age),
//        First = g.First().Name,
//        Lass = g.Last().Name
//    })
//    .ToListAsync();

//foreach (var company in companies)
//{
//    Console.WriteLine(company.ToJson());
//}

//record Employee(ObjectId Id, string Name, int Age, Company? Company);
//record Company(string Title);

///////////////////////////
// Редагування документів

//Для редагування документів колекції застосовується низка методів:

//ReplaceOne() / ReplaceOneAsync() : повністю замінює один документ іншим

//UpdateOne()/ UpdateOneAsync() : оновлює один документ

//UpdateMany()/ UpdateManyAsync() : оновлює набір документів

//FindOneAndReplace()/ FindOneAndReplaceAsync() : якщо знаходить документ, 
//який відповідає фільтру, то замінює його та повертає замінний документ

//ReplaceOne()/ ReplaceOneAsync() : повністю замінює один документ іншим

//Вони мають різні версії, приймають різні параметри. Але всі вони як мінімум приймають два параметри:

//Фільтр, який дозволяє фільтрувати документи для оновлення

//новий документ, який замінює старий або описує принципи зміни старого

//При оновленні слід враховувати, що ми не можемо змінити поле _id.

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - документ, где Name = Tom и Age = 33
//var filter = new BsonDocument { { "Name", "Tom" }, { "Age", 33 } };
//// определяем документ, на который будет заменять
//var newDocument = new BsonDocument { { "Name", "Tomas" }, { "Age", 34 } };
//// выполняем замену
//var result = await collection.ReplaceOneAsync(filter, newDocument);

//Console.WriteLine($"Найдено по соответствию: {result.MatchedCount}; обновлено: {result.ModifiedCount}");

//// проверяем - выводи документы после обновления
//var users = await collection.Find("{}").ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

// Вставка документа

//using MongoDB.Bson;
//using MongoDB.Driver;
//using System.Text.Json;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - документ, где Name = Alex и Age = 33
//var filter = new BsonDocument { { "Name", "Alex" }, { "Age", 33 } };
//// определяем документ, на который будет заменять
//var newDocument = new BsonDocument { { "Name", "Alexander" }, { "Age", 34 } };
//// выполняем замену, если документ не найден, то вставку
//var result = await collection.ReplaceOneAsync(filter, newDocument, new ReplaceOptions { IsUpsert = true });

//Console.WriteLine($"Matched: {result.MatchedCount}; Modified: {result.ModifiedCount}; UpsertedId: {result.UpsertedId}");

//var users = await collection.Find("{}").ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

// UpdateOneAsync

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//// определяем фильтр - документ, где Name = Tom
//var filter = new BsonDocument("Name", "Tom");
//// определяем параметры обновления - обновляем только поле Age
//var updateSettings = new BsonDocument("$set", new BsonDocument("Age", 39));
//// выполняем обновление
//var result = await collection.UpdateOneAsync(filter, updateSettings);

//Console.WriteLine($"Matched: {result.MatchedCount}; Modified: {result.ModifiedCount}");

//var users = await collection.Find("{}").ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

// Видалення поля

// Для видалення окремого поля використовується оператор $unset . Наприклад, видалимо поле "Age":

//using MongoDB.Bson;
/////
//var result = await collection.UpdateOneAsync(
//    new BsonDocument("Name", "Alexander"),
//    new BsonDocument("$unset", new BsonDocument("Age", 1)));

// Відновлення масивів. Оператор $push

//using MongoDB.Bson;
/////
//var result = await collection.UpdateOneAsync(
//    new BsonDocument("Name", "Sam"),
//    new BsonDocument("$push", new BsonDocument { { "Languages", "english" } }));

// Оператор $addToSet

// Оператор $addToSet подібно до оператора $push додає об'єкти в масив. Відмінність полягає в тому, що $addToSet додає дані, якщо їх ще немає в масиві $push.

//using MongoDB.Bson;
/////
//var result = await collection.UpdateOneAsync(
//    new BsonDocument("Name", "Sam"),
//    new BsonDocument("$addToSet", new BsonDocument("Languages", "italian")));

// Видалення елемента з масиву

//using MongoDB.Bson;
/////
//var result = await collection.UpdateOneAsync(
//    new BsonDocument("Ім'я", "Сем"),
//    new BsonDocument("$pop", new BsonDocument("Мови", 1)));

// Дещо іншу дію передбачає оператор $pull . Він видаляє кожне входження елемента до масиву.
// Наприклад, через оператор $push ми можемо додати те саме значення масив кілька разів. І тепер за допомогою $pull видалимо його:

//using MongoDB.Bson;
/////
//var result = await collection.UpdateOneAsync(
//    new BsonDocument("Name", "Sam"),
//    new BsonDocument("$pull", new BsonDocument("Languages", "german")));

//using MongoDB.Bson;
/////
//using MongoDB.Driver;
/////
//UpdateDefinitionBuilder
//Для оновлення документів замість BsonDocument можна використовувати об'єкт UpdateDefinitionBuilder , у якого визначається ряд методів, що відповідають консольним операторам mongodb:

//Set : змінює значення поля

//AddToSet : додає нові елементи до поля документа, яке представляє масив. Наприклад, додаємо в масив Languages ​​новий рядок:Builders<BsonDocument>.Update.AddToSet("Languages", "spanish")

//Inc: інкрементує значення числової властивості на вказану кількість одиниць. Наприклад, збільшимо значення властивості Age на дві одиниці: Builders<BsonDocument>.Update.Inc("Age", 2)

//Mul: помножує значення числової властивості на вказане число

//Push : додає нові елементи ключа, який представляє масив. Наприклад:Builders<BsonDocument>.Update.Push("Languages", "french")

//Pull: видаляє певний елемент з масиву. Наприклад:Builders<BsonDocument>.Update.Pull("Languages", "french")

//Unset: видаляє ключ та його значення. Наприклад:Builders<BsonDocument>.Update.Unset("Age")

//PopFirst: вибирає перший елемент для властивості, яку представляє масив

//PopLast : вибирає останній елемент для властивості, яку представляє масив

//Rename : перейменовує назву ключа документа. Наприклад, перейменуємо поле Age у Year: Builders<BsonDocument>.Update.Rename("Age", "Year");.

/////////////////////
// Видалення документів

// Для видалення документів застосовуються методи DeleteOne()/DeleteOneAsync() та DeleteMany()/DeleteManyAsync() ,
// визначені в інтерфейсі IMongoCollection. Як параметр вони приймають фільтр, який визначає документ видалення.

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");
//// удаляем документ с Name="Sam"
//var result = await collection.DeleteOneAsync(new BsonDocument("Name", "Sam"));
//Console.WriteLine($"Удалено документов: {result.DeletedCount}");

//var users = await collection.Find("{}").ToListAsync();
//foreach (var user in users) Console.WriteLine(user);

// Додатково для видалення одного об'єкта можна використовувати методи FindOneAndDelete()/FindOneAndDeleteAsync() .
// Вони приймають щонайменше один параметр – фільтр документів для видалення.
// І, документ для видалення знайдено, видаляють його і повертають як результат. Якщо документа не знайдено, то повертається null.

//using MongoDB.Bson;
//using MongoDB.Driver;

//MongoClient client = new MongoClient("mongodb://localhost:27017");

//var db = client.GetDatabase("test");
//var collection = db.GetCollection<BsonDocument>("users");

//var result = await collection.FindOneAndDeleteAsync(new BsonDocument("Name", "Tom"));
//if (result == null)
//    Console.WriteLine("Документы не найдены");
//else
//    Console.WriteLine($"Удален документ: {result}");


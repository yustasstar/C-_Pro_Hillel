///////////////////////////////////////////////////////////////////////
//// На сьогоднішній день XML є одним із найпоширеніших стандартів документів,
//// який дозволяє у зручній формі зберігати складні за структурою дані.
//// Тому розробники платформи .NET увімкнули у фреймворк широкі можливості для роботи з XML.
//// Перш ніж перейти безпосередньо до роботи з XML-файлами, спочатку розглянемо,
//// що є xml-документом і як він може зберігати об'єкти, що використовуються в програмі на c#.
///////////////////////////////////////////////////////////////////////

/*
<?xml version="1.0" encoding="utf-8" ?>
<people>
  <person name="Tom">
    <company>Microsoft</company>
    <age>37</age>
  </person>
  <person name="Bob">
    <company>Google</company>
    <age>41</age>
  </person>
</people>
*/

///////////////////////////////////////////////////////////////////////
//// XML - документ повідомляє рядок<?xml version="1.0" encoding="utf-8" ?>.
//// Вона задає версію (1.0) та кодування(utf-8) xml.Далі йде власне вміст документа.
//// XML-документ повинен мати один єдиний кореневий елемент, всередину якого містяться всі інші елементи.
//// В даному випадку таким елементом є <people>. Всередині кореневого елемента <people> встановлено набір елементів <person>.
//// Поза кореневим елементом ми не можемо розмістити елементи person.
//// Кожен елемент визначається за допомогою тега, що відкриває і закриває, наприклад, <person> і </person>,
//// всередині яких міститься значення або вміст елементів. Також елемент може мати скорочене оголошення:
//// <person/> -в кінці елемента міститься сліш.
//// Елемент може мати вкладені елементи та атрибути. В даному випадку кожен елемент person має два вкладені
//// елементи company і age та атрибут name.
//// Атрибути визначаються в тілі елемента та мають таку форму: назва = "значення".Наприклад,
//// <person name = "Bill Gates">, в даному випадку атрибут називається name і має значення Bill Gates
//// Усередині простих елементів міститься їхнє значення. Наприклад, <company>Google</company> -
//// елемент company має значення Google.
//// Назви елементів є реєстрозалежними, тому <company> і <COMPANY> будуть представляти різні елементи.
//// Таким чином, весь список Users з коду C# зіставляється з кореневим елементом <people>, кожен об'єкт
//// Person - з елементом <person>, а кожна властивість об'єкта Person - з атрибутом або вкладеним елементом елемента <person>
//// Що використовувати для властивостей – вкладені елементи чи атрибути? Це питання переваг -
//// ми можемо використовувати як атрибути, і вкладені елементи.
//// Так, у попередньому прикладі цілком можна використовувати замість атрибута вкладений елемент:
///////////////////////////////////////////////////////////////////////

/*
<?xml version="1.0" encoding="utf-8" ?>
<people>
  <person>
    <name>Tom</name>
    <company>Microsoft</company>
    <age>37</age>
  </person>
  <person>
    <name>Bob</name>
    <company>Google</company>
    <age>41</age>
  </person>
</people>
*/

///////////////////////////////////////////////////////////////////////
//// * Робота з XML за допомогою класів System.Xml
///////////////////////////////////////////////////////////////////////
//// Для роботи з XML C# можна використовувати кілька підходів.
//// У перших версіях фреймворку основний функціонал роботи з XML надавав простір імен System.Xml.

//// У ньому визначено ряд класів, які дозволяють маніпулювати XML-документом:
//// XmlNode:       представляє вузол xml. Як вузл може використовуватися весь документ, так і окремий елемент
//// XmlDocument:   представляє весь xml-документ
//// XmlElement:    представляє окремий елемент. Наслідується від класу XmlNode
//// XmlAttribute:  представляє атрибут елемента
//// XmlText:       представляє значення елемента у вигляді тексту, тобто той текст, який знаходиться в елементі між його тегами, що відкривають і закривають
//// XmlComment:    представляє коментар у xml
//// XmlNodeList:   використовується для роботи зі списком вузлів

//// Ключовим класом, який дозволяє маніпулювати вмістом xml, є XmlNode, тому розглянемо деякі його основні методи та властивості:
//// Attributes     - повертає об'єкт XmlAttributeCollection, який представляє колекцію атрибутів
//// ChildNodes     - повертає колекцію дочірніх вузлів для цього вузла.
//// HasChildNodes  - повертає true, якщо поточний вузол має дочірні вузли
//// FirstChild     - повертає перший дочірній вузол
//// LastChild      - повертає останній дочірній вузол
//// InnerText      - повертає текстове значення вузла
//// InnerXml       - повертає всю внутрішню розмітку xml вузла
//// Name           - повертає назву вузла. Наприклад, <user> - значення властивості Name і "user"
//// ParentNode     - повертає батьківський вузол біля поточного вузла
///////////////////////////////////////////////////////////////////////

//using System.Xml;

//var xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");

//// получим корневой элемент
//XmlElement? xRoot = xDoc.DocumentElement;
//if (xRoot != null)
//{
//    // обход всех узлов в корневом элементе
//    foreach (XmlElement xnode in xRoot)
//    {
//        // получаем атрибут name
//        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
//        Console.WriteLine(attr?.Value);

//        // обходим все дочерние узлы элемента user
//        foreach (XmlNode childnode in xnode.ChildNodes)
//        {
//            // если узел - company
//            if (childnode.Name == "company")
//            {
//                Console.WriteLine($"Company: {childnode.InnerText}");
//            }
//            // если узел age
//            if (childnode.Name == "age")
//            {
//                Console.WriteLine($"Age: {childnode.InnerText}");
//            }
//        }
//        Console.WriteLine();
//    }
//}

///////////////////////////////////////////////////////////////////////
//// Щоб розпочати роботу з документом xml, нам треба створити об'єкт XmlDocument
//// і потім завантажити в нього xml-файл: xDoc.Load("people.xml");
//// Під час аналізу xml для початку ми отримуємо кореневий елемент документа за допомогою властивості xDoc.DocumentElement.
//// Далі вже відбувається власне розбір вузлів документа.
//// У циклі foreach(XmlNode xnode in xRoot) пробігаємось по всіх дочірніх вузлах кореневого елемента.
//// Оскільки дочірні вузли є елементами <person>, ми можемо отримати їх атрибути:
//// XmlNode attr = xnode.Attributes.GetNamedItem("name"); та вкладені елементи: foreach (XmlNode childnode in xnode.ChildNodes)
//// Щоб визначити, що за вузол перед нами, ми можемо порівняти його назву: if (childnode.Name == "company")
//// Подібним чином ми можемо створити об'єкти класів і структур за даними xml:
///////////////////////////////////////////////////////////////////////

//using System.Xml;

//var people = new List<Person>();
//var xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");

//// получим корневой элемент
//XmlElement? xRoot = xDoc.DocumentElement;
//if (xRoot != null)
//{
//    foreach (XmlElement xnode in xRoot)
//    {
//        Person person = new Person();
//        XmlNode? attr = xnode.Attributes.GetNamedItem("name");
//        person.Name = attr?.Value;

//        foreach (XmlNode childnode in xnode.ChildNodes)
//        {
//            if (childnode.Name == "company")
//                person.Company = childnode.InnerText;

//            if (childnode.Name == "age")
//                person.Age = int.Parse(childnode.InnerText);
//        }
//        people.Add(person);
//    }
//    foreach (var person in people)
//        Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
//}

//class Person
//{
//    public string? Name { get; set; }
//    public int Age { get; set; }
//    public string? Company { get; set; }
//}

///////////////////////////////////////////////////////////////////////
//// * Зміна документа XML:
///////////////////////////////////////////////////////////////////////
//// Для редагування xml-документа (зміни, додавання, видалення елементів) ми можемо скористатися методами класу XmlNode:
//// AppendChild:       додає до кінця поточного вузла новий дочірній вузол
//// InsertAfter:       додає новий вузол після певного вузла
//// InsertBefore:      додає новий вузол до певного вузла
//// RemoveAll:         видаляє всі дочірні вузли поточного вузла
//// RemoveChild:       видаляє біля поточного вузла один дочірній вузол і повертає його

//// Клас XmlDocument додає ще низку методів, які дозволяють створювати нові вузли:
//// CreateNode:        створює вузол будь - якого типу
//// CreateElement:     створює вузол типу XmlDocument
//// CreateAttribute:   створює вузол типу XmlAttribute
//// CreateTextNode:    створює вузол типу XmlTextNode
//// CreateComment:     створює коментар
///////////////////////////////////////////////////////////////////////

//using System.Xml;

//var xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");
//XmlElement? xRoot = xDoc.DocumentElement;

//// создаем новый элемент person
//XmlElement personElem = xDoc.CreateElement("person");

//// создаем атрибут name
//XmlAttribute nameAttr = xDoc.CreateAttribute("name");

//// создаем элементы company и age
//XmlElement companyElem = xDoc.CreateElement("company");
//XmlElement ageElem = xDoc.CreateElement("age");

//// создаем текстовые значения для элементов и атрибута
//XmlText nameText = xDoc.CreateTextNode("Ivan");
//XmlText companyText = xDoc.CreateTextNode("Rozetka");
//XmlText ageText = xDoc.CreateTextNode("99");

////добавляем узлы
//nameAttr.AppendChild(nameText);
//companyElem.AppendChild(companyText);
//ageElem.AppendChild(ageText);

//// добавляем атрибут name
//personElem.Attributes.Append(nameAttr);

//// добавляем элементы company и age
//personElem.AppendChild(companyElem);
//personElem.AppendChild(ageElem);

//// добавляем в корневой элемент новый элемент person
//xRoot?.AppendChild(personElem);

//// сохраняем изменения xml-документа в файл
//xDoc.Save("../../../people.xml");

///////////////////////////////////////////////////////////////////////
//// * Видалення вузлів
///////////////////////////////////////////////////////////////////////

//using System.Xml;

//var xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");
//XmlElement? xRoot = xDoc.DocumentElement;
//XmlNode? firstNode = xRoot?.FirstChild;
//if (firstNode is not null) xRoot?.RemoveChild(firstNode);
//xDoc.Save("../../../people.xml");

///////////////////////////////////////////////////////////////////////
//// * XPath:
///////////////////////////////////////////////////////////////////////
//// XPath представляє мову запитів у XML. Він дозволяє вибирати елементи, які відповідають певному селектору.
//// Розглянемо деякі найпоширеніші селектори:

//// .                           - вибір поточного вузла
//// ..                          - вибір батьківського вузла
//// *                           - вибір усіх дочірніх вузлів поточного вузла
//// person                      - вибір всіх вузлів з певним ім'ям, у разі з ім'ям "person"
//// @name                       - вибір атрибута поточного вузла, після знака @ вказується назва атрибута (у разі "name")
//// @*                          - вибір усіх атрибутів поточного вузла
//// element[3]                  - вибір певного дочірнього вузла за індексом, у разі третього вузла
//// //person                    - вибір у документі всіх вузлів з ім'ям "person"
//// person[@name='Tom']         - вибір елементів із певним значенням атрибута. У разі вибираються все елементи " personal " з атрибутом                                       name='Tom'
//// person[company='Microsoft'] - вибір елементів із певним значенням вкладеного елемента. В даному випадку вибираються всі елементи "person",                                 у яких дочірній елемент "company" має значення 'Microsoft'
//// //person/company            - выбор в документе всех узлов с именем "company", которые находятся в элементах "person"

//// Действие запросов XPath основано на применении двух методов класса XmlElement:
//// SelectSingleNode(): выбор единственного узла из выборки. Если выборка по запросу содержит несколько узлов, то выбирается первый
//// SelectNodes(): выборка по запросу коллекции узлов в виде объекта XmlNodeList
///////////////////////////////////////////////////////////////////////
//// v1

//using System.Xml;

//XmlDocument xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");
//XmlElement? xRoot = xDoc.DocumentElement;

//// выбор всех дочерних узлов
//XmlNodeList? nodes = xRoot?.SelectNodes("*");
//if (nodes is not null)
//{
//    foreach (XmlNode node in nodes)
//        Console.WriteLine(node.OuterXml);
//}

///////////////////////////////////////////////////////////////////////
//// v2

//using System.Xml;

//XmlDocument xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");
//XmlElement? xRoot = xDoc.DocumentElement;
//XmlNodeList? personNodes = xRoot?.SelectNodes("person");
//if (personNodes is not null)
//{
//    foreach (XmlNode node in personNodes)
//        Console.WriteLine(node.SelectSingleNode("@name")?.Value);
//}

///////////////////////////////////////////////////////////////////////
//// v3

//using System.Xml;

//XmlDocument xDoc = new XmlDocument();
//xDoc.Load("../../../people.xml");
//XmlElement? xRoot = xDoc.DocumentElement;

//XmlNodeList? companyNodes = xRoot?.SelectNodes("//person/company");
//if (companyNodes is not null)
//{
//    foreach (XmlNode node in companyNodes)
//        Console.WriteLine(node.InnerText);
//}

///////////////////////////////////////////////////////////////////////
//// * Linq to Xml. Створення документа XML:
///////////////////////////////////////////////////////////////////////
//// Ще один підхід до роботи з Xml представляє технологія LINQ to XML.
//// Вся функціональність LINQ to XML міститься у просторі імен System.Xml.Linq.
//// Розглянемо основні класи цього простору імен:

//// XAttribute:    представляє атрибут xml - елемента
//// XComment:      представляє коментар
//// XDocument:     представляє весь XML - документ
//// XElement:      представляє окремий xml - елемент

//// Ключовим класом є XElement, який дозволяє отримувати вкладені елементи та керувати ними. Серед його методів можна назвати такі:

//// Add():         додає новий атрибут або елемент
//// Attributes():  повертає колекцію атрибутів для цього елемента
//// Elements():    повертає всі дочірні елементи цього елемента
//// Remove():      видаляє цей елемент із батьківського об'єкта
//// RemoveAll():   видаляє всі дочірні елементи та атрибути цього елемента

//// Отже, використовуємо функціональність LINQ to XML і створимо новий XML-документ:
///////////////////////////////////////////////////////////////////////
//// v1

//using System.Xml.Linq;

//XDocument xdoc = new XDocument();
//// создаем первый элемент person
//XElement tom = new XElement("person");
//// создаем атрибут name
//XAttribute tomNameAttr = new XAttribute("name", "Tom");
//// создаем два элемента company и age 
//XElement tomCompanyElem = new XElement("company", "Microsoft");
//XElement tomAgeElem = new XElement("age", 37);
//// добавляем атрибут и элементы в первый элемент person
//tom.Add(tomNameAttr);
//tom.Add(tomCompanyElem);
//tom.Add(tomAgeElem);

//// создаем второй элемент person
//XElement bob = new XElement("person");
//// создаем для него атрибут name
//XAttribute bobNameAttr = new XAttribute("name", "Bob");
//// и два элемента - company и age
//XElement bobCompanyElem = new XElement("company", "Google");
//XElement bobAgeElem = new XElement("age", 41);
//bob.Add(bobNameAttr);
//bob.Add(bobCompanyElem);
//bob.Add(bobAgeElem);
//// создаем корневой элемент
//XElement people = new XElement("people");
//// добавляем два элемента person в корневой элемент
//people.Add(tom);
//people.Add(bob);
//// добавляем корневой элемент в документ
//xdoc.Add(people);
////сохраняем документ
//xdoc.Save("../../../people_v2.xml");

//Console.WriteLine("Data saved");

///////////////////////////////////////////////////////////////////////
//// v2

//using System.Xml.Linq;

//XDocument xdoc = new XDocument(new XElement("people",
//    new XElement("person",
//        new XAttribute("name", "Tom"),
//        new XElement("company", "Microsoft"),
//        new XElement("age", 37)),
//    new XElement("person",
//        new XAttribute("name", "Bob"),
//        new XElement("company", "Google"),
//        new XElement("age", 41))));
//xdoc.Save("../../../people_v3.xml");

//Console.WriteLine("Data saved");

///////////////////////////////////////////////////////////////////////
//// * Вибірка елементів у LINQ to XML
///////////////////////////////////////////////////////////////////////
//// v1

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");
//// получаем корневой узел
//XElement? people = xdoc.Element("people");
//if (people is not null)
//{
//    // проходим по всем элементам person
//    foreach (XElement person in people.Elements("person"))
//    {

//        XAttribute? name = person.Attribute("name");
//        XElement? company = person.Element("company");
//        XElement? age = person.Element("age");

//        Console.WriteLine($"Person: {name?.Value}");
//        Console.WriteLine($"Company: {company?.Value}");
//        Console.WriteLine($"Age: {age?.Value}");

//        Console.WriteLine(); //  для разделения при выводе на консоль
//    }
//}

///////////////////////////////////////////////////////////////////////
//// v2

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");

//var microsoft = xdoc.Element("people")?   // получаем корневой узел people
//    .Elements("person")             // получаем все элементы person
//                                    // получаем все person, у которого company = Microsoft
//    .Where(p => p.Element("company")?.Value == "Facebook")
//    .Select(p => new        // для каждого объекта создаем анонимный объект
//    {
//        name = p.Attribute("name")?.Value,
//        age = p.Element("age")?.Value,
//        company = p.Element("company")?.Value
//    });

//if (microsoft is not null)
//{
//    foreach (var person in microsoft)
//    {
//        Console.WriteLine($"Name: {person.name}  Age: {person.age}");
//    }
//}

///////////////////////////////////////////////////////////////////////
//// v3

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");

//var tom = xdoc.Element("people")?   // получаем корневой узел people
//    .Elements("person")             // получаем все элементы person
//    .FirstOrDefault(p => p.Attribute("name")?.Value == "Bob");

//var name = tom?.Attribute("name")?.Value;
//var age = tom?.Element("age")?.Value;
//var company = tom?.Element("company")?.Value;

//Console.WriteLine($"Name: {name}  Age: {age}  Company: {company}");

///////////////////////////////////////////////////////////////////////
//// * Зміна документа в LINQ to XML:
///////////////////////////////////////////////////////////////////////
//// * Додавання даних:

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");
//XElement? root = xdoc.Element("people");

//if (root != null)
//{
//    // добавляем новый элемент
//    root.Add(new XElement("person",
//                new XAttribute("name", "Sam"),
//                new XElement("company", "JetBrains"),
//                new XElement("age", 28)));

//    xdoc.Save("../../../people.xml");
//}

//// выводим xml-документ на консоль
//Console.WriteLine(xdoc);

///////////////////////////////////////////////////////////////////////
//// * Зміна даних:
///////////////////////////////////////////////////////////////////////

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");

//// получим элемент person с name = "Tom"
//var tom = xdoc.Element("people")?
//    .Elements("person")
//    .FirstOrDefault(p => p.Attribute("name")?.Value == "Tom");

//if (tom != null)
//{
//    //  меняем атрибут name
//    var name = tom.Attribute("name");
//    if (name != null) name.Value = "Tomas";


//    //  меняем вложенный элемент age
//    var age = tom.Element("age");
//    if (age != null) age.Value = "22";

//    xdoc.Save("../../../people.xml");
//}

//// выводим xml-документ на консоль
//Console.WriteLine(xdoc);

///////////////////////////////////////////////////////////////////////
//// * Видалення даних:
///////////////////////////////////////////////////////////////////////

//using System.Xml.Linq;

//XDocument xdoc = XDocument.Load("../../../people.xml");
//XElement? root = xdoc.Element("people");

//if (root != null)
//{
//    // получим элемент person с name = "Bob"
//    var bob = root.Elements("person")
//        .FirstOrDefault(p => p.Attribute("name")?.Value == "Bob");
//    // и удалим его
//    if (bob != null)
//    {
//        bob.Remove();
//        xdoc.Save("../../../people.xml");
//    }
//}

//// выводим xml-документ на консоль
//Console.WriteLine(xdoc);

///////////////////////////////////////////////////////////////////////
//// * Серіалізація у XML.XmlSerializer:
///////////////////////////////////////////////////////////////////////
//// Для зручного збереження та вилучення об'єктів із файлів xml може використовуватися клас XmlSerializer із
//// простору імен System.Xml.Serialization. Цей клас спрощує збереження складних об'єктів у форматі xml і подальше їх вилучення.
//// Для створення об'єкта XmlSerializer можна застосовувати різні конструктори, але майже всі вони вимагають
//// вказівки типу даних, які будуть серіалізуватися та десеріалізуватися:
///////////////////////////////////////////////////////////////////////

//using System.Xml.Serialization;

//XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

////[Serializable]
//class Person { }

///////////////////////////////////////////////////////////////////////
//// У цьому випадку XmlSerializer працюватиме лише з об'єктами класу Person.
//// Слід враховувати, що XmlSerializer передбачає деякі обмеження. Наприклад, клас, що підлягає серіалізації,
//// повинен мати стандартний конструктор без параметрів та повинен мати модифікатор доступу public.
//// Також серіалізації підлягають лише відкриті члени. Якщо в класі є поля або властивості з private модифікатором,
//// то при серіалізації вони будуть ігноруватися. Крім того, властивості повинні мати загальнодоступні гетери та сеттери.
///////////////////////////////////////////////////////////////////////
////  * Серіалізація:
///////////////////////////////////////////////////////////////////////

//using System.Xml.Serialization;

//// объект для сериализации
//Person person = new Person("Tom", 37);
//// передаем в конструктор тип класса Person
//XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
//// получаем поток, куда будем записывать сериализованный объект
//using (FileStream fs = new FileStream("../../../person_v4.xml", FileMode.OpenOrCreate))
//{
//    xmlSerializer.Serialize(fs, person);

//    Console.WriteLine("Object has been serialized");
//}

//[Serializable]
//public class Person
//{
//    public string Name { get; set; } = "Undefined";
//    public int Age { get; set; } = 1;

//    public Person() { }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// * Десеріалізація:
///////////////////////////////////////////////////////////////////////

//using System.Xml.Serialization;

//XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

//// десериализуем объект:
//using (FileStream fs = new FileStream("person_v4.xml", FileMode.OpenOrCreate))
//{
//    Person? person = xmlSerializer.Deserialize(fs) as Person;
//    Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
//}

//public class Person
//{
//    public string Name { get; set; } = "Undefined";
//    public int Age { get; set; } = 1;

//    public Person() { }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// Серіалізація та десеріалізація колекцій:
///////////////////////////////////////////////////////////////////////
//// v1

//using System.Xml.Serialization;

//Person[] people = new Person[]
//{
//    new Person("Tom", 37),
//    new Person("Bob", 41)
//};

//XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
//// сохранение массива в файл
//using (FileStream fs = new FileStream("../../../people_v5.xml", FileMode.OpenOrCreate))
//{
//    formatter.Serialize(fs, people);
//}
//// восстановление массива из файла
//using (FileStream fs = new FileStream("../../../people_v5.xml", FileMode.OpenOrCreate))
//{
//    Person[]? newpeople = formatter.Deserialize(fs) as Person[];

//    if (newpeople != null)
//    {
//        foreach (Person person in newpeople)
//        {
//            Console.WriteLine($"Name: {person.Name} --- Age: {person.Age}");
//        }
//    }
//}

//public class Person
//{
//    public string Name { get; set; } = "Undefined";
//    public int Age { get; set; } = 1;
//    public Person() { }
//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age;
//    }
//}

///////////////////////////////////////////////////////////////////////
//// v2

//using System.Xml.Serialization;

//var microsoft = new Company("Microsoft");
//var google = new Company("Google");

//Person[] people = new Person[]
//{
//    new Person("Tom", 37, microsoft),
//    new Person("Bob", 41, google)
//};

//XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

//using (FileStream fs = new FileStream("../../../people_v6.xml", FileMode.OpenOrCreate))
//{
//    formatter.Serialize(fs, people);
//}

//using (FileStream fs = new FileStream("../../../people_v6.xml", FileMode.OpenOrCreate))
//{
//    Person[]? newpeople = formatter.Deserialize(fs) as Person[];

//    if (newpeople != null)
//    {
//        foreach (Person person in newpeople)
//        {
//            Console.WriteLine($"Name: {person.Name}");
//            Console.WriteLine($"Age: {person.Age}");
//            Console.WriteLine($"Company: {person.Company.Name}");
//        }
//    }
//}

//public class Company
//{
//    public string Name { get; set; } = "Undefined";
//    // стандартный конструктор без параметров
//    public Company() { }
//    public Company(string name) => Name = name;
//}
//public class Person
//{
//    public string Name { get; set; } = "Undefined";
//    public int Age { get; set; } = 1;
//    public Company Company { get; set; } = new Company();
//    public Person() { }
//    public Person(string name, int age, Company company)
//    {
//        Name = name;
//        Age = age;
//        Company = company;
//    }
//}

///////////////////////////////////////////////////////////////////////


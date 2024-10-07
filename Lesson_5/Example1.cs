namespace Lesson5
{
    class Person
    {
        public object Id { get; }
        public string Name { get; }
        public Person(object id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Person<T>
    {
        public T Id { get; set; }
        public static T? code;
        public string Name { get; set; }
        public Person(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Company<P>
    {
        public P CEO { get; set; }
        public Company(P ceo)
        {
            CEO = ceo;
        }
    }

    // Using Multiple Generic Parameters
    class Person<T, K>
    {
        public T Id { get; }
        public K Password { get; set; }
        public string Name { get; }
        public Person(T id, K password, string name)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }

    // Restriction types and standard restrictions

    //We can use the following types as constraints:

    //Classes

    //Interfaces

    //class - the generic parameter must represent a class

    //struct - the generic parameter must represent a structure

    //new () - the generic parameter must represent a type that has a public parameterless constructor

    // examples
    //class Messenger<T> where T : struct
    //{ }

    //class Messenger<T> where T : class
    //{ }

    //class Messenger<T> where T : new()
    //{ }

    //class Smartphone<T> where T : Messenger, new()
    //{ }

    //
    class Messenger<T, P>
    where T : Message
    where P : Person2
    {
        public void SendMessage(P sender, P receiver, T message)
        {
            Console.WriteLine($"Sender: {sender.Name}");
            Console.WriteLine($"Recipient: {receiver.Name}");
            Console.WriteLine($"Message: {message.Text}");
        }
    }
    class Person2
    {
        public string Name { get; }
        public Person2(string name) => Name = name;
    }

    class Message
    {
        public string Text { get; }
        public Message(string text) => Text = text;
    }

    // Generic Type Inheritance
    public class BaseUser<T> where T : class
    {
        public T Id { get; }
        public BaseUser(T id) => Id = id;
    }

    class User<T> : BaseUser<T> where T : class
    {
        public User(T id) : base(id) { }
    }

    class MixedUser<T, K> : BaseUser<T>
        where K : struct
        where T: class
    {
        public K Code { get; set; }
        public MixedUser(T id, K code) : base(id)
        {
            Code = code;
        }
    }

    public static class Example1
    {
        // Generic Methods
        static void Swap<TEntity>(ref TEntity x, ref TEntity y)
        {
            TEntity temp = x;
            x = y;
            y = temp;
        }

        public static void Test()
        {
            // 1
            //Console.WriteLine();
            //int n1 = 1, n2 = 2;
            //Swap(ref n1, ref n2);
            //Console.WriteLine(n1);
            //Console.WriteLine(n2);
            //var n3 = 12.5f;
            //var n4 = 33.8f;
            //Swap(ref n3, ref n4);

            // problem
            //Person tom = new Person(546, "Tom");  // boxing an int value into an Object
            //Person bob = new Person("abc123", "Bob");

            //int tomId = (int)tom.Id;  // Unboxing to int type
            //string tomId2 = (string)tom.Id;  // Error - Exception InvalidCastException
            //string bobId = (string)bob.Id;

            //Console.WriteLine(tomId);   // 546
            //Console.WriteLine(bobId);   // abc123

            // solution -> generics

            //Person<int> tom = new Person<int>(546, "Tom");  // boxing is not needed
            //Person<string> bob = new Person<string>("abc123", "Bob");

            //int tomId = tom.Id;      // no Unboxing needed
            //string bobId = bob.Id;  // no type conversion needed

            //Console.WriteLine(tomId);
            //Console.WriteLine(bobId);

            ////
            //var microsoft = new Company<Person<int>>(tom);

            //Console.WriteLine(microsoft.CEO.Id);
            //Console.WriteLine(microsoft.CEO.Name);

            //// static
            //Person<string>.code = "meta";
            //Person<int>.code = 1234;

            //Console.WriteLine(Person<int>.code);
            //Console.WriteLine(Person<string>.code);

            //// 
            //Person<int, string> tom1 = new Person<int, string>(546, "qwerty", "Tom");
            //Console.WriteLine(tom1.Id);
            //Console.WriteLine(tom1.Password);

            //
            //int x = 7;
            //int y = 25;
            //Swap<int>(ref x, ref y);
            //Console.WriteLine($"x={x}    y={y}");

            //string s1 = "hello";
            //string s2 = "bye";
            //Swap<string>(ref s1, ref s2);
            //Console.WriteLine($"s1={s1}    s2={s2}");

            //
            Messenger<Message, Person2> telegram = new Messenger<Message, Person2>();
            Person2 tom2 = new Person2("Tom");
            Person2 bob2 = new Person2("Bob");
            Message hello = new Message("Hello, Bob!");
            telegram.SendMessage(tom2, bob2, hello);
        }
    }
}

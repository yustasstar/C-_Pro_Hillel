namespace Lesson4
{
    //можно перегрузить
    //унарные операторы +x, -x, !x, ~x, ++, --, true, false
    //бинарные операторы +, -, *, /, %
    //операции сравнения ==, !=, <, >, <=, >=
    //поразрядные операторы &, |, ^, <<, >>
    //логические операторы &&, ||

    // нужно определять парами
    //== и !=
    //< и >
    //<= и >=

    class Counter
    {
        public int Value { get; set; }

        public static Counter operator +(Counter counter1, Counter counter2)
        {
            return new Counter { Value = counter1.Value + counter2.Value };
        }
        public static bool operator >(Counter counter1, Counter counter2)
        {
            return counter1.Value > counter2.Value;
        }
        public static bool operator <(Counter counter1, Counter counter2)
        {
            return counter1.Value < counter2.Value;
        }
        public static Counter operator ++(Counter counter1)
        {
            return new Counter { Value = counter1.Value + 10 };
        }
        public static bool operator true(Counter counter1)
        {
            return counter1.Value != 0;
        }
        public static bool operator false(Counter counter1)
        {
            return counter1.Value == 0;
        }
        public static bool operator !(Counter counter1)
        {
            return counter1.Value == 0;
        }
    }

    record User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public User(string userName, string email, string address)
        {
            UserName = userName;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"UserName: {UserName} Email: {Email} Address: {Address}";
        }
    }

    class Organisation
    {
        User[] users;
        public Organisation(User[] users)
        {
            this.users = users;
        }

        public User this[int index]
        {
            get => users[index];
            set => users[index] = value;
        }

        //public void Hello()
        //{
        //    Console.WriteLine("Hello");
        //}

        //public void HelloV2() => Console.WriteLine("Hello");

        public User this[string userName]
        {
            get
            {
                foreach (var user in users)
                {
                    if (user.UserName == userName)
                    {
                        return user;
                    }
                }
                throw new InvalidOperationException("Unknown name");
            }
        }
    }

    // explicit - явное преобразование типов
    // implicit - неявное преобразование типов
    class Timer
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    class CounterV2
    {
        public int Seconds { get; set; }

        public static implicit operator CounterV2(int x)
        {
            return new CounterV2 { Seconds = x };
        }
        public static explicit operator int(CounterV2 counter)
        {
            return counter.Seconds;
        }
        public static explicit operator CounterV2(Timer timer)
        {
            int h = timer.Hours * 3600;
            int m = timer.Minutes * 60;
            return new CounterV2 { Seconds = h + m + timer.Seconds };
        }
        public static implicit operator Timer(CounterV2 counter)
        {
            int h = counter.Seconds / 3600;
            int m = (counter.Seconds % 3600) / 60;
            int s = counter.Seconds % 60;
            return new Timer { Hours = h, Minutes = m, Seconds = s };
        }
    }

    public static class Example1
    {
        public static void StartTest()
        {
            Counter counter1 = new Counter { Value = 23 };
            Counter counter2 = new Counter { Value = 45 };
            bool result = counter1 > counter2;
            Console.WriteLine(result); // false

            Counter counter3 = counter1 + counter2;
            Console.WriteLine(counter3.Value);  // 23 + 45 = 68


            Counter counter4 = new Counter() { Value = 10 };
            Counter counter5 = counter4++;
            Console.WriteLine(counter4.Value);      // 20
            Console.WriteLine(counter5.Value);      // 10

            Counter counter6 = ++counter4;
            Console.WriteLine(counter4.Value);      // 30
            Console.WriteLine(counter6.Value);      // 30


            Counter counter = new Counter() { Value = 0 };
            if (counter)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);


            if (!counter)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);


            var myOrg = new Organisation(new User[] {
                new("Vasya", "test1@gmail.com", "street 1"),
                new("Petya", "test2@gmail.com", "street 2"),
                new("Anton", "test3@gmail.com", "street 3")
            });

            Console.WriteLine(myOrg[1]);
            Console.WriteLine(myOrg["Anton"]);


            //CounterV2 counter1 = new CounterV2 { Seconds = 115 };

            //Timer timer = counter1;
            //Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); // 0:1:55

            //var counter2 = (CounterV2)timer;
            //Console.WriteLine(counter2.Seconds);  //115
        }
    }
}

// перегрузка операторов
// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

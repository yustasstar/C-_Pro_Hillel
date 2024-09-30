namespace ThirdLesson.someStandardInterfaces
{
    // https://www.programiz.com/csharp-programming/yield-keyword#:~:text=yield%20return%20%2D%20returns%20an%20expression,yield%20break%20%2D%20terminates%20the%20iteration
    // Итераторы и оператор yield

    //Ітератор по суті є блоком коду, який використовує оператор yield для перебору набору значень.
    //Цей блок коду може представляти тіло методу, оператора або блок get у властивостях.
    //Ітератор використовує дві спеціальні інструкції:

    //yield return: визначає елемент, що повертається

    //yield break: вказує, що послідовність більше не має елементів

    class Numbers
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return i * i;
            }
        }
    }

    static class Int32Extension
    {
        public static IEnumerator<int> GetEnumerator(this int number)
        {
            int k = (number > 0) ? number : 0;
            for (int i = number - k; i <= k; i++) yield return i;
        }
    }

    class Human
    {
        public string Name { get; }
        public Human(string name) => Name = name;
    }
    class MyCompany
    {
        Human[] personnel;
        public MyCompany(Human[] personnel) => this.personnel = personnel;
        public int Length => personnel.Length;
        public IEnumerable<Human> GetPersonnel(int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == personnel.Length)
                {
                    yield break;
                }
                else
                {
                    yield return personnel[i];
                }
            }
        }
    }

    public static class Example7
    {
        public static void StartTest()
        {
            //Numbers numbers = new Numbers();
            //foreach (int n in numbers)
            //{
            //    Console.WriteLine(n);
            //}

            //
            // foreach (var n in 5) Console.WriteLine(n);
            // foreach (var n in -5) Console.WriteLine(n);

            ////
            //var people = new Human[]
            //{
            //    new Human("Tom"),
            //    new Human("Bob"),
            //    new Human("Sam")
            //};
            //var microsoft = new MyCompany(people);

            //foreach (Human employee in microsoft.GetPersonnel(5))
            //{
            //    Console.WriteLine(employee.Name);
            //}
        }
    }
}

// Рефлексия:
// https://www.bestprog.net/uk/2018/11/09/reflection-examples-of-obtaining-information-about-methods-interfaces-type-fields-method-parameters-type-statistics_ua/
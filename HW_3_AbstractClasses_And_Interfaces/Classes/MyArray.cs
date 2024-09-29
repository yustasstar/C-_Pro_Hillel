using HW_3_AbstractClasses_And_Interfaces.Interfaces;

namespace HW_3_AbstractClasses_And_Interfaces.Classes
{
    public class MyArray : IOutput, IMath , ISort
    {
        private readonly int[] array;

        public MyArray(int[] testArray)
        {
            array = testArray;
        }

        public void Show() => Console.WriteLine("Random test array generated elements: " + string.Join(", ", array));

        public void Show(string info) => Console.WriteLine($"{info}: " + string.Join(", ", array));

        public int Max()
        {
            int maxValue = array.Max();
            Console.WriteLine($"Max value of test array: '{maxValue}'");
            return maxValue;
        }

        public int Min()
        {
            int minValue = array.Min();
            Console.WriteLine($"Min value of test array: '{minValue}'");
            return minValue;
        }

        public float Avg()
        {
            float avgValue = (float)array.Average();
            Console.WriteLine($"Average value of test array: '{avgValue}'");
            return avgValue;
        }

        public bool Search(int valueToSearch)
        {
            bool isPresent = Array.Exists(array, element => element == valueToSearch);
            if (isPresent)
            {
                Console.WriteLine($"Value '{valueToSearch}' is present in the test array: {isPresent}");
                return isPresent;
            }

            Console.WriteLine($"Value '{valueToSearch}' is NOT present in the test array: {isPresent}");
            return isPresent;
        }

        public void SortAsc()
        {
            Array.Sort(array);
            Console.WriteLine("Array sorted by Ascending order:");
        }

        public void SortDesc()
        {
            Array.Sort(array);
            Array.Reverse(array);
            Console.WriteLine("Array sorted by Descending order:");
        }

        public void SortByParam(bool isAsc)
        {
            Console.WriteLine($"Parameter to sort: {isAsc}");

            if (!isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
}

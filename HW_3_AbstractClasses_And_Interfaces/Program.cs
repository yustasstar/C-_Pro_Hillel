using HW_3_AbstractClasses_And_Interfaces.Classes;

namespace HW_3_AbstractClasses_And_Interfaces

{
    public class Program
    {
        public static void Main(string[] args)
        {
            string messageBeforeSorting = "Array before sorting";
            string messageAfterSorting = "Array after sorting";
            int lenght = 9;
            int minValue = -10;
            int maxValue = 100;
            int[] randomArray = GenerateRandomArray(lenght, minValue, maxValue);

            MyArray myArray = new MyArray(randomArray);

            Console.WriteLine("Task 1 - IOutput:");
            myArray.Show();
            myArray.Show(messageBeforeSorting);

            Console.WriteLine("Task 2 - IMath:");
            myArray.Min();
            myArray.Max();
            myArray.Avg();


            Console.WriteLine("Please enter the integer value to search in array:");
            bool success = int.TryParse(Console.ReadLine(), out int valueToSearch);
            if (!success)
            {
                throw new ArgumentException("Entered value is not valid to search!"); ;
            }

            myArray.Search(valueToSearch);

            Console.WriteLine("Task 3 - Sort:");
            myArray.Show(messageBeforeSorting);
            myArray.SortAsc();
            myArray.Show(messageAfterSorting);

            myArray.SortDesc();
            myArray.Show(messageAfterSorting);

            myArray.SortByParam(true);
            myArray.Show(messageAfterSorting);

            myArray.SortByParam(false);
            myArray.Show(messageAfterSorting);


            static int[] GenerateRandomArray(int size, int minValue, int maxValue)
            {
                Random random = new Random();
                int[] array = new int[size];

                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(minValue, maxValue);
                }
                return array;
            }
        }
    }
}
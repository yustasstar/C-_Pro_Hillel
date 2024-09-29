using HW_3_AbstractClasses_And_Interfaces.Classes;

namespace HW_3_AbstractClasses_And_Interfaces

{
    public class Program
    {
        public static void Main(string[] args)
        {
            int lenght = 9;
            int minValue = -10; 
            int maxValue = 100; 
            int[] randomArray = GenerateRandomArray(lenght, minValue, maxValue);

            MyArray myArray = new MyArray(randomArray);
            string message = "Some info message!";

            myArray.Show();
            myArray.Show(message);
            myArray.Min();
            myArray.Max();
            myArray.Avg();
           

            Console.WriteLine("Please enter the integer value to search in array:");
            int valueToSearch;

            bool success = int.TryParse(Console.ReadLine(), out valueToSearch);

            if (!success)
            {
                throw new ArgumentException("Entered value is not valid to search!"); ;
            }
   
            myArray.Search(valueToSearch);


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
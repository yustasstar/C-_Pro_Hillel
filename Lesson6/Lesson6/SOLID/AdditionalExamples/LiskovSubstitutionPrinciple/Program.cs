//namespace LiskovSubstitutionPrinciple
//{
//	class Program
//	{
//		private static void Main()
//		{
//			Console.WriteLine("---Liskov Substitution Principle---\n");
//			Console.Write("Enter the major axis of a circle: ");
//			var majorAxis = Convert.ToInt32(Console.ReadLine());

//			Console.Write("Enter the minor axis of a circle: ");
//			var minorAxis = Convert.ToInt32(Console.ReadLine());

//			Console.Write("Enter the width of the rectangle: ");
//			var width = Convert.ToInt32(Console.ReadLine());

//			Console.Write("Enter the height of the rectangle: ");
//			var height = Convert.ToInt32(Console.ReadLine());

//			var areaCalc = new AreaCalc();

//			var ellipseArea = areaCalc.SetCircleArea(majorAxis, minorAxis);
//			var rectangleArea = areaCalc.SetSquareArea(width, height);

//			Console.WriteLine("\n---Results---\n");
//			Console.WriteLine($"Ellipse area: {ellipseArea}");
//			Console.WriteLine($"Rectangle area: {rectangleArea}");
//		}
//	}
//}

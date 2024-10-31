namespace LiskovSubstitutionPrinciple
{
    public class AreaCalc
    {
        public double SetCircleArea(int majorAxis, int minorAxis)
        {
            var circle = new Circle();
            circle.SetMajorAxis(majorAxis);
            circle.SetMinorAxis(minorAxis);

            return circle.Area();
        }

        public int SetSquareArea(int width, int height)
        {
            var square = new Square();
            square.SetWidth(width);
            square.SetHeight(height);

            return square.GetArea();
        }
    }
}

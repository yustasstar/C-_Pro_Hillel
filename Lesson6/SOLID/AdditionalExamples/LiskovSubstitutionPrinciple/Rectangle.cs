namespace LiskovSubstitutionPrinciple
{
    public class Rectangle
    {
        public int Height { get; private set; }

        public int Width { get; private set; }

        public virtual void SetHeight(int height) => Height = height;

        public virtual void SetWidth(int width) => Width = width;

        public int GetArea() => Height * Width;
    }
}

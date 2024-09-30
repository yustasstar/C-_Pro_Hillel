namespace Lesson4.PartialClasses
{
    public partial class PersonPartial
    {
        public partial void Read();
        public void DoSomething()
        {
            Read();
        }
    }
}

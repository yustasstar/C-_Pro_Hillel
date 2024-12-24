namespace DesignPatternsExamples.Factory.Abstract_Factory.Interfaces
{
    public interface IArmchair : IBaseProduct
    {
        string GetPurpose(int numbersOfHandles);
    }
}

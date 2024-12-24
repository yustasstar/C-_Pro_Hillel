namespace DesignPatternsExamples.State.Interfaces
{
    public interface IOrderState
    {
        void NewOrderPlaced();

        void Register();

        void Dispatch();

        void Approve();
    }
}

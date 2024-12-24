namespace DesignPatternsExamples.ChainOfResponsibility.Classes
{
    public abstract class Approver
    {
        protected readonly Approver Successor;
        protected readonly string Position;

        public Approver(Approver approver, string position)
        {
            Successor = approver;
            Position = position;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}

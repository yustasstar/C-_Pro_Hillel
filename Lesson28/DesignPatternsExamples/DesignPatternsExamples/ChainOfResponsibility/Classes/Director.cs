using System;

namespace DesignPatternsExamples.ChainOfResponsibility.Classes
{
    public class Director : Approver
    {
        public Director(Approver approver) : base(approver, "Director")
        {
            
        }

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", Position, purchase.Number);
            }
            else
            {
                Successor.ProcessRequest(purchase);
            }
        }
    }
}

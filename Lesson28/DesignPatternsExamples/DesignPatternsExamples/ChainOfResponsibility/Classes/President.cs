using System;

namespace DesignPatternsExamples.ChainOfResponsibility.Classes
{
    public class President : Approver
    {
        public President(Approver approver) : base(approver, "President")
        {

        }

        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine($"Request {purchase.Number} requires an executive meeting!");
            }
        }
    }
}

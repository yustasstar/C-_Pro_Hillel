namespace DesignPatternsExamples.ChainOfResponsibility.Classes
{
    public class ChainOfResponsibilityExample
    {
        public void TestChainOfResponsibility()
        {
            Approver vasya = new President(null);
            Approver petya = new VicePresident(vasya);
            Approver kirill = new Director(petya);

            var purchase = new Purchase(2034, 350.00, "Project X");
            kirill.ProcessRequest(purchase);

            purchase = new Purchase(2035, 32590.10, "Project Y");
            kirill.ProcessRequest(purchase);

            purchase = new Purchase(2036, 122100.00, "Project Z");
            kirill.ProcessRequest(purchase);
        }
    }
}

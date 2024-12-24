using DesignPatternsExamples.State.Interfaces;

namespace DesignPatternsExamples.State.Classes
{
    public class OrderState
    {
        public IOrderState currentState;

        public OrderState()
        {
            currentState = new NewOrder(this);
        }

        public void Dispatch()
        {
            currentState.Dispatch();
        }

        public void Register()
        {
            currentState.Register();
        }

        public void Approve()
        {
            currentState.Approve();
        }
    }
}

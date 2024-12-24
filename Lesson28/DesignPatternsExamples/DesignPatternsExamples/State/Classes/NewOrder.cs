using DesignPatternsExamples.State.Interfaces;
using System;

namespace DesignPatternsExamples.State.Classes
{
    public class NewOrder : IOrderState
    {
        private readonly OrderState _orderState;

        public NewOrder(OrderState orderState)
        {
            _orderState = orderState;
            NewOrderPlaced();
        }

        public bool IsDispatched
        {
            get { return false; }
        }

        public void NewOrderPlaced()
        {
            Console.WriteLine("New order placed!");
        }

        public void Dispatch()
        {
            _orderState.currentState = new DispatchedState(_orderState);
        }

        public void Register()
        {
            _orderState.currentState = new RegisteredState(_orderState);
        }

        public void Approve()
        {
            _orderState.currentState = new ApprovedState(_orderState);
        }
    }
}

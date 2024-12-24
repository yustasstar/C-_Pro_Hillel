using DesignPatternsExamples.State.Interfaces;
using System;

namespace DesignPatternsExamples.State.Classes
{
    public class DispatchedState : IOrderState
    {
        private readonly OrderState _orderState;

        public void NewOrderPlaced()
        {
            throw new Exception("OrderState has already been placed!");
        }

        public DispatchedState(OrderState orderState)
        {
            _orderState = orderState;
            Dispatch();
        }

        public void Dispatch()
        {
            Console.WriteLine("Dispatched!");
        }

        public void Register()
        {
            throw new Exception("OrderState has already been registered!");
        }

        public void Approve()
        {
            _orderState.currentState = new ApprovedState(_orderState);
        }
    }
}

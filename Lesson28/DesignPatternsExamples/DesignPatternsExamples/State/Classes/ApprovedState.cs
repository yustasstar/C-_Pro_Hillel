using DesignPatternsExamples.State.Interfaces;
using System;

namespace DesignPatternsExamples.State.Classes
{
    public class ApprovedState : IOrderState
    {
        private readonly OrderState _orderState;

        public ApprovedState(OrderState orderState)
        {
            _orderState = orderState;
            Approve();
        }

        public void NewOrderPlaced()
        {
            throw new Exception("OrderState has already been placed!");
        }

        public void Dispatch()
        {
            _orderState.currentState = new DispatchedState(_orderState);
        }

        public void Register()
        {
            throw new Exception("OrderState has already been registered!");
        }

        public void Approve()
        {
            Console.WriteLine("Approved!");
        }
    }
}

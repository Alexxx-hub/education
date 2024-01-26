using Patterns.Factory.My_little_factory.Core.Orders;
using Patterns.Factory.My_little_factory.Interfaces;

namespace Patterns.Factory.My_little_factory.Factory.OrderFactory
{
    public class MiddleOrderCreator : OrderCreator
    {
        public override IOrder CreateOrder()
        {
            return new MiddleOrder();
        }
    }
}
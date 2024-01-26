using Patterns.Factory.My_little_factory.Core.Orders;
using Patterns.Factory.My_little_factory.Interfaces;

namespace Patterns.Factory.My_little_factory.Factory.OrderFactory
{
    public class HardOrderCreator : OrderCreator
    {
        public override IOrder CreateOrder()
        {
            return new HardOrder();
        }
    }
}
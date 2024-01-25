using Patterns.Factory.My_little_factory.Interfaces;

namespace Patterns.Factory.My_little_factory.Factory.OrderFactory
{
    public abstract class OrderCreator
    {
        public abstract IOrder CreateOrder();
    }
}
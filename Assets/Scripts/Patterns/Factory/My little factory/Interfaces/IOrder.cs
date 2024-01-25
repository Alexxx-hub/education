using System.Collections.Generic;

namespace Patterns.Factory.My_little_factory.Interfaces
{
    public interface IOrder
    {
        public int FinishOrder(List<Furniture.Furniture> furnitures);
    }
}
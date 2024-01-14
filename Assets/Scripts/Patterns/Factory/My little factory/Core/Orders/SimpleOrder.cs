using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Interfaces;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Core.Orders
{
    public class SimpleOrder : IOrder
    {
        private Dictionary<int, int> _furnitureOrder;
        //---------------------------------------------------------------------------------------------------------------
        public SimpleOrder()
        {
            var furnitureID = Random.Range(0, 3);
            var furnitureCount = Random.Range(0, 3);
            
            _furnitureOrder = new Dictionary<int, int>
            {
                {furnitureID, furnitureCount}
            };
        }
        //---------------------------------------------------------------------------------------------------------------
        public int FinishOrder(Dictionary<int, int> providedOrder)
        {
            int price = 0;

            return price;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
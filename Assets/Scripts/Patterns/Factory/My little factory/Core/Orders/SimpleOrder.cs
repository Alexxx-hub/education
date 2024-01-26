using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Interfaces;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Core.Orders
{
    public class SimpleOrder : IOrder
    {
        public Dictionary<int, int> FurnitureOrder { get; }
        //---------------------------------------------------------------------------------------------------------------
        public SimpleOrder()
        {
            int furnitureID = Random.Range(0, 3);
            int furnitureCount = Random.Range(1, 3);

            FurnitureOrder = new Dictionary<int, int>
            {
                {furnitureID, furnitureCount}
            };
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
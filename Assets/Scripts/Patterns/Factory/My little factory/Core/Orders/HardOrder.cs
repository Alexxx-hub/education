using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Interfaces;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Core.Orders
{
    public class HardOrder : IOrder
    {
        public Dictionary<int, int> FurnitureOrder { get; }
        //---------------------------------------------------------------------------------------------------------------
        public HardOrder()
        {
            int furnitureID1 = 0;
            int furnitureID2 = 0;
            int furnitureID3 = 0;
            
            while (furnitureID2 == furnitureID1)
            {
                furnitureID2 = Random.Range(0, 3);
            }
            
            while (furnitureID3 == furnitureID2 || furnitureID3 == furnitureID1)
            {
                furnitureID3 = Random.Range(0, 3);
            }
            
            int furnitureCount1 = Random.Range(1, 3);
            int furnitureCount2 = Random.Range(1, 3);
            int furnitureCount3 = Random.Range(1, 3);

            FurnitureOrder = new Dictionary<int, int>
            {
                {furnitureID1, furnitureCount1},
                {furnitureID2, furnitureCount2},
                {furnitureID3, furnitureCount3}
            };
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
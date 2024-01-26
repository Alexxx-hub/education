using Patterns.Factory.My_little_factory.Furniture;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Factory.FurnitureFactory
{
    public class ChairCreator : FurnitureCreator
    {
        //---------------------------------------------------------------------------------------------------------------
        public override Furniture.Furniture CreateFurniture()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/My little factory/Furniture/Chair");
            var go = Object.Instantiate(prefab);
            var component = go.GetComponent<Chair>();

            return component;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
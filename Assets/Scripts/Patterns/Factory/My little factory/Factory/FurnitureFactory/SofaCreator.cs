using Patterns.Factory.My_little_factory.Furniture;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Factory.FurnitureFactory
{
    public class SofaCreator : FurnitureCreator
    {
        //---------------------------------------------------------------------------------------------------------------
        public override Furniture.Furniture CreateFurniture()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/My little factory/Furniture/Sofa");
            var go = Object.Instantiate(prefab);
            var component = go.GetComponent<Sofa>();

            return component;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
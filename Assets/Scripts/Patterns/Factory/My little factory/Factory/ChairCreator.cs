using Patterns.Factory.My_little_factory.Furniture;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Factory
{
    public class ChairCreator : FurnitureCreator
    {
        //---------------------------------------------------------------------------------------------------------------
        public override Furniture.Furniture CreateFurniture()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/My little factory/Furniture/Chair");
            var go = GameObject.Instantiate(prefab);
            var component = go.AddComponent<Chair>();

            return component;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
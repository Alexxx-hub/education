﻿using Patterns.Factory.My_little_factory.Furniture;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Factory.FurnitureFactory
{
    public class ChairCreator : FurnitureCreator
    {
        //---------------------------------------------------------------------------------------------------------------
        public override Furniture.Furniture CreateFurniture(Transform spawnPoint)
        {
            var prefab = Resources.Load<GameObject>("Prefabs/My little factory/Furniture/Chair");
            var go = Object.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            var component = go.GetComponent<Chair>();

            return component;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
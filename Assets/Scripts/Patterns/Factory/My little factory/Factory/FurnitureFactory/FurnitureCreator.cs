using UnityEngine;

namespace Patterns.Factory.My_little_factory.Factory.FurnitureFactory
{
    public abstract class FurnitureCreator
    {
        public abstract Furniture.Furniture CreateFurniture(Transform spawnPoint);

    }
}
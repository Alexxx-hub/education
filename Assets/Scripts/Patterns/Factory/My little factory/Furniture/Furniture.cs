using UnityEngine;

namespace Patterns.Factory.My_little_factory.Furniture
{
    public abstract class Furniture : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private int _price;
        
        public int ID => _id;
        public int Price => _price;
    }
}

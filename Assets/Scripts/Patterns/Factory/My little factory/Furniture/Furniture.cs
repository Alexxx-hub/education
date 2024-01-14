using UnityEngine;

namespace Patterns.Factory.My_little_factory.Furniture
{
    public abstract class Furniture : MonoBehaviour
    {
        [SerializeField] private int price;
    }
}

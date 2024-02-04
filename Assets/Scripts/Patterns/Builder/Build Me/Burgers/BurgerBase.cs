using UnityEngine;

public class BurgerBase : MonoBehaviour
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    public float Weight { get; private set; }

    protected GameObject[] _items;

    public void Construct(string name, float price, float weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
    
    public void SetupBurgerItems(GameObject[] elements)
    {
        _items = elements;

        foreach (var element in _items)
        {
            element.transform.SetParent(transform);
        }
    }
}
using UnityEngine;

public class BurgerBase : MonoBehaviour
{
    protected string _name;
    protected float _price;
    protected float _weight;
    
    protected GameObject[] _items;

    public void Construct(string name, float price, float weight)
    {
        _name = name;
        _price = price;
        _weight = weight;
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
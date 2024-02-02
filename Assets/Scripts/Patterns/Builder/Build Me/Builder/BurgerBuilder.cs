using System.Collections.Generic;
using UnityEngine;

public class BurgerBuilder
{
    private string _name;
    private float _price;
    private float _weight;
    private List<string> _items;
    
    private float _offset;
    private Vector3 _spawnPoint;
    private GameObject _panPrefab;
    
    private BurgerElement[] _burgerElements;

    public BurgerBuilder(BurgerElement[] elements, GameObject panPrefab, float offset, Vector3 spawnPoint)
    {
        _burgerElements = elements;
        _panPrefab = panPrefab;
        _offset = offset;
        _spawnPoint = spawnPoint;
        _items = new List<string>();
    }
    
    public virtual BurgerBuilder Clear()
    {
        _name = null;
        _price = 0;
        _weight = 0;
        _items.Clear();
        return this;
    }

    public virtual BurgerBuilder WithItem(string id)
    {
        _items.Add(id);
        return this;
    }
    
    public BurgerBuilder WithItem(List<string> items)
    {
        _items = items;
        return this;
    }

    public BurgerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public BurgerBuilder WithPrice(float price)
    {
        _price = price;
        return this;
    }

    public BurgerBuilder WithWeight(float weight)
    {
        _weight = weight;
        return this;
    }
    public BurgerBase Build()
    {
        BurgerBase burger = new GameObject(_name).AddComponent<BurgerBase>();
        GameObject[] currentElements = new GameObject[_items.Count + 2];
        
        Vector3 spawnPos = _spawnPoint;
        
        currentElements[0] = Object.Instantiate(_panPrefab, spawnPos, Quaternion.identity);
        
        for (int i = 0; i < _items.Count; i++)
        {
            spawnPos.y += _offset;
            currentElements[i + 1] = CreateNewElement(_items[i], spawnPos);
        }
        
        spawnPos.y += _offset;
        currentElements[^1] = Object.Instantiate(_panPrefab, spawnPos, Quaternion.identity);
        
        burger.Construct(_name, _price, _weight);
        burger.SetupBurgerItems(currentElements);

        return burger;
    }
    
    private GameObject CreateNewElement(string id, Vector3 spawnPosition)
    {
        foreach (var burgerElement in _burgerElements)
        {
            if (burgerElement.Name == id)
            {
                return Object.Instantiate(burgerElement.Prefab, spawnPosition, Quaternion.identity);
            }
        }

        return null;
    }
    
}
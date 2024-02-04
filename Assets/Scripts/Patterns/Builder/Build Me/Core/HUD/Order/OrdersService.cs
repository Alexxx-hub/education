using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class OrdersService
{
    public event Action<int> totalPriceCalculated;

    private Transform _parent;
    private GameObject _prefab;
    private List<OrderItem> OrderItems;
    
    public int TotalPrice { get; private set; }

    public OrdersService(GameObject prefab, Transform parent)
    {
        OrderItems = new List<OrderItem>();
        _prefab = prefab;
        _parent = parent;
        TotalPrice = 0;
    }
    
    public void AddNewItem(BurgerElement burgerElement)
    {
        OrderItem orderItem = Object.Instantiate(_prefab, _parent, false).GetComponent<OrderItem>();
        orderItem.Construct(burgerElement.Name, burgerElement.Price.ToString());
        OrderItems.Add(orderItem);
        TotalPrice += burgerElement.Price;
        
        totalPriceCalculated?.Invoke(TotalPrice);
    }

    public void ResetItems()
    {
        foreach (var item in OrderItems)
        {
            Object.Destroy(item.gameObject);
        }
        
        OrderItems.Clear();
        TotalPrice = 0;
        
        totalPriceCalculated?.Invoke(TotalPrice);
    }
    
    public void CancelOrder()
    {
        ResetItems();
    }
}
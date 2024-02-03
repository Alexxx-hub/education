using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class OrdersService
{
    public event Action<int> totalPriceCalculated;

    private int _totalPrice;
    
    private Transform _parent;
    private GameObject _prefab;
    private List<OrderItem> OrderItems;

    public OrdersService(GameObject prefab, Transform parent)
    {
        OrderItems = new List<OrderItem>();
        _prefab = prefab;
        _parent = parent;
        _totalPrice = 0;
    }
    
    public void AddNewItem(BurgerElement burgerElement)
    {
        OrderItem orderItem = Object.Instantiate(_prefab, _parent, false).GetComponent<OrderItem>();
        orderItem.Construct(burgerElement.Name, burgerElement.Price.ToString());
        OrderItems.Add(orderItem);
        _totalPrice += burgerElement.Price;
        
        totalPriceCalculated?.Invoke(_totalPrice);
    }

    public void ResetItems()
    {
        foreach (var item in OrderItems)
        {
            Object.Destroy(item.gameObject);
        }
        
        OrderItems.Clear();
        _totalPrice = 0;
        
        totalPriceCalculated?.Invoke(_totalPrice);
    }

    public void SendOrder()
    {
        
    }

    public void CancelOrder()
    {
        ResetItems();
    }
}
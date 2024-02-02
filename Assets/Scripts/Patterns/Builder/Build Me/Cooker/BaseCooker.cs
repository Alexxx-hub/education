using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCooker : MonoBehaviour
{
    public event Action<BaseCooker> OnItemChoosed;

    public MenuItem _menuItem;
    
    [SerializeField] protected TextMeshProUGUI _priceField;
    [SerializeField] protected TextMeshProUGUI _nameField;
    [SerializeField] protected Button _button;
    
    protected BurgerBuilder _burgerBuilder;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(BurgerBuilder burgerBuilder, MenuItem item)
    {
        _burgerBuilder = burgerBuilder;
        _menuItem = item;
        _priceField.text = _menuItem.Price.ToString();
        _nameField.text = _menuItem.Name;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        _button.onClick.AddListener(SendBurgerBuilder);
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
    //---------------------------------------------------------------------------------------------------------------
    private void SendBurgerBuilder()
    {
        OnItemChoosed?.Invoke(this);
    }
    //---------------------------------------------------------------------------------------------------------------
    public abstract BurgerBase Cook();
    //---------------------------------------------------------------------------------------------------------------
}
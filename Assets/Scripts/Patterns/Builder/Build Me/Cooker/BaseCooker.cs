using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCooker : MonoBehaviour
{
    public event Action<BaseCooker> OnItemChoosed;
    
    [SerializeField] protected TextMeshProUGUI _priceField;
    [SerializeField] protected TextMeshProUGUI _nameField;
    [SerializeField] protected Button _button;
    
    protected BurgerBuilder _burgerBuilder;
    
    public MenuItemData MenuItemData { get; private set; }
    public string Id {get; protected set; }
    public Button Button => _button;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(BurgerBuilder burgerBuilder, MenuItemData itemData)
    {
        _burgerBuilder = burgerBuilder;
        MenuItemData = itemData;
        _priceField.text = MenuItemData.Price.ToString();
        _nameField.text = MenuItemData.Name;
        Id = MenuItemData.Name;
    }
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Construct(BurgerBuilder burgerBuilder, List<string> itemsList){}
    //---------------------------------------------------------------------------------------------------------------
    protected virtual void OnEnable()
    {
        _button.onClick.AddListener(() => OnItemChoosed?.Invoke(this));
    }
    //---------------------------------------------------------------------------------------------------------------
    protected void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
    //---------------------------------------------------------------------------------------------------------------
    public abstract BurgerBase Cook();
    //---------------------------------------------------------------------------------------------------------------
}
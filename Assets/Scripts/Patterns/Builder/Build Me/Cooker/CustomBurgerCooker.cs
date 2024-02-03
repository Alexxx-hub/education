using System;
using System.Collections.Generic;

public class CustomBurgerCooker : BaseCooker
{
    private const int CUSTOM_BURGER_MINPRICE = 180;
    private const string CUSTOM_BURGER_NAME = "Custom Burger";
    
    private List<string> _items;
    //---------------------------------------------------------------------------------------------------------------
    public override void Construct(BurgerBuilder burgerBuilder, List<string> itemsList)
    {
        _burgerBuilder = burgerBuilder;
        _items = itemsList;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _priceField.text = CUSTOM_BURGER_MINPRICE.ToString();
        _nameField.text = CUSTOM_BURGER_NAME;
        Id = CUSTOM_BURGER_NAME;
    }
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName(CUSTOM_BURGER_NAME)
            .WithPrice(320)
            .WithWeight(450)
            .WithItem(_items)
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
    public void SetItems(List<string> items)
    {
        _items = items;
    }
    //---------------------------------------------------------------------------------------------------------------
}
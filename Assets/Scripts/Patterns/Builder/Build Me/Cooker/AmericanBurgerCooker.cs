﻿public class AmericanBurgerCooker : ICooker
{
    private BurgerBuilder _burgerBuilder;
    private MenuItem _menuItem;
    //---------------------------------------------------------------------------------------------------------------
    public AmericanBurgerCooker(BurgerBuilder burgerBuilder, MenuItem item)
    {
        _burgerBuilder = burgerBuilder;
        _menuItem = item;
    }
    //---------------------------------------------------------------------------------------------------------------
    public BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName(_menuItem.Name)
            .WithPrice(_menuItem.Price)
            .WithWeight(_menuItem.Weight)
            .WithItem("cabbage")
            .WithItem("kotlet")
            .WithItem("cheese")
            .WithItem("tomato")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
using System.Collections.Generic;

public class CustomBurgerCooker 
{
    private List<string> _items;
    private BurgerBuilder _burgerBuilder;
    
    public CustomBurgerCooker(BurgerBuilder burgerBuilder, List<string> items)
    {
        _burgerBuilder = burgerBuilder;
        _items = items;
    }
    
    public BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName("Custom Burger")
            .WithPrice(320)
            .WithWeight(450)
            .WithItem(_items)
            .Build();
    }
}
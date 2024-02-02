public class CheeseBurgerCooker : ICooker
{
    private BurgerBuilder _burgerBuilder;
    private MenuItem _menuItem;
    //---------------------------------------------------------------------------------------------------------------
    public CheeseBurgerCooker(BurgerBuilder burgerBuilder, MenuItem item)
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
            .WithItem("cheese")
            .WithItem("cabbage")
            .WithItem("tomato")
            .WithItem("cheese")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
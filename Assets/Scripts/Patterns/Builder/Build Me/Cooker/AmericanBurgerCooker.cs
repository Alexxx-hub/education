public class AmericanBurgerCooker : ICooker
{
    private BurgerBuilder _burgerBuilder;
    
    public AmericanBurgerCooker(BurgerBuilder burgerBuilder)
    {
        _burgerBuilder = burgerBuilder;
    }
    
    public BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName("American Burger")
            .WithPrice(120)
            .WithWeight(500)
            .WithItem("tomato")
            .WithItem("cheese")
            .Build();
    }
}
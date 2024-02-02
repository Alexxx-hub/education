public class CheeseBurgerCooker : BaseCooker
{
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
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
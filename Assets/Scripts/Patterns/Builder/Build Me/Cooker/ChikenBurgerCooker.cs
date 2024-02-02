public class ChikenBurgerCooker : BaseCooker
{
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName(_menuItem.Name)
            .WithPrice(_menuItem.Price)
            .WithWeight(_menuItem.Weight)
            .WithItem("cabbage")
            .WithItem("chiken")
            .WithItem("cheese")
            .WithItem("tomato")
            .WithItem("onion")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
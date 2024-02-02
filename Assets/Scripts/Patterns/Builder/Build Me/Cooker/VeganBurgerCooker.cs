public class VeganBurgerCooker : BaseCooker
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
            .WithItem("tomato")
            .WithItem("peeckle")
            .WithItem("bell paper")
            .WithItem("cabbage")
            .WithItem("onion")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
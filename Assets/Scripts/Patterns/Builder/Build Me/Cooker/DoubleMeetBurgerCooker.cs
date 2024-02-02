public class DoubleMeetBurgerCooker : BaseCooker
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
            .WithItem("kotlet")
            .WithItem("cheese")
            .WithItem("cabbage")
            .WithItem("kotlet")
            .WithItem("cheese")
            .WithItem("tomato")
            .WithItem("peeckle")
            .WithItem("onion")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
public class VeganBurgerCooker : BaseCooker
{
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName(MenuItemData.Name)
            .WithPrice(MenuItemData.Price)
            .WithWeight(MenuItemData.Weight)
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
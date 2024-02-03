public class AmericanBurgerCooker : BaseCooker
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
            .WithItem("kotlet")
            .WithItem("cheese")
            .WithItem("tomato")
            .WithItem("peeckle")
            .WithItem("onion")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
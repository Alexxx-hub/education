public class ChikenBurgerCooker : BaseCooker
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
            .WithItem("chiken")
            .WithItem("cheese")
            .WithItem("tomato")
            .WithItem("onion")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
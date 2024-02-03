public class CheeseBurgerCooker : BaseCooker
{
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
    {
        return _burgerBuilder
            .Clear()
            .WithName(MenuItemData.Name)
            .WithPrice(MenuItemData.Price)
            .WithWeight(MenuItemData.Weight)
            .WithItem("cheese")
            .WithItem("cabbage")
            .WithItem("tomato")
            .WithItem("cheese")
            .Build();
    }
    //---------------------------------------------------------------------------------------------------------------
}
public class CheeseBurger : MenuItem
{
    public override void Construct(BurgerBuilder builder)
    {
        base.Construct(builder);
        Cooker = new CheeseBurgerCooker(_burgerBuilder, this);
    }
}
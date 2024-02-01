public class AmericanBurger : MenuItem
{
    public override void Construct(BurgerBuilder builder)
    {
        base.Construct(builder);
        Cooker = new AmericanBurgerCooker(_burgerBuilder);
    }
}
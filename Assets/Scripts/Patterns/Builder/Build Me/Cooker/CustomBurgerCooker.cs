using System.Collections.Generic;

public class CustomBurgerCooker : BaseCooker
{
    private const int CUSTOM_BURGER_MINPRICE = 180;
    private const string CUSTOM_BURGER_NAME = "Custom Burger";
    
    private List<string> _items;
    //---------------------------------------------------------------------------------------------------------------
    public override void Construct(BurgerBuilder burgerBuilder)
    {
        _burgerBuilder = burgerBuilder;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _priceField.text = CUSTOM_BURGER_MINPRICE.ToString();
        _nameField.text = CUSTOM_BURGER_NAME;
        Id = CUSTOM_BURGER_NAME;
        _items = new List<string>();
    }
    //---------------------------------------------------------------------------------------------------------------
    public override BurgerBase Cook()
    {
        BurgerBase burger = _burgerBuilder
            .Clear()
            .WithName(CUSTOM_BURGER_NAME)
            .WithWeight(450)
            .WithItem(_items)
            .WithPrice()
            .Build();

        _items.Clear();

        return burger;
    }
    //---------------------------------------------------------------------------------------------------------------
    public void SetItems(BurgerElement burgerElement)
    {
        _items.Add(burgerElement.Name);
    }
    //---------------------------------------------------------------------------------------------------------------
}
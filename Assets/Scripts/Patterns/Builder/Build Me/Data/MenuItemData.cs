public class MenuItemData 
{ 
    private string _name; 
    private int _price; 
    private int _weight;

    public string Name => _name;
    public int Price => _price;
    public int Weight => _weight;
    //---------------------------------------------------------------------------------------------------------------
    public MenuItemData(string name, int price, int weight)
    {
        _name = name;
        _price = price;
        _weight = weight;
    }
    //---------------------------------------------------------------------------------------------------------------
}
using UnityEngine.UI;

public class IngridientPanel : UIElement
{
    private Button[] _ingridientButtons;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(Button[] ingridientButtons)
    {
        _ingridientButtons = ingridientButtons;
    }
    //---------------------------------------------------------------------------------------------------------------
}
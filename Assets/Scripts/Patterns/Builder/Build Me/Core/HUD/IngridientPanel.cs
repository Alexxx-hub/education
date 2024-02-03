public class IngridientPanel : UIElement
{
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        ContentArea.gameObject.SetActive(false);
        _opened = false;
    }
    //---------------------------------------------------------------------------------------------------------------
    public void OnCookerChoosed(BaseCooker cooker)
    {
        if (cooker.Id == "Custom Burger" && !_opened)
        {
            Show();
        }
        else if(cooker.Id != "Custom Burger")
        {
            Hide();
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}
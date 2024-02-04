public class IngridientPanel : UIElement
{
    private IngridientPanelService _ingridientPanelService;
    private Level _level;
    private OrderPanel _orderPanel;
    private MenuPanel _menuPanel;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(Level level, OrderPanel orderPanel, MenuPanel menuPanel)
    {
        _ingridientPanelService = new IngridientPanelService(level.LevelConfig, ContentArea);
        _level = level;
        _orderPanel = orderPanel;
        _menuPanel = menuPanel;
        
        _orderPanel.panelOpened += SubscribeButtons;
        _orderPanel.panelClosed += UnSubscribeButtons;
        _orderPanel.panelClosed += Hide;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        ContentArea.gameObject.SetActive(false);
        _opened = false;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        if (_orderPanel != null)
        {
            _orderPanel.panelOpened += SubscribeButtons;
            _orderPanel.panelClosed += UnSubscribeButtons;
            _orderPanel.panelClosed += Hide;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        _orderPanel.panelOpened -= SubscribeButtons;
        _orderPanel.panelClosed -= UnSubscribeButtons;
        _orderPanel.panelClosed -= Hide;
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
    private void SubscribeButtons()
    {
        foreach (var ingridientButton in _ingridientPanelService.IngridientButtons)
        {
            ingridientButton.itemChoosed += _menuPanel.MenuService.CustomBurgerCooker.SetItems;
            ingridientButton.itemChoosed += _orderPanel.OrdersService.AddNewItem;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    private void UnSubscribeButtons()
    {
        foreach (var ingridientButton in _ingridientPanelService.IngridientButtons)
        {
            ingridientButton.itemChoosed -= _menuPanel.MenuService.CustomBurgerCooker.SetItems;
            ingridientButton.itemChoosed -= _orderPanel.OrdersService.AddNewItem;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}
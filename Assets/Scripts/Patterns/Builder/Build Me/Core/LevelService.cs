using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
    public delegate void myDelegate();
    
    public List<string> items;

    [SerializeField] private float _offset;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private MenuConfig _menuConfig;
    [SerializeField] private IngridientPanel _ingridientPanel;
    [SerializeField] private MenuPanel _menuPanel;
    [SerializeField] private OrderPanel _orderPanel;

    private BurgerBuilder _burgerBuilder;
    private BaseCooker _cooker;

    private MenuService _menuService;
    private IngridientPanelService _ingridientPanelService;
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _ingridientPanelService = new IngridientPanelService(_levelConfig, _ingridientPanel.ContentArea);
        
        _burgerBuilder = new BurgerBuilder(_levelConfig.BurgerElements, _levelConfig.Pan.Prefab, _offset, _spawnPoint.position);
        _menuService = new MenuService(_burgerBuilder, this, _ingridientPanel, _menuConfig, _menuPanel.ContentArea);
        _menuService.CustomBurgerCooker.Button.onClick.AddListener(_menuPanel.SwitchState);
        _menuService.CustomBurgerCooker.Button.onClick.AddListener(_orderPanel.Show);

        items = new List<string>();

        foreach (var ingridientButton in _ingridientPanelService.IngridientButtons)
        {
            ingridientButton.itemChoosed += GetItem;
            ingridientButton.itemChoosed += _orderPanel.OrdersService.AddNewItem;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BurgerBase burger = _cooker.Cook();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            _cooker.Construct(_burgerBuilder, items);
            BurgerBase burger = _cooker.Cook();
            items.Clear();
        }
    }
    //---------------------------------------------------------------------------------------------------------------
    public void GetCooker(BaseCooker cooker)
    {
        _cooker = cooker;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void GetItem(BurgerElement burgerElement)
    {
        items.Add(burgerElement.Name);
    }
    //---------------------------------------------------------------------------------------------------------------
}
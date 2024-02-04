using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIElement
{
    [Header("Animation settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _openPosition;
    [SerializeField] private float _closePosition;
    
    [Header("Content")]
    [SerializeField] private Button _openButton;

    private RectTransform _rectTransform;
    public MenuService MenuService { get; private set; }
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(Level level, IngridientPanel ingridientPanel, OrderPanel orderPanel)
    {
        MenuService = new MenuService(level.BurgerBuilder, level, ingridientPanel, level.MenuConfig, ContentArea);
        MenuService.CustomBurgerCooker.Button.onClick.AddListener(orderPanel.Show);
        MenuService.CustomBurgerCooker.Button.onClick.AddListener(SwitchState);
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _openButton.onClick.AddListener(SwitchState);
        _rectTransform = GetComponent<RectTransform>();
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        _openButton.onClick.RemoveAllListeners();
    }
    //---------------------------------------------------------------------------------------------------------------
    public void SwitchState()
    {
        if (_opened)
        {
            _rectTransform.DOMoveX(_closePosition, _speed);
            _opened = false;
        }
        else
        {
            _rectTransform.DOMoveX(_openPosition, _speed);
            _opened = true;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}
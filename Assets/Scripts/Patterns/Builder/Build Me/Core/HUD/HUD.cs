using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private MenuPanel _menuPanel;
    [SerializeField] private IngridientPanel _ingridientPanel;
    [SerializeField] private TextMeshProUGUI _moneyTextBox;
    
    [field: SerializeField] public OrderPanel OrderPanel { get; private set; }

    private float _moneyBarValue;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(Level level)
    {
        _ingridientPanel.Construct(level, OrderPanel, _menuPanel);
        _menuPanel.Construct(level, _ingridientPanel, OrderPanel);
    }
    //---------------------------------------------------------------------------------------------------------------
    public void UpdateMoneyTextBox(float value)
    {
        _moneyBarValue += value;
        _moneyTextBox.text = $"{_moneyBarValue}$";
    }
    //---------------------------------------------------------------------------------------------------------------
}
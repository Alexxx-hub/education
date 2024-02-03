using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : UIElement
{
    [Header("Buttons")]
    [SerializeField] private Button _canelButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _acceptButton;
    
    [Header("Content")]
    [SerializeField] private Transform _orderArea;
    [SerializeField] private GameObject _orderItemPrefab;
    [SerializeField] private TextMeshProUGUI _totalTextBox;

    public OrdersService OrdersService { get; private set; }
    
    private void Awake()
    {
        ContentArea.gameObject.SetActive(false);
        _opened = false;
        OrdersService = new OrdersService(_orderItemPrefab, _orderArea);
    }

    private void OnEnable()
    {
        _resetButton.onClick.AddListener(OrdersService.ResetItems);
        _canelButton.onClick.AddListener(OrdersService.CancelOrder);
        _canelButton.onClick.AddListener(Hide);

        OrdersService.totalPriceCalculated += UpdateTotalPrice;
    }

    private void OnDisable()
    {
        _resetButton.onClick.RemoveAllListeners();
        
        OrdersService.totalPriceCalculated -= UpdateTotalPrice;
    }

    private void UpdateTotalPrice(int totalPrice)
    {
        _totalTextBox.text = totalPrice.ToString();
    }
}
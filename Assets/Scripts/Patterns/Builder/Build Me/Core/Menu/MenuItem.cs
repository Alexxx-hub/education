using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuItem : MonoBehaviour
{
    public event Action<ICooker> OnItemChoosed;

    [SerializeField] protected string _name;
    [SerializeField] protected float _price;
    [SerializeField] protected float _weight; 
    
    [SerializeField] protected TextMeshProUGUI _priceField;
    [SerializeField] protected TextMeshProUGUI _nameField;
    [SerializeField] protected Button _button;

    protected BurgerBuilder _burgerBuilder;

    public ICooker Cooker { get; protected set; }
    
    public string Name => _name;
    public float Price => _price;
    public float Weight => _weight;
    //---------------------------------------------------------------------------------------------------------------
    public virtual void Construct(BurgerBuilder builder)
    {
        _burgerBuilder = builder;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        _button.onClick.AddListener(SendBurgerBuilder);
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
    //---------------------------------------------------------------------------------------------------------------
    protected void Awake()
    {
        _priceField.text = _price.ToString();
        _nameField.text = _name;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void SendBurgerBuilder()
    {
        OnItemChoosed?.Invoke(Cooker);
    }
    //---------------------------------------------------------------------------------------------------------------
}
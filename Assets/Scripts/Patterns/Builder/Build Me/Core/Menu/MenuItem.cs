using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuItem : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected float _price;
    [SerializeField] protected float _weight; 
    
    [SerializeField] protected TextMeshProUGUI _priceField;
    [SerializeField] protected TextMeshProUGUI _nameField;
    [SerializeField] protected Button _button;

    protected BurgerBuilder _burgerBuilder;

    public ICooker Cooker { get; protected set; }
    
    public virtual void Construct(BurgerBuilder builder)
    {
        _burgerBuilder = builder;
    }
    
    protected void Awake()
    {
        _priceField.text = _price.ToString();
        _nameField.text = _name;
    }
    
}
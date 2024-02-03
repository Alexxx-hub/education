using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngridientButton : MonoBehaviour
{
    public event Action<BurgerElement> itemChoosed;

    private TextMeshProUGUI _buttonText;
    
    public BurgerElement BurgerElement { get; private set; }
    public Button Button { get; private set; }
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(BurgerElement burgerElement)
    {
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();

        BurgerElement = burgerElement;
        _buttonText.text = burgerElement.Name;
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        Button = GetComponent<Button>();
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnEnable()
    {
        Button.onClick.AddListener(() => itemChoosed?.Invoke(BurgerElement));
    }
    //---------------------------------------------------------------------------------------------------------------
    private void OnDisable()
    {
        Button.onClick.RemoveAllListeners();
    }
    //---------------------------------------------------------------------------------------------------------------
}
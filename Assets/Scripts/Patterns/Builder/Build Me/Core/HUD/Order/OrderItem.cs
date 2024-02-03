using UnityEngine;
using TMPro;

public class OrderItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTextBox;
    [SerializeField] private TextMeshProUGUI _priceTextBox;

    public void Construct(string name, string price)
    {
        _nameTextBox.text = name;
        _priceTextBox.text = price;
    }
}
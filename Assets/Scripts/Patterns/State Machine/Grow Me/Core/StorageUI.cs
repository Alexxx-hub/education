using UnityEngine;
using TMPro;

public class StorageUI : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI WeatTextbox { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Corn { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Oats { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Rice { get; private set; }

    private void Start()
    {
        WeatTextbox.text = "weat: 0";
        Corn.text = "corn: 0";
        Oats.text = "oats: 0";
        Rice.text = "rice: 0";
    }

    public void UpdateUI(string id, float value)
    {
        switch (id) 
        {
            case "wheat":
                WeatTextbox.text = $"weat: {value}";
                break;
            case "corn":
                Corn.text = $"corn: {value}";
                break;
            case "oats":
                Oats.text = $"oats: {value}";
                break;
            case "rice":
                Rice.text = $"rice: {value}";
                break;

        }
    }
}

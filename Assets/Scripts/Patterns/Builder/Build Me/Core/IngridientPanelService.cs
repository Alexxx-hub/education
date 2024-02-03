using UnityEngine;
using Object = UnityEngine.Object;

public class IngridientPanelService
{
    public IngridientButton[] IngridientButtons { get; }
    
    public IngridientPanelService(LevelConfig levelConfig, Transform parent)
    { 
        IngridientButtons = new IngridientButton[levelConfig.BurgerElements.Length];

        for (int i = 0; i < IngridientButtons.Length; i++)
        {
            IngridientButtons[i] = Object.Instantiate(levelConfig.IngridientButtonPrefab, parent, true).GetComponent<IngridientButton>();
            IngridientButtons[i].Construct(levelConfig.BurgerElements[i]);
        }
    }
}
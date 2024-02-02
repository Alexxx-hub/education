using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuConfig _menuConfig;
    [SerializeField] private Transform _contentArea;

    private List<MenuItem> _menuItemsData;
    private DataLoader _dataLoader;
    //---------------------------------------------------------------------------------------------------------------
    public void Construct(BurgerBuilder builder, LevelService levelService)
    {
        _menuItemsData = new List<MenuItem>();
        
        _dataLoader = new DataLoader(_menuConfig.DataFile);
        _menuItemsData = _dataLoader.Load();
        
        for (int i = 0; i < _menuConfig.MenuItems.Length; i++)
        {
            var item = _menuConfig.MenuItems[i];
            BaseCooker cooker = Instantiate(item, _contentArea, false).GetComponent<BaseCooker>();
            cooker.Construct(builder, _menuItemsData[i]);
            cooker.OnItemChoosed += levelService.GetCooker;
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}
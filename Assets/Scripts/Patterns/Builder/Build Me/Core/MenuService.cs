﻿using System.Collections.Generic;
using UnityEngine;

public class MenuService 
{
    private List<MenuItemData> _menuItemsData;
    private DataLoader _dataLoader;

    public CustomBurgerCooker CustomBurgerCooker { get; }
    //---------------------------------------------------------------------------------------------------------------
    public MenuService(BurgerBuilder builder, LevelService levelService, IngridientPanel ingridientPanel, MenuConfig menuConfig, Transform contentArea)
    {
        _menuItemsData = new List<MenuItemData>();
        
        _dataLoader = new DataLoader(menuConfig.DataFile);
        _menuItemsData = _dataLoader.Load();
        
        for (int i = 0; i < menuConfig.MenuItems.Length; i++)
        {
            var item = menuConfig.MenuItems[i];
            BaseCooker cooker = Object.Instantiate(item, contentArea, false).GetComponent<BaseCooker>();
            cooker.Construct(builder, _menuItemsData[i]);
            cooker.OnItemChoosed += levelService.GetCooker;
            cooker.OnItemChoosed += ingridientPanel.OnCookerChoosed;
        }
        
        CustomBurgerCooker = Object.Instantiate(menuConfig.CustomBurgerMenuItem, contentArea, false).GetComponent<CustomBurgerCooker>();
        //CustomBurgerCooker.Construct(builder);
        CustomBurgerCooker.OnItemChoosed += levelService.GetCooker;
        CustomBurgerCooker.OnItemChoosed += ingridientPanel.OnCookerChoosed;
    }
    //---------------------------------------------------------------------------------------------------------------
}
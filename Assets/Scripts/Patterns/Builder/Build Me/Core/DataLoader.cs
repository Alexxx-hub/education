using System;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader
{
    private const int NAME = 0;
    private const int PRICE = 1;
    private const int WEIGHT = 2;
    
    private TextAsset _dataFile;
    //---------------------------------------------------------------------------------------------------------------
    public DataLoader(TextAsset textAsset)
    {
        _dataFile = textAsset;
    }
    //---------------------------------------------------------------------------------------------------------------
    public List<MenuItem> Load()
    {
        List<MenuItem> menuItemsData = new List<MenuItem>();
        
        string[] rows = _dataFile.text.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        int dataStartRowIndex = 1;

        for (int i = dataStartRowIndex; i < rows.Length; i++)
        {
            string[] cells = rows[i].Split(";");
            
            menuItemsData.Add(new MenuItem(cells[NAME], Int32.Parse(cells[PRICE]), Int32.Parse(cells[WEIGHT])));
        }

        return menuItemsData;
    }
    //---------------------------------------------------------------------------------------------------------------
}
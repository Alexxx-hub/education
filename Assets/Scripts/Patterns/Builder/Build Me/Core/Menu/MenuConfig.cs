﻿using UnityEngine;

[CreateAssetMenu(fileName = "Builder", menuName = "Menu/New Menu Config")]
public class MenuConfig : ScriptableObject
{
    [SerializeField] private TextAsset _dataFile;
    [SerializeField] private GameObject[] _menuItems;

    public GameObject[] MenuItems => _menuItems;
    public TextAsset DataFile => _dataFile;
}
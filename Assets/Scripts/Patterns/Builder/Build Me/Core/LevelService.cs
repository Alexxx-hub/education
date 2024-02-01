﻿using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
    public List<string> items;

    [SerializeField] private float _offset;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private LevelConfig _levelConfig;

    [SerializeField] private Menu _menu;

    private BurgerBuilder _burgerBuilder;
    private ICooker _cooker;
    //---------------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _burgerBuilder = new BurgerBuilder(_levelConfig.BurgerElements, _levelConfig.Pan.prefab, _offset, _spawnPoint.position);
       _menu.Construct(_burgerBuilder);
    }
    //---------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BurgerBase burger = _cooker.Cook();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            _cooker = new CustomBurgerCooker(_burgerBuilder, items);
            BurgerBase burger = _cooker.Cook();
        }
    }
    //---------------------------------------------------------------------------------------------------------------
}
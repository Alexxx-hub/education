﻿using Patterns.Factory.My_little_factory.Core.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Factory.My_little_factory.Core
{
    public class LevelService : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _totalProfitText;
        
        [Space(10)]
        [Header("Control Buttons")]
        [SerializeField] private Button _createChairButton;
        [SerializeField] private Button _createSofaButton;
        [SerializeField] private Button _createTableButton;
        [SerializeField] private Button _finishorderButton;
        
        [Space(10)]
        [SerializeField] private FurnitureFactory _furnitureFactory;
        [SerializeField] private OrderService _ordersService;

        private int _totalProfit;
        private ControlPanelService _controlPanelService;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            _furnitureFactory.OnFinishOrder += _ordersService.FinishOrder;
            _ordersService.OnCalculateProfit += UpdateProfit;
            _controlPanelService.OnButtonsSwitch += SwitchButtons;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _furnitureFactory.OnFinishOrder -= _ordersService.FinishOrder;
            _ordersService.OnCalculateProfit -= UpdateProfit;
            _controlPanelService.OnButtonsSwitch -= SwitchButtons;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _controlPanelService = new ControlPanelService(_createChairButton, _createSofaButton, _createTableButton, _finishorderButton);
            
            _furnitureFactory.Construct(_controlPanelService);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void UpdateProfit(int profit)
        {
            _totalProfit += profit;
            _totalProfitText.text = $"{_totalProfit}$";
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SwitchButtons()
        {
            _createChairButton.interactable = !_createChairButton.interactable;
            _createSofaButton.interactable = !_createSofaButton.interactable;
            _createTableButton.interactable = !_createTableButton.interactable;
            _finishorderButton.interactable = !_finishorderButton.interactable;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
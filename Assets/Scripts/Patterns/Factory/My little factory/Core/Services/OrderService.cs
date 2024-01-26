using System;
using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Factory.OrderFactory;
using Patterns.Factory.My_little_factory.Interfaces;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory.My_little_factory.Core.Services
{
    public class OrderService : MonoBehaviour
    {
        public event Action<int> OnCalculateProfit; 

        [SerializeField] private TextMeshProUGUI[] _ordersTexts;

        private int _currentProfit;
        private Dictionary<int, OrderCreator> _ordersCreators;
        private IOrder _currentOrder;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _ordersCreators = new Dictionary<int, OrderCreator>()
            {
                {0, new SimpleOrderCreator()},
                {1, new MiddleOrderCreator()},
                {2, new HardOrderCreator()}
            };
            
            GetNewOrder();
        }
        //---------------------------------------------------------------------------------------------------------------
        public void FinishOrder(List<Furniture.Furniture> furnitures)
        {
            _currentProfit = 0;

            for (int i = 0; i < furnitures.Count; i++)
            {
                if (_currentOrder.FurnitureOrder.ContainsKey(furnitures[i].ID))
                {
                    _currentProfit += furnitures[i].Price;
                }
                else
                {
                    _currentProfit -= (int)(furnitures[i].Price * 0.1f);
                }
            }

            OnCalculateProfit?.Invoke(_currentProfit);
            GetNewOrder();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void GetNewOrder()
        {
            var key = Random.Range(0, _ordersCreators.Count);

            _currentOrder = _ordersCreators[key].CreateOrder();

            // update order panel
            for (int i = 0; i < _ordersTexts.Length; i++)
            {
                if (_currentOrder.FurnitureOrder.ContainsKey(i))
                {
                    ResetOrderTexts(i);
                    _ordersTexts[i].text += $"x{_currentOrder.FurnitureOrder[i]}";
                    _ordersTexts[i].transform.SetAsFirstSibling();
                }
                else
                {
                    _ordersTexts[i].text = "";
                    _ordersTexts[i].transform.SetAsLastSibling();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResetOrderTexts(int id)
        {
            switch (id)
            {
                case 0:
                    _ordersTexts[id].text = "Chair : ";
                    break;
                case 1:
                    _ordersTexts[id].text = "Sofa : ";
                    break;
                case 2:
                    _ordersTexts[id].text = "Table : ";
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
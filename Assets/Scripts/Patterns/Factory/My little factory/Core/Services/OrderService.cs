using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Factory.OrderFactory;
using Patterns.Factory.My_little_factory.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory.My_little_factory.Core.Services
{
    public class OrderService : MonoBehaviour
    {
        private Dictionary<int, OrderCreator> _ordersCreators;

        private IOrder _currentOrder;

        private void Awake()
        {
            _ordersCreators = new Dictionary<int, OrderCreator>()
            {
                {0, new SimpleOrderCreator()}
            };
        }

        private IOrder GetNewOrder()
        {
            var key = Random.Range(0, _ordersCreators.Count);

            return _ordersCreators[key].CreateOrder();
        }
    }
}
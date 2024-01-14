using UnityEngine;

namespace Patterns.Factory.My_little_factory.Core.Orders
{
    public class PriceListService : MonoBehaviour
    {
        [SerializeField] private int _chairPrice;
        [SerializeField] private int _sofaPrice;
        [SerializeField] private int _tablePrice;

        private int[] _priceList;

        public int[] PriceList => _priceList;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _priceList = new[]
            {
                _chairPrice,
                _sofaPrice,
                _tablePrice
            };
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
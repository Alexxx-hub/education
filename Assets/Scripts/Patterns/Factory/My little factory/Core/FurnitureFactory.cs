using System;
using System.Collections.Generic;
using Patterns.Factory.My_little_factory.Core.Services;
using Patterns.Factory.My_little_factory.Factory.FurnitureFactory;
using UnityEngine;

namespace Patterns.Factory.My_little_factory.Core
{
    public class FurnitureFactory : MonoBehaviour
    {
        public event Action<List<Furniture.Furniture>> OnFinishOrder;

        [SerializeField] private float _timeToWork;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _spawnPoint;

        private int _currentId;
        private bool _isWorking;
        private float _currentWorkTime;
        private List<Furniture.Furniture> _producedFurnitures;
        private FurnitureCreator _currentFurnitureCreator;
        
        private ControlPanelService _controlPanelService;
        //---------------------------------------------------------------------------------------------------------------
        public void Construct(ControlPanelService controlPanelService)
        {
            _controlPanelService = controlPanelService;
            
            _controlPanelService.OnFurnitureChoose += CreateFurniture;
            _controlPanelService.OnFinishButtonDown += SendOrder;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            _controlPanelService.OnFurnitureChoose -= CreateFurniture;
            _controlPanelService.OnFinishButtonDown -= SendOrder;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _producedFurnitures = new List<Furniture.Furniture>();
            _isWorking = false;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (_isWorking)
            {
                _currentWorkTime += Time.deltaTime;
                
                if (_currentWorkTime >= _timeToWork)
                {
                    _currentWorkTime = 0;
                    _isWorking = false;
                    _animator.SetInteger("Id", _currentId);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateFurniture(FurnitureCreator furnitureCreator, int id)
        {
            _isWorking = true;
            _animator.SetTrigger("StartWork");
            _currentId = id;
            _currentFurnitureCreator = furnitureCreator;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void FinishFurniture()
        {
            _producedFurnitures.Add(_currentFurnitureCreator.CreateFurniture(_spawnPoint));
            _animator.SetInteger("Id", -1);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendOrder()
        {
            OnFinishOrder?.Invoke(_producedFurnitures);

            foreach (var furniture in _producedFurnitures)
            {
                furniture.ReleaseFurniture();
            }
            
            _producedFurnitures.Clear();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
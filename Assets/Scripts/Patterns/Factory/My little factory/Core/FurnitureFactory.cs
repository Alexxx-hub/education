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
        
        private List<Furniture.Furniture> _producedFurnitures;
        
        private ControlPanelService _controlPanelService;
        //---------------------------------------------------------------------------------------------------------------
        public void Construct(ControlPanelService controlPanelService)
        {
            _controlPanelService = controlPanelService;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
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
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateFurniture(FurnitureCreator furnitureCreator)
        {
            _producedFurnitures.Add(furnitureCreator.CreateFurniture());
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SendOrder()
        {
            OnFinishOrder?.Invoke(_producedFurnitures);
            _producedFurnitures.Clear();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
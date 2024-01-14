using System;
using Patterns.Factory.My_little_factory.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Factory.My_little_factory.Core.Services
{
    [Serializable]
    public class ControlPanelService
    {
        public event Action<FurnitureCreator> OnFurnitureChoose;

        private ChairCreator _chairCreator;
        private SofaCreator _sofaCreator;
        private TableCreator _tableCreator;
        //---------------------------------------------------------------------------------------------------------------
        public ControlPanelService(params Button[] buttons)
        {
            _chairCreator = new ChairCreator();
            _sofaCreator = new SofaCreator();
            _tableCreator = new TableCreator();
            
            buttons[0].onClick.AddListener(CreateChair);
            buttons[1].onClick.AddListener(CreateSofa);
            buttons[2].onClick.AddListener(CreateTable);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateChair()
        {
            OnFurnitureChoose?.Invoke(_chairCreator);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateSofa()
        {
            OnFurnitureChoose?.Invoke(_sofaCreator);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateTable()
        {
            OnFurnitureChoose?.Invoke(_tableCreator);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
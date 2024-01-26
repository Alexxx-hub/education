using System;
using Patterns.Factory.My_little_factory.Factory;
using Patterns.Factory.My_little_factory.Factory.FurnitureFactory;
using UnityEngine.UI;

namespace Patterns.Factory.My_little_factory.Core.Services
{
    [Serializable]
    public class ControlPanelService
    {
        public event Action<FurnitureCreator> OnFurnitureChoose;
        public event Action OnFinishButtonDown;

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
            buttons[3].onClick.AddListener(FinishOrder);
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
        private void FinishOrder()
        {
            OnFinishButtonDown?.Invoke();;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
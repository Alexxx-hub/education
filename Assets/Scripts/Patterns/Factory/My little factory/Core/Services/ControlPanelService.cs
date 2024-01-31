using System;
using Patterns.Factory.My_little_factory.Factory.FurnitureFactory;
using UnityEngine.UI;

namespace Patterns.Factory.My_little_factory.Core.Services
{
    [Serializable]
    public class ControlPanelService
    {
        public event Action<FurnitureCreator, int> OnFurnitureChoose;
        public event Action OnFinishButtonDown;
        public event Action OnButtonsSwitch;

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
        public void EnableButton()
        {
            OnButtonsSwitch?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateChair()
        {
            OnFurnitureChoose?.Invoke(_chairCreator, 0);
            OnButtonsSwitch?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateSofa()
        {
            OnFurnitureChoose?.Invoke(_sofaCreator, 1);
            OnButtonsSwitch?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void CreateTable()
        {
            OnFurnitureChoose?.Invoke(_tableCreator, 2);
            OnButtonsSwitch?.Invoke();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void FinishOrder()
        {
            OnFinishButtonDown?.Invoke();;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
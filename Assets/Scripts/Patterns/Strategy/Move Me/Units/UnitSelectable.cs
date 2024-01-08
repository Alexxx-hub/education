using Patterns.Strategy.Move_Me.Core;
using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public abstract class UnitSelectable : UnitBase, ISelectable
    {
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private Color _selectedColor;
        
        private string[] _commands; 
        private ObjectColorProvider _objectColorProvider;
        //---------------------------------------------------------------------------------------------------------------
        protected virtual void Awake()
        {
            Color[] colors = {_defaultColor, _hoverColor, _selectedColor};
            _objectColorProvider = new ObjectColorProvider(GetComponent<MeshRenderer>(), colors);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnMouseOver()
        {
            _objectColorProvider.SetObjectColor(SelectedColor.Default);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnMouseExit()
        {
            _objectColorProvider.SetObjectColor(SelectedColor.Hover);
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void SetCommands(string[] cmd)
        {
            _commands = cmd;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Select()
        {
            UnitSignalsService.SendSelectedUnit(this, _commands);
            _objectColorProvider.SetObjectColor(SelectedColor.Selected);
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Deselect()
        {
            _objectColorProvider.SetObjectColor(SelectedColor.Default);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
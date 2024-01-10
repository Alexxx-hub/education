using System;
using System.Collections.Generic;
using Patterns.Strategy.Move_Me.Core;
using Patterns.Strategy.Move_Me.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Units
{
    public abstract class UnitSelectable : UnitBase, ISelectable
    {
        public Vector3 pointToMove;
        public Vector3[] path;
        public Transform target;
        
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private Color _selectedColor;

        protected MoveCommands _currentCommand;
        protected Dictionary<string, Action> _commands; 
        private ObjectColorProvider _objectColorProvider;

        public Dictionary<string, Action> Commands => _commands;
        //---------------------------------------------------------------------------------------------------------------
        protected virtual void Awake()
        {
            Color[] colors = {_defaultColor, _hoverColor, _selectedColor};
            _currentCommand = MoveCommands.None;
            _objectColorProvider = new ObjectColorProvider(GetComponent<MeshRenderer>(), colors);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnMouseOver()
        {
            _objectColorProvider.SetObjectColor(SelectedColor.Hover);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnMouseExit()
        {
            _objectColorProvider.SetObjectColor(SelectedColor.Default);
        } 
        //---------------------------------------------------------------------------------------------------------------
        public void Select()
        {
            UnitSignalsService.SendSelectedUnit(this);
            _objectColorProvider.SetObjectColor(SelectedColor.Selected);
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Deselect()
        {
            _objectColorProvider.Deselect();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
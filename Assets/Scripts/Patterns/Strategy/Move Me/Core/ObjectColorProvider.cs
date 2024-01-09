using System;
using UnityEngine;

namespace Patterns.Strategy.Move_Me.Core
{
    public enum SelectedColor
    {
        Default,
        Hover,
        Selected,
    }
    
    [Serializable]
    public class ObjectColorProvider
    {
        private Color[] _colors;
        private bool _isSelected;
        private MeshRenderer _meshRenderer;
        private MaterialPropertyBlock _materialPropertyBlock;
        //---------------------------------------------------------------------------------------------------------------
        public ObjectColorProvider(MeshRenderer meshRenderer, Color[] colors)
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
            _meshRenderer = meshRenderer;
            _colors = new Color[colors.Length];

            for (int i = 0; i < colors.Length; i++)
            {
                _colors[i] = colors[i];
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public void SetObjectColor(SelectedColor value)
        {
            switch (value)
            {
                case SelectedColor.Default:
                    if(_isSelected) return;
                    _materialPropertyBlock.SetColor("_BaseColor", _colors[0]);
                    _meshRenderer.SetPropertyBlock(_materialPropertyBlock, 0);
                    break;
                case SelectedColor.Hover:
                    if(_isSelected) return;
                    _materialPropertyBlock.SetColor("_BaseColor", _colors[1]);
                    _meshRenderer.SetPropertyBlock(_materialPropertyBlock, 0);
                    break;
                case SelectedColor.Selected:
                    _isSelected = true;
                    _materialPropertyBlock.SetColor("_BaseColor", _colors[2]);
                    _meshRenderer.SetPropertyBlock(_materialPropertyBlock, 0);
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Deselect()
        {
            _isSelected = false;
            SetObjectColor(SelectedColor.Default);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
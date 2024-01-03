using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class ButtonService : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Color32 _selectedButtonColor;
        [SerializeField] private Color32 _textColorBase;
        [SerializeField] private Color32 _textColorSelected;
        
        [Space(10)]
        [Header("Color Block")]
        [Space(10)]
        [SerializeField] private ColorBlock _ColorBlock;

        private Button _animalButton;
        private TextMeshProUGUI _buttonText;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            GameSignalService.OnButtonSelected += SelectButton;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            GameSignalService.OnButtonSelected -= SelectButton;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            SetButtonStyle();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SelectButton(Button button)
        {
            if(_animalButton != null)
            {
                _animalButton.colors = _ColorBlock;
                _buttonText.color = _textColorBase;
            }
            
            _buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            _animalButton = button;
            
            ColorBlock colorBlock = _ColorBlock;
            colorBlock.normalColor = _selectedButtonColor;
            colorBlock.highlightedColor = _selectedButtonColor;
            colorBlock.pressedColor = _selectedButtonColor;
            
            _animalButton.colors = colorBlock;
            _buttonText.color = _textColorSelected;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SetButtonStyle()
        {
            foreach (var btn in _buttons)
            {
                btn.colors = _ColorBlock;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
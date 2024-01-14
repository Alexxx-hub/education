using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho.Core
{
    public class AnimalPanelService : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Color32 _selectedButtonColorCorrect;
        [SerializeField] private Color32 _selectedButtonColorWrong;
        [SerializeField] private Color32 _textColorBase;
        [SerializeField] private Color32 _textColorSelected;
        
        [Space(10)]
        [Header("Color Block")]
        [Space(10)]
        [SerializeField] private ColorBlock _ColorBlock;

        private int _hiddenAnimalId;
        private Button _animalButton;
        private TextMeshProUGUI[] _buttonsTextFields;
        private TextMeshProUGUI _selectedButtonTextField;
        private ButtonService[] _buttonServices;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            GameSignalService.OnShakeCards += ResetButton;
            GameSignalService.OnButtonPressed += SelectButton;
            GameSignalService.OnAnimalCoocked += GetHiddenAnimalId;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            GameSignalService.OnShakeCards -= ResetButton;
            GameSignalService.OnButtonPressed -= SelectButton;
            GameSignalService.OnAnimalCoocked -= GetHiddenAnimalId;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            SetButtonStyle();

            _buttonServices = new ButtonService[_buttons.Length];
            _buttonsTextFields = new TextMeshProUGUI[_buttons.Length];
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttonServices[i] = _buttons[i].GetComponent<ButtonService>();
                _buttonsTextFields[i] = _buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                _buttonServices[i].id = i;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void GetHiddenAnimalId(int id)
        {
            _hiddenAnimalId = id;
            EnableButtons();
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SelectButton(int id)
        { // change color for selected button and reset color for previous one
            
            // reset color for previous
            if(_animalButton != null)
            {
                _animalButton.colors = _ColorBlock;
                _selectedButtonTextField.color = _textColorBase;
            }
            
            // get new selected button
            _selectedButtonTextField = _buttonsTextFields[id];
            _animalButton = _buttons[id];;

            ColorBlock colorBlock = _ColorBlock;
            
            // choose color to mark selected button
            if (_hiddenAnimalId == id)
            {
                colorBlock.normalColor = _selectedButtonColorCorrect;
                colorBlock.highlightedColor = _selectedButtonColorCorrect;
                colorBlock.pressedColor = _selectedButtonColorCorrect;
            }
            else
            {
                colorBlock.normalColor = _selectedButtonColorWrong;
                colorBlock.highlightedColor = _selectedButtonColorWrong;
                colorBlock.pressedColor = _selectedButtonColorWrong;
            }
            
            _animalButton.colors = colorBlock;
            _selectedButtonTextField.color = _textColorSelected;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResetButton()
        { // reset color for selected button
            
            if(_animalButton != null)
            {
                _animalButton.colors = _ColorBlock;
                _selectedButtonTextField.color = _textColorBase;
            }
            
            DisableButtons();
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
        private void DisableButtons()
        {
            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void EnableButtons()
        {
            foreach (var button in _buttons)
            {
                button.interactable = true;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
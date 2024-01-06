using System.Linq;
using Patterns.Strategy.Animals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class PanelService : MonoBehaviour
    {
        private const string AnimalNotSelected = "No animal is selected";
        private const string AnimalCanNotBehaviour = "I'm can't to - ";
        
        [SerializeField] private Button _walkButton;
        [SerializeField] private Button _eatButton;
        [SerializeField] private Button _speakButton;
        [SerializeField] private Button _sleepButton;
        [SerializeField] private TextMeshProUGUI _textField;

        private AnimalBase _selectedAnimal;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            GameSignalService.OnAnimalSelected += SetCurrentAnimal;
            GameSignalService.OnShakeCards += ResetPanel;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            GameSignalService.OnAnimalSelected -= SetCurrentAnimal;
            GameSignalService.OnShakeCards -= ResetPanel;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            ResetPanel();
            _walkButton.onClick.AddListener(WalkButton);
            _eatButton.onClick.AddListener(EatButton);
            _speakButton.onClick.AddListener(SpeakButton);
            _sleepButton.onClick.AddListener(SleepButton);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SetCurrentAnimal(AnimalBase animal)
        {
            _textField.text = "";
            _selectedAnimal = animal;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void WalkButton()
        {
            if(_selectedAnimal != null)
            {
                if (_selectedAnimal.Behaviour.Keys.Contains("walk"))
                {
                    _selectedAnimal.Behaviour["walk"].Invoke();
                    _textField.text = _selectedAnimal.CurrentBehaviour;
                }
                else
                {
                    _textField.text = AnimalCanNotBehaviour + "walk";
                }
            }
            else
            {
                _textField.text = AnimalNotSelected;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void EatButton()
        {
            if(_selectedAnimal != null)
            {
                if (_selectedAnimal.Behaviour.Keys.Contains("eat"))
                {
                    _selectedAnimal.Behaviour["eat"].Invoke();
                    _textField.text = _selectedAnimal.CurrentBehaviour;
                }
                else
                {
                    _textField.text = AnimalCanNotBehaviour + "eat";
                }
            }
            else
            {
                _textField.text = AnimalNotSelected;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SpeakButton()
        {
            if(_selectedAnimal != null)
            {
                if (_selectedAnimal.Behaviour.Keys.Contains("speak"))
                {
                    _selectedAnimal.Behaviour["speak"].Invoke();
                    _textField.text = _selectedAnimal.CurrentBehaviour;
                }
                else
                {
                    _textField.text = AnimalCanNotBehaviour + "speak";
                }
            }
            else
            {
                _textField.text = AnimalNotSelected;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SleepButton()
        {
            if(_selectedAnimal != null)
            {
                if (_selectedAnimal.Behaviour.Keys.Contains("sleep"))
                {
                    _selectedAnimal.Behaviour["sleep"].Invoke();
                    _textField.text = _selectedAnimal.CurrentBehaviour;
                }
                else
                {
                    _textField.text = AnimalCanNotBehaviour + "sleep";
                }
            }
            else
            {
                _textField.text = AnimalNotSelected;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void ResetPanel()
        {
            _textField.text = "";
            _selectedAnimal = null;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
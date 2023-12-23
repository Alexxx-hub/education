using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.MiniGames.GuessWho
{
    public class PanelService : MonoBehaviour
    {
        private const string AnimalNotSelected = "No animal is selected";
        
        [SerializeField] private Button _walkButton;
        [SerializeField] private Button _eatButton;
        [SerializeField] private Button _speakButton;
        [SerializeField] private Button _sleepButton;
        [SerializeField] private TextMeshProUGUI _textField;

        private Dictionary<string, Action> _behavioursList;
        private string _currentBehaviour;
        //---------------------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            GameSignalService.OnAnimalSelected += SetCurrantBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            GameSignalService.OnAnimalSelected -= SetCurrantBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _textField.text = "";
            _walkButton.onClick.AddListener(WalkButton);
            _eatButton.onClick.AddListener(EatButton);
            _speakButton.onClick.AddListener(SpeakButton);
            _sleepButton.onClick.AddListener(SleepButton);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SetCurrantBehaviour(Dictionary<string, Action> behaviours, string currentBehaviour)
        {
            _behavioursList.Clear();
            _behavioursList = behaviours;
            _currentBehaviour = currentBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void WalkButton()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------------
        private void EatButton()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SpeakButton()
        {
            try
            {
                if (_behavioursList.Keys.Contains("speak"))
                {
                    _behavioursList["speak"].Invoke();
                    _textField.text = _currentBehaviour;
                }
            }
            catch (Exception e)
            {
                _textField.text = AnimalNotSelected;
            }
        }
        //---------------------------------------------------------------------------------------------------------------
        private void SleepButton()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
using System;
using System.Collections.Generic;
using Patterns.Strategy.Behaviours;
using Patterns.Strategy.MiniGames.GuessWho;
using Patterns.Strategy.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.Animals
{
    public class Cow : AnimalBase
    {
        [SerializeField] private SpeakBehaviourTextList _speakBehaviourTextList;
        [SerializeField] private string _food;
        [SerializeField] private string _walk;
        [SerializeField] private string _sleep;
        
        private Button _button;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            SetSpeakBehaviour(new SpeakBehaviour(_speakBehaviourTextList.Texts));
            SetEatBehaviour(new EatBehaviour(_food));
            SetWalkBehaviour(new WalkBehaviour(_walk));
            SetSleepBehaviour(new SleepBehaviour(_sleep));

            Behaviour = new Dictionary<string, Action>()
            {
                {"speak", Speak},
                {"eat", Eat},
                {"walk", Walk},
                {"sleep", Sleep}
            };

            _button = GetComponent<Button>();
            _button.onClick.AddListener(MarkSelected);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void MarkSelected()
        {
            GameSignalService.SelectAnimal(this);
            GameSignalService.SetButton(_button);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
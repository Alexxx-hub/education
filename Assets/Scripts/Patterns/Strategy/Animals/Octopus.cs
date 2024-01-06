using System;
using System.Collections.Generic;
using Patterns.Strategy.Behaviours;
using Patterns.Strategy.MiniGames.GuessWho;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Strategy.Animals
{
    public class Octopus : AnimalBase
    {
        [SerializeField] private string _food;
        [SerializeField] private string _sleep;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            SetEatBehaviour(new EatBehaviour(_food));
            SetSleepBehaviour(new SleepBehaviour(_sleep));

            Behaviour = new Dictionary<string, Action>()
            {
                {"eat", Eat},
                {"sleep", Sleep}
            };

            _button = GetComponent<Button>();
            _button.onClick.AddListener(MarkSelected);
        }
        //---------------------------------------------------------------------------------------------------------------
        private void MarkSelected()
        {
            GameSignalService.SelectAnimal(this);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
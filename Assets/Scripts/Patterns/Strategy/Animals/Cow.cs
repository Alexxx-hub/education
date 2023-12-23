using Patterns.Strategy.Behaviours;
using Patterns.Strategy.ScriptableObjects;
using UnityEngine;

namespace Patterns.Strategy.Animals
{
    public class Cow : AnimalBase
    {
        [SerializeField] private SpeakBehaviourTextList _speakBehaviourTextList;
        
        private void Awake()
        {
            SetSpeakBehaviour(new SpeakBehaviour(_speakBehaviourTextList.Texts));
        }
    }
}
using Patterns.Strategy.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public string CurrentBehaviour { get; private set; }
        
        protected ISpeak _speakBehaviour;
        protected IEat _eatBehaviour;
        protected IWalk _walkBehaviour;
        protected ISleep _sleepBehaviour;
        //---------------------------------------------------------------------------------------------------------------
        protected void SetSpeakBehaviour(ISpeak speakBehaviour)
        {
            _speakBehaviour = speakBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void SetEatBehaviour(IEat eatBehaviour)
        {
            _eatBehaviour = eatBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void SetWalkBehaviour(IWalk walkBehaviour)
        {
            _walkBehaviour = walkBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void SetSleepBehaviour(ISleep sleepBehaviour)
        {
            _sleepBehaviour = sleepBehaviour;
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Speak()
        {
            CurrentBehaviour = _speakBehaviour.Speak();
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Eat()
        {
            _eatBehaviour.Eat();
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Walk()
        {
            _walkBehaviour.Walk();
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Sleep()
        {
            _sleepBehaviour.Sleep();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
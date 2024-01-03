﻿using System;
using System.Collections.Generic;
using Patterns.Strategy.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Animals
{
    public abstract class AnimalBase : MonoBehaviour
    {
        public Dictionary<string, Action> Behaviour { get; protected set; }
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
            CurrentBehaviour = _eatBehaviour.Eat();
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Walk()
        {
            CurrentBehaviour = _walkBehaviour.Walk();
        }
        //---------------------------------------------------------------------------------------------------------------
        protected void Sleep()
        {
            CurrentBehaviour = _sleepBehaviour.Sleep();
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
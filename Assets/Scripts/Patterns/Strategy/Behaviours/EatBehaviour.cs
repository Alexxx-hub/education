using Patterns.Strategy.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Behaviours
{
    public class EatBehaviour : IEat
    {
        private string _text;
        //---------------------------------------------------------------------------------------------------------------
        public EatBehaviour(string text)
        {
            _text = text;
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Eat()
        {
            Debug.Log(_text);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
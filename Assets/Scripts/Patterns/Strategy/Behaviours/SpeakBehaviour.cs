using Patterns.Strategy.Interfaces;
using UnityEngine;

namespace Patterns.Strategy.Behaviours
{
    public class SpeakBehaviour : ISpeak
    {
        private string[] _text;
        //---------------------------------------------------------------------------------------------------------------
        public SpeakBehaviour(string[] text)
        {
            _text = text;
        }
        //---------------------------------------------------------------------------------------------------------------
        public string Speak()
        {
            string text = _text[Random.Range(0, _text.Length)];

            return "I'm say: " + text;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
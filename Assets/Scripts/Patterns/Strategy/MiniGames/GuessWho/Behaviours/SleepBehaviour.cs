using Patterns.Strategy.MiniGames.GuessWho.Interfaces;

namespace Patterns.Strategy.MiniGames.GuessWho.Behaviours
{
    public class SleepBehaviour : ISleep
    {
        private string _text;
        //---------------------------------------------------------------------------------------------------------------
        public SleepBehaviour(string text)
        {
            _text = text;
        }
        //---------------------------------------------------------------------------------------------------------------
        public string Sleep()
        {
            return _text;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
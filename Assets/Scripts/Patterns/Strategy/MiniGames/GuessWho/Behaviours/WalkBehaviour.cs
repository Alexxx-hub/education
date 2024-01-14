using Patterns.Strategy.MiniGames.GuessWho.Interfaces;

namespace Patterns.Strategy.MiniGames.GuessWho.Behaviours
{
    public class WalkBehaviour : IWalk
    {
        private string _text;
        //---------------------------------------------------------------------------------------------------------------
        public WalkBehaviour(string text)
        {
            _text = text;
        }
        //---------------------------------------------------------------------------------------------------------------
        public string Walk()
        {
            return _text;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
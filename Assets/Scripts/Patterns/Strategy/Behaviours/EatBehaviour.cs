using Patterns.Strategy.Interfaces;

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
        public string Eat()
        {
            return "I'm eat: " + _text;
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
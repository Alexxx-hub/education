using Patterns.Strategy.Interfaces;

namespace Patterns.Strategy.Behaviours
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
        public void Walk()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
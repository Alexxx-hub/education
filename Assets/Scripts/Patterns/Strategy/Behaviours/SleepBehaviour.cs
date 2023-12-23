using Patterns.Strategy.Interfaces;

namespace Patterns.Strategy.Behaviours
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
        public void Sleep()
        {
            
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}
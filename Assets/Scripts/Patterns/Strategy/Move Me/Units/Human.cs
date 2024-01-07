using Patterns.Strategy.Move_Me.Core;
using ISelectable = Patterns.Strategy.Move_Me.Interfaces.ISelectable;

namespace Patterns.Strategy.Move_Me.Units
{
    public class Human : UnitBase, ISelectable
    {
        private string[] _commands;

        public string[] Commands => _commands;
        //---------------------------------------------------------------------------------------------------------------
        private void Awake()
        {
            _commands = new[] {"move", "patrol", "follow"};
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (_hasCommandMove) Move(transform, _speed);
        }
        //---------------------------------------------------------------------------------------------------------------
        public void Selected()
        {
            UnitSignalsService.SendSelectedUnit(this, Commands);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}   
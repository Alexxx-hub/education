namespace Patterns.Strategy.Move_Me.Units
{
    public class Human : UnitSelectable
    {
        //---------------------------------------------------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            SetCommands(new[] {"move", "patrol", "follow"});
        }
        //---------------------------------------------------------------------------------------------------------------
        private void Update()
        {
            if (_hasCommandMove) Move(transform, _speed);
        }
        //---------------------------------------------------------------------------------------------------------------
    }
}   
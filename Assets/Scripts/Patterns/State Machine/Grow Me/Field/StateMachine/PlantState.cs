using UnityEngine;

public class PlantState : State
{
    public PlantState(StateMachine stateMachine, Field field) : base(stateMachine, field)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _field.stage = 1;
        _field.Sprite.sprite = _field.SpriteArray[1];
        _maxVolume = _field.Square * 1.2f;
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Proceed()
    {
        _currentVolume += _field.PlantingSpeed * Time.deltaTime;
        base.Proceed();

        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("watering");
        }
    }
}

using UnityEngine;

public class WateringState : State
{
    public WateringState(StateMachine stateMachine, Field field) : base(stateMachine, field)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _field.stage = 2;
        _field.Sprite.sprite = _field.SpriteArray[2];
        _maxVolume = _field.Square * _field.CropType.WaterPerUnit;
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Proceed()
    {
        _currentVolume += _field.WateringSpeed * Time.deltaTime;
        base.Proceed();

        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("grow");
        }
    }
}

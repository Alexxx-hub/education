using UnityEngine;

public class CleaningState : State
{
    public CleaningState(StateMachine stateMachine, Field field) : base(stateMachine, field)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _field.stage = 4;
        _field.Sprite.sprite = _field.SpriteArray[0];
        _maxVolume = _field.Square * _field.CropType.CountPerUnit;
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
            _stateMachine.SetState("plant");
        }
    }
}

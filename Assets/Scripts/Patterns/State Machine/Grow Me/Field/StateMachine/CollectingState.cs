using UnityEngine;

public class CollectingState : State
{
    public CollectingState(StateMachine stateMachine, Field field) : base(stateMachine, field)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _field.stage = 3;
        _field.Sprite.sprite = _field.SpriteArray[7];
        _maxVolume = _field.Square * _field.CropType.CountPerUnit;
    }

    public override void Exit()
    {
        _currentVolume = 0;
        _field.collectCrop.Invoke(_field.CropType.name, _maxVolume);
    }

    public override void Proceed()
    {
        _currentVolume += _field.CollectingSpeed * Time.deltaTime;
        base.Proceed();

        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("cleaning");
        }
    }
}

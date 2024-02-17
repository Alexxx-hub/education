using UnityEngine;

public class CollectingState : State
{
    private float _maxVolume;
    private float _currentVolume;

    private Field _field;

    public CollectingState(StateMachine stateMachine, Field field) : base(stateMachine)
    {
        _field = field;
        _currentVolume = 0;
    }

    public override void Enter()
    {
        _field.stage = 4;
        _field.Sprite.sprite = _field.SpriteArray[7];
        _maxVolume = _field.Square * _field.CropType.CountPerUnit;
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Proceed()
    {
        _currentVolume += _field.CollectingSpeed * Time.deltaTime;
        Debug.Log(_currentVolume);
        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("cleaning");
        }
    }
}

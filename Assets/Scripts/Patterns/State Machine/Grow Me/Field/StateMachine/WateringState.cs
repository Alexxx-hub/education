using UnityEngine;

public class WateringState : State
{
    private float _maxVolume;
    private float _currentVolume;

    private Field _field;

    public WateringState(StateMachine stateMachine, Field field) : base(stateMachine)
    {
        _field = field;
        _maxVolume = field.Square * 1.2f;
        _currentVolume = 0;
    }

    public override void Enter()
    {
        _field.stage = 2;
        _field.Sprite.sprite = _field.SpriteArray[2];
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Proceed()
    {
        _currentVolume += _field.WateringSpeed * Time.deltaTime;
        Debug.Log(_currentVolume);
        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("grow");
        }
    }
}

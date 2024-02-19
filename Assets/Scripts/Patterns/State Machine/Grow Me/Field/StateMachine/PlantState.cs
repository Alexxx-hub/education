using UnityEngine;

public class PlantState : State
{
    private float _maxVolume;
    private float _currentVolume;

    private Field _field;

    public PlantState(StateMachine stateMachine, Field field) : base(stateMachine) 
    { 
        _field = field;
        _maxVolume = field.Square * 1.2f;
        _currentVolume = 0;
    }

    public override void Enter()
    {
        _field.stage = 1;
        _field.Sprite.sprite = _field.SpriteArray[1];
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Proceed()
    {
        _currentVolume += _field.PlantingSpeed * Time.deltaTime;
        Debug.Log(_currentVolume);
        if (_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("watering");
        }
    }

}
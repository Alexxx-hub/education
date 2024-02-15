using UnityEngine;

public class PlantState : State
{
    private const float _volumePerSecond = 10f;
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
        Debug.Log("Idle stage: Enter");
    }

    public override void Exit()
    {
        _currentVolume = 0;
    }

    public override void Update()
    {
        _currentVolume += _volumePerSecond * Time.deltaTime;
        Debug.Log(_currentVolume);

        if(_currentVolume >= _maxVolume)
        {
            _stateMachine.SetState("idle");
        }
    }

}

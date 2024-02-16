using UnityEngine;

public class GrowState : State
{
    private const float MAX_TIME = 8f;
    private const int STEPS = 4;
    private const int OFFSET = 4;

    private int _currentStep;
    private float _currentTime;
    private Field _field;

    public GrowState(StateMachine stateMachine, Field field) : base(stateMachine)
    {
        _field = field;
        _currentTime = 0;
        _currentStep = 0;
    }

    public override void Enter()
    {
        _field.stage = 3;
        _field.Sprite.sprite = _field.SpriteArray[3];
    }

    public override void Exit()
    {
        _currentTime = 0;
        _currentStep = 0;
    }

    public override void Update()
    {
        _currentTime += Time.deltaTime * _field.GrowingSpeed;
        Debug.Log(_currentTime);
        if (_currentTime >= MAX_TIME)
        {
            if (_currentStep >= STEPS)
            {
                _stateMachine.SetState("collecting");
                return;
            }

            _field.Sprite.sprite = _field.SpriteArray[_currentStep + OFFSET];
            _currentTime = 0;
            _currentStep++;
        }

    }
}

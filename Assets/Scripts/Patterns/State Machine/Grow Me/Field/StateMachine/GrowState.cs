using UnityEngine;

public class GrowState : State
{
    private readonly int STEPS = 4;
    private const int OFFSET = 4;

    private int _currentStep;
    private float _stepTime;
    private float _currentTime;

    public GrowState(StateMachine stateMachine, Field field) : base(stateMachine, field)
    {
        _field = field;
        _currentTime = 0;
        _currentStep = 0;
    }

    public override void Enter()
    {
        _field.stage = -1;
        _field.Sprite.sprite = _field.SpriteArray[3];
        _stepTime = _field.CropType.TimeToGrow / STEPS;
    }

    public override void Exit()
    {
        _currentTime = 0;
        _currentStep = 0;
    }

    public override void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _stepTime)
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

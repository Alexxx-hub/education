public abstract class State
{
    protected readonly StateMachine _stateMachine;

    protected float _maxVolume;
    protected float _currentVolume;
    protected Field _field;

    public State(StateMachine stateMachine, Field field)
    {
        _field = field;
        _currentVolume = 0;
        _stateMachine = stateMachine;
    }

    public virtual void Enter() 
    {
        _field.statusBarImage.fillAmount = _currentVolume;
    }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void Proceed() 
    {
        _field.statusBarImage.fillAmount = _currentVolume / _maxVolume;
    }
}

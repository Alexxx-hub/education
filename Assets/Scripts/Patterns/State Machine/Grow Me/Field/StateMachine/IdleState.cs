public class IdleState : State
{
    private int _toolID;

    public IdleState(StateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        _toolID = 0;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}

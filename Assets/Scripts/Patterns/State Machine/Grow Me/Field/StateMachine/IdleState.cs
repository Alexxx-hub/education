using UnityEngine;

public class IdleState : State
{
    private Field _field;

    public IdleState(StateMachine stateMachine, Field field) : base(stateMachine) 
    {
        _field = field;
    }

    public override void Enter()
    {
        _field.stage = 0;
        Debug.Log("Idle stage: Enter");
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}

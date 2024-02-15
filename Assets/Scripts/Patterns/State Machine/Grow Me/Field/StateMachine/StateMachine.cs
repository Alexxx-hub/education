using System;
using System.Collections.Generic;

public class StateMachine
{
    private State CurrentState { get; set; }
    private Dictionary<string, State> _states;

    public StateMachine()
    {
        _states = new Dictionary<string, State>();
    }

    public void AddState(string id, State state)
    {
        _states.Add(id, state);
    }

    public void SetState(string id)
    {
        if(_states.TryGetValue(id, out var newState))
        {
           if(CurrentState != null)
            {
                CurrentState.Exit();
            }
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
    public void Update()
    {
        CurrentState?.Update();
    }
}

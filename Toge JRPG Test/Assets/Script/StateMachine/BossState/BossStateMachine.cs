using UnityEngine;

public class BossStateMachine
{
    public BossState currentState { get; private set; } //state ninja realtime

    public void Initialize(BossState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(BossState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}

using UnityEngine;

public class BattleStateMachine
{
    public BattleState currentState { get; private set; }

    public void Initialize(BattleState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(BattleState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}

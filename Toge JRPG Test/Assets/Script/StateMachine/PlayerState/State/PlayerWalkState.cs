using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

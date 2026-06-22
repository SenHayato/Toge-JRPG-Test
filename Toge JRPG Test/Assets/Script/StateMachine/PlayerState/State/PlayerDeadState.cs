using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

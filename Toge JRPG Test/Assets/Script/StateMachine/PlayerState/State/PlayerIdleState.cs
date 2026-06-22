using UnityEngine;


public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}



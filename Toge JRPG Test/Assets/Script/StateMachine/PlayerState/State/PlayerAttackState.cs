using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

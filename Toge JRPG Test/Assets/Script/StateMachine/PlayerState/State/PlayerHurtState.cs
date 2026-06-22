using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

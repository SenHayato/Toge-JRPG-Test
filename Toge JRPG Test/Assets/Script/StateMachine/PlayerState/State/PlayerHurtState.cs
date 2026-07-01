using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        playerActive.playerInState = PlayerInState.Hurt;
        playerActive.Hurt();
        playerActive.playerAnimator.SetBool("IsHurt", true);
    }

    public override void Exit()
    {
        base.Exit();
        playerActive.playerAnimator.SetBool("IsHurt", false);
        if (playerActive.playerInState != PlayerInState.Idle)
        {
            playerActive.ChangeToIdle();
        }
    }
}

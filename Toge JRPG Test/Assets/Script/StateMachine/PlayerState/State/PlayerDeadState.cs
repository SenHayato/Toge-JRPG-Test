using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        playerActive.playerInState = PlayerInState.Dead;
        playerActive.playerAnimator.SetBool("IsDead", true);
    }

    public override void Update()
    {
        base.Update();
        playerActive.Revive();
    }

    public override void Exit()
    {
        base.Exit();
        playerActive.playerAnimator.SetBool("IsDead", false);
        if (playerActive.playerInState != PlayerInState.Idle)
        {
            playerActive.ChangeToIdle();
        }
    }
}

using UnityEngine;


public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        playerActive.playerInState = PlayerInState.Idle;
        playerActive.playerAnimator.SetBool("IsIdle", true);
    }

    public override void Update()
    {
        base.Update();
        if (playerActive.moveValue != Vector2.zero)
        {
            playerStateMachine.ChangeState(playerActive.walkState);
        }
    }

    public override void Exit()
    {
        playerActive.playerAnimator.SetBool("IsIdle", false);
    }
}



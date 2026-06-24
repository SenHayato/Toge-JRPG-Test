using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        playerActive.playerInState = PlayerInState.Walk;
        playerActive.playerAnimator.SetBool("IsMove", true);
    }

    public override void Update()
    {
        base.Update();
        if (playerActive.moveValue == Vector2.zero)
        {
            playerStateMachine.ChangeState(playerActive.idleState);
        }
        else
        {
            playerActive.Movement();
            RunState();
            FlipSprite();
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerActive.playerAnimator.SetBool("IsMove", false);
    }

    #region Method
    void FlipSprite()
    {
        if (playerActive.moveValue.x > 0.1f)
        {
            playerActive.spriteRenderer.flipX = false;
        }
        else if (playerActive.moveValue.x < -0.1f)
        {
            playerActive.spriteRenderer.flipX = true;
        }
    }

    void RunState()
    {
        if (playerActive.isRunning)
        {
            playerActive.playerAnimator.SetBool("IsRun", true);
            playerActive.moveSpeed = Mathf.Max(playerActive.moveSpeed, 4f);
        }
        else
        {
            playerActive.playerAnimator.SetBool("IsRun", false);
            playerActive.moveSpeed = Mathf.Min(1.5f, playerActive.moveSpeed);
        }
    }
    #endregion
}

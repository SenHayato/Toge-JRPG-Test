using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerWalkState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("masuk walk");
        playerActive.playerInState = PlayerInState.Walk;
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
            FlipSprite();
        }
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
    #endregion
}

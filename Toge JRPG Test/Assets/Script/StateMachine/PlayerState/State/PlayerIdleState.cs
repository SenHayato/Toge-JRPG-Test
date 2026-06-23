using UnityEngine;


public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public override void Enter()
    {
        playerActive.playerInState = PlayerInState.Idle;
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (playerActive.moveValue != Vector2.zero)
        {
            playerStateMachine.ChangeState(playerActive.walkState);
        }
    }
}



using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerActive playerActive, PlayerStateMachine playerStateMachine)
        : base(playerActive, playerStateMachine) { }

    public int AttackNumber;
    public override void Enter()
    {
        base.Enter();
        playerActive.playerInState = PlayerInState.Attack;
        playerActive.playerAnimator.SetBool("IsAttack", true);
        playerActive.playerAnimator.SetInteger("AttackNum", AttackNumber);
    }

    public override void Exit()
    {
        base.Exit();
        playerActive.playerAnimator.SetBool("IsAttack", false);
        playerActive.playerAnimator.SetInteger("AttackNum", 0);
        if (playerActive.playerInState != PlayerInState.Idle)
        {
            playerActive.ChangeToIdle();
        }
    }
}

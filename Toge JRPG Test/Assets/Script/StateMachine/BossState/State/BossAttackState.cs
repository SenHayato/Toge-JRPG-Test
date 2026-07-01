using UnityEngine;

public class BossAttackState : BossState
{
    public BossAttackState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public int AttackNum;
    public override void Enter()
    {
        base.Enter();
        bossActive.enemyAnimator.SetBool("IsAttack", true);
        bossActive.enemyAnimator.SetInteger("AttackNum", AttackNum);
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.enemyAnimator.SetBool("IsAttack", false);
        bossActive.enemyAnimator.SetInteger("AttackNum", 0);
        if (bossActive.inState != BossInState.Idle)
        {
            bossActive.ChangeToIdle();
        }
    }
}

using UnityEngine;

public class BossHurtState : BossState
{
    public BossHurtState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Hurt;
        bossActive.enemyAnimator.SetBool("IsHurt", true);
        bossActive.Hurt();
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.enemyAnimator.SetBool("IsHurt", true);
        if (bossActive.inState != BossInState.Idle)
        {
            bossActive.ChangeToIdle();
        }
    }
}

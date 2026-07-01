using UnityEngine;

public class BossDeadState : BossState
{
    public BossDeadState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Dead;
        bossActive.enemyAnimator.SetBool("IsDead", true);
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.enemyAnimator.SetBool("IsDead", false);
        if (bossActive.inState != BossInState.Idle)
        {
            bossActive.ChangeToIdle();
        }
    }
}

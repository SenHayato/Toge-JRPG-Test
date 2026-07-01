using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Idle;
        bossActive.enemyAnimator.SetBool("IsIdle", true);
    }

    public override void Update()
    {
        base.Update();
        //if (bossActive.inState == BossInState.Walk)
        //{
        //    bossStateMachine.ChangeState(bossActive.walkState);
        //}
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.enemyAnimator.SetBool("IsIdle", true);
    }
}

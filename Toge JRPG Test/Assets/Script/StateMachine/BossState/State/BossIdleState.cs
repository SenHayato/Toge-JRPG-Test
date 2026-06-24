using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Idle;
    }

    public override void Update()
    {
        base.Update();
        //if (bossActive.inState == BossInState.Walk)
        //{
        //    bossStateMachine.ChangeState(bossActive.walkState);
        //}
    }
}

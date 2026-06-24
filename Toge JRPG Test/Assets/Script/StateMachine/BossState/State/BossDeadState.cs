using UnityEngine;

public class BossDeadState : BossState
{
    public BossDeadState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Dead;
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.inState = BossInState.Idle;
    }
}

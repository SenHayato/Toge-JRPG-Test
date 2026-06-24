using UnityEngine;

public class BossHurtState : BossState
{
    public BossHurtState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        bossActive.inState = BossInState.Hurt;
        bossActive.Hurt();
    }

    public override void Exit()
    {
        base.Exit();
        bossActive.inState = BossInState.Idle;
    }
}

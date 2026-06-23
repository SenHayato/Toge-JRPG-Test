using UnityEngine;

public class BossHurtState : BossState
{
    public BossHurtState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

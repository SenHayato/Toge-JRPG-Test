using UnityEngine;

public class BossAttackState : BossState
{
    public BossAttackState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

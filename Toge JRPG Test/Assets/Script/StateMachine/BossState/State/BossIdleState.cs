using UnityEngine;

public class BossIdleState : BossState
{
    public BossIdleState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

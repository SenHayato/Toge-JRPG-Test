using UnityEngine;

public class BossDeadState : BossState
{
    public BossDeadState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }
}

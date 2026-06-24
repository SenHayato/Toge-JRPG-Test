using UnityEngine;

public class BossWalkState : BossState
{
    public BossWalkState(BossActive bossActives, BossStateMachine StateMachine)
        : base(bossActives, StateMachine) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Boss Walk State");
    }
}

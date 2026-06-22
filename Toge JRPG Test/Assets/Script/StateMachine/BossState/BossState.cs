using UnityEngine;

public class BossState
{
    protected BossActive bossActive;
    protected BossStateMachine bossStateMachine;

    public BossState(BossActive bossActives, BossStateMachine stateMachine)
    {
        this.bossActive = bossActives;
        this.bossStateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

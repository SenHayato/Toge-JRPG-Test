using UnityEngine;

public class BattleState
{
    protected BattleManager battleManager;
    protected BattleStateMachine battleStateMachine;

    public BattleState(BattleManager battleManagers, BattleStateMachine battleStateMachines)
    {
        this.battleManager = battleManagers;
        this.battleStateMachine = battleStateMachines;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

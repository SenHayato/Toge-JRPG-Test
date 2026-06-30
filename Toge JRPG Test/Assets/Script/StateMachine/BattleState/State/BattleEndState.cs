using UnityEngine;

public class BattleEndState : BattleState
{
    public BattleEndState(BattleManager battleManager, BattleStateMachine battleStateMachine)
        : base(battleManager, battleStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        battleManager.battleProgress = BattleInProgress.BattleEnd;
        Debug.Log("Masuk");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Keluar");
    }
}

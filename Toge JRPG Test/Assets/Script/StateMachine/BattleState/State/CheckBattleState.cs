using UnityEngine;

public class CheckBattleState : BattleState
{
    public CheckBattleState(BattleManager battleManager, BattleStateMachine battleStateMachine)
        : base(battleManager, battleStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        battleManager.battleProgress = BattleInProgress.CheckBattle;
        Debug.Log("Masuk");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Keluar");
    }
}

using UnityEngine;

public class BattleStartState : BattleState
{
    public BattleStartState(BattleManager battleManager, BattleStateMachine battleStateMachine)
        : base(battleManager, battleStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        battleManager.battleProgress = BattleInProgress.BattleStart;
        battleManager.SetUpBattle();
        battleManager.BattleStartToPlayerTurn();
        Debug.Log("Masuk");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Keluar");
    }
}

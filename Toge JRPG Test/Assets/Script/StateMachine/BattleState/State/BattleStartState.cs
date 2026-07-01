using UnityEngine;

public class BattleStartState : IState
{
    private BattleManager battleManager;

    public BattleStartState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.BattleStart;
        battleManager.SetUpBattle();
        battleManager.BattleStartToPlayerTurn();
        Debug.Log("Battle Start");
    }
    
    public void Update() { }

    public void Exit()
    {
        Debug.Log("Battle Start - Exit");
    }
}

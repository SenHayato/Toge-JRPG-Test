using UnityEngine;

public class CheckBattleState : IState
{
    private BattleManager battleManager;

    public CheckBattleState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.CheckBattle;
        Debug.Log("Masuk");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

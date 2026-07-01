using UnityEngine;

public class EnemyTurnState : IState
{
    private BattleManager battleManager;

    public EnemyTurnState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.EnemyTurn;
        Debug.Log("Masuk");
    }

    public void Update() { }
    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

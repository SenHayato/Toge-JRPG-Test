using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : IState
{
    private BattleManager battleManager;
    public List<EnemyActive> enemyActives;

    public EnemyTurnState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.EnemyTurn;
        battleManager.wasTurn = BattleInProgress.EnemyTurn;

        //checkEnemy lagi
        battleManager.GetEnemyOnTurn();
        Debug.Log("Masuk");
    }

    public void Update() { }
    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

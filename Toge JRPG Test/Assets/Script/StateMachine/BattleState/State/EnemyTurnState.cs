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
        //battleManager.targetAlly 
        //checkEnemy lagi
        battleManager.GetEnemyOnTurn();
        BattleManager.Instance.stateMachine.ChangeState(BattleManager.Instance.actionState);
        Debug.Log("Masuk");
    }

    public void Update() { }
    public void Exit()
    {
        battleManager.enemies.Clear();
        Debug.Log("Keluar");
    }
}

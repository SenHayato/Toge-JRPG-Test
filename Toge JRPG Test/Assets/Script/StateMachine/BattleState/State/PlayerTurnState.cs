using UnityEngine;

public class PlayerTurnState : IState
{
    private BattleManager battleManager;

    public PlayerTurnState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.PlayerTurn;
        battleManager.wasTurn = BattleInProgress.PlayerTurn;
        HudManager.Instance.OnPlayerTurn();
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
        Debug.Log("Player Turn");
    }

    public void Update() { }

    public void Exit()
    {
        DisableBattleUI();
        Debug.Log("Player Turn - Exit");
    }

    void DisableBattleUI()
    {
        //matikan semua kecuali battlemonitor
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseEnemyUnit, false);
    }
}

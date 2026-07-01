using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager, BattleStateMachine battleStateMachine)
        : base(battleManager, battleStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        battleManager.battleProgress = BattleInProgress.PlayerTurn;
        //HudManager.Instance.PlayerUnitChoose(true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
        Debug.Log("Player Turn");
    }

    public override void Exit()
    {
        base.Exit();
        //HudManager.Instance.PlayerUnitChoose(false);
        //HudManager.Instance.ActionChoice(false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        Debug.Log("Player Turn - Exit");
    }
}

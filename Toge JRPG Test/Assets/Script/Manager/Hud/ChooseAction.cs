using UnityEngine;

public class ChooseAction : Singleton<ChooseAction>
{
    public void BackToUnit()
    {
        HudManager.Instance.PlayerUnitChoose(true);
        HudManager.Instance.ActionChoice(false);
        BattleManager.Instance.ChangeBattleState(BattleManager.Instance.playerTurn);
    }
}

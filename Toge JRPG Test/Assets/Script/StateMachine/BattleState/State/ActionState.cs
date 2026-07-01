using Unity.VisualScripting;
using UnityEngine;

public class ActionState : IState
{
    private BattleManager battleManager;

    public ActionState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.ActionState;
        HudManager.Instance.OnSkillAction();
        Debug.Log("Masuk");
    }
    public void Update() { }

    public void Exit()
    {
        battleManager.ClearTargetData(); //reset target
        Debug.Log("Keluar");
    }

}

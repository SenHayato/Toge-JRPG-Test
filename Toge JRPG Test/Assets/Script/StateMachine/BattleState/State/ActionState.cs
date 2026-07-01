using Unity.VisualScripting;
using UnityEngine;

public class ActionState : BattleState
{
    public ActionState(BattleManager battleManager, BattleStateMachine battleStateMachine)
        : base(battleManager, battleStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        battleManager.battleProgress = BattleInProgress.ActionState;
        Debug.Log("Masuk");
    }

    public override void Exit()
    {
        base.Exit();
        battleManager.ClearTargetData(); //reset target
        Debug.Log("Keluar");
    }
}

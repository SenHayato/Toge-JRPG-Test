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
        ChooseAction.Instance.ButtonDestroy();
        //HudManager.Instance.OnSkillAction();

        Debug.Log("Masuk ActionState");

        SkillsSO skill = battleManager.selectedSkill;
        Debug.Log("Selected skill " + skill.name);

        // ubah state
        battleManager.selectedUnit.ChangeToAttackState(skill.AttackNumber);

        // Jalankan coroutine execution
        battleManager.StartCoroutine(battleManager.ExecuteSkill(skill));
    }

    public void Update() { }

    public void Exit()
    {
        battleManager.ClearTargetData();
        HudManager.Instance.OnExitAction();
        //battleManager.MoveToPosition(battleManager.target[0].transform);
        //battleManager.stateMachine.ChangeState(battleManager.checkBattle);
        Debug.Log("Keluar ActionState");
    }
}

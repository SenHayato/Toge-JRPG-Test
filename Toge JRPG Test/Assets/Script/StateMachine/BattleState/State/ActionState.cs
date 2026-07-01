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

        Debug.Log("Masuk ActionState");

        SkillsSO skill = battleManager.selectedSkill;

        // ubah state
        battleManager.selectedUnit.ChangeToAttackState(skill.AttackNumber);

        // Jalankan coroutine execution
        //battleManager.StartCoroutine(ExecuteAction(skill));
    }

    //private IEnumerator ExecuteAction(SkillsSO skill)
    //{
    //    // tunggu animasi
    //    //battleManager.MoveToPosition(battleManager.target[0].transform);
    //    yield return new WaitForSeconds(skill.Animation.length);

    //    // eksekusi skill
    //    battleManager.SkillExecutor(skill);

    //    // cek hasil battle
    //    battleManager.CheckBattleResult();

    //    // lanjut turn
    //    battleManager.NextTurn();
    //}

    public void Update() { }

    public void Exit()
    {
        battleManager.ClearTargetData();
        //battleManager.MoveToPosition(battleManager.target[0].transform);
        battleManager.stateMachine.ChangeState(battleManager.checkBattle);
        Debug.Log("Keluar ActionState");
    }
}

using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAction : Singleton<ChooseAction>
{
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] Transform buttonSpawner;

    //public void OnEnable()
    //{

    //}

    List<GameObject> buttonList = new List<GameObject>();

    public void SpawnSkillButton(PlayerActive unit)
    {
        BattleManager.Instance.ClearTargetData();
        foreach (SkillsSO skill in unit.skillManager.skills)
        {
            SkillsSO capturedSkill = skill;

            GameObject btnObj = Instantiate(buttonPrefabs, buttonSpawner);
            Button btn = btnObj.GetComponent<Button>();
            buttonList.Add(btnObj);

            btn.GetComponentInChildren<TMP_Text>().text = skill.SkillName;

            btn.onClick.AddListener(() =>
            {
                SelectSkill(unit, capturedSkill);
                Debug.Log(skill.SkillName + " " + unit.modelName);
            });
        }
    }

    [SerializeField] SkillsSO selectedSkill;
    [SerializeField] CharacterUnit selectedUnit;
    
    void AssignData()
    {
        selectedSkill = BattleManager.Instance.selectedSkill;
        selectedUnit = BattleManager.Instance.selectedUnit;
    }

    void SelectSkill(PlayerActive playerUnit, SkillsSO skill)
    {
        BattleManager.Instance.AssignData(skill);
        BattleManager.Instance.AssignData(playerUnit);
        AssignData();

        Debug.Log("Skill yang dipilih " + selectedSkill.SkillName);

        switch (selectedSkill.TargetType)
        {
            case SkillTargetType.SingleEnemy:
                ShowSingleTargetHud();
                break;

            case SkillTargetType.SingleAlly:
                ShowAllySingleTarget();
                break;

            case SkillTargetType.Self:
                ExecuteSelf(selectedUnit); // langsung eksekusi
                break;

            case SkillTargetType.MultipleEnemy:
                MultipleTargetSkill(SkillTargetType.MultipleEnemy); // nanti di ActionState
                BattleManager.Instance.stateMachine.ChangeState(BattleManager.Instance.actionState);
                break;

            case SkillTargetType.MultipleAlly:
                MultipleTargetSkill(SkillTargetType.MultipleAlly); // nanti di ActionState
                BattleManager.Instance.stateMachine.ChangeState(BattleManager.Instance.actionState);
                break;
        }
        //Battle state ubah ke action dan jalankan skill
    }

    void ShowSingleTargetHud()
    {
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseEnemyUnit, true);
    }

    void ShowAllySingleTarget()
    {
        ChoosePlayerUnit.Instance.isAllyTarget = true;
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
    }

    void ExecuteSelf(CharacterUnit units)
    {
        BattleManager.Instance.ChangeBattleState(BattleManager.Instance.actionState);
    }

    void MultipleTargetSkill(SkillTargetType skillMultipleType)
    {
        switch (skillMultipleType)
        {
            case SkillTargetType.MultipleEnemy:
                EnemyActive[] enemy = FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                BattleManager.Instance.AssignMultipleTarget(enemy);
                break;
            case SkillTargetType.MultipleAlly:
                PlayerActive[] player = FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
                BattleManager.Instance.AssignMultipleTarget(player);
                break;
        }
    }

    void ButtonDestroy()
    {
        foreach (GameObject btn in buttonList)
        {
            Destroy(btn);
        }
    }

    private void OnDisable()
    {
        ButtonDestroy();
        buttonList.Clear();
    }

    public void BackToUnit()
    {
        //    HudManager.Instance.PlayerUnitChoose(true);
        //    HudManager.Instance.ActionChoice(false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
    }
}

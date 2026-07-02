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

    [SerializeField] List<GameObject> buttonList = new List<GameObject>();

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

    public void SelectSkill(CharacterUnit unit, SkillsSO skill)
    {
        BattleManager.Instance.AssignData(skill);
        BattleManager.Instance.AssignData(unit);
        AssignData();

        Debug.Log("Skill yang dipilih " + selectedSkill.SkillName);

        switch (selectedSkill.TargetType)
        {
            case SkillTargetType.SingleEnemy:
                if (skill.executor == SkillExecutor.Ally)
                {
                    ShowSingleTargetHud();
                }
                break;

            case SkillTargetType.SingleAlly:
                if (skill.executor == SkillExecutor.Ally)
                {
                    ShowAllySingleTarget();
                }
                break;

            case SkillTargetType.Self:
                ExecuteSelf(selectedUnit); // langsung eksekusi
                break;

            case SkillTargetType.Guard:
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
                List<EnemyActive> enemies = new List<EnemyActive>(FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None));
                foreach(EnemyActive enemy in enemies)
                {
                    BattleManager.Instance.AssignMultipleTarget(enemy);
                }
                break;
            case SkillTargetType.MultipleAlly:
                List<PlayerActive> players = new List<PlayerActive>(FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None));
                foreach(PlayerActive player in players)
                {
                    BattleManager.Instance.AssignMultipleTarget(player);
                }
                break;
        }
    }

    public void ButtonDestroy()
    {
        if (buttonList != null)
        {
            foreach (GameObject btn in buttonList)
            {
                Destroy(btn);
            }
            buttonList.Clear();
        }
    }

    public void BackToUnit()
    {
        //    HudManager.Instance.PlayerUnitChoose(true);
        //    HudManager.Instance.ActionChoice(false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        ButtonDestroy();
    }
}

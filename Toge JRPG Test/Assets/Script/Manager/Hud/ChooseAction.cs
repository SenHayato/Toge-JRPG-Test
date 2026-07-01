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

    SkillsSO selectedSkill;
    PlayerActive selectedUnit;
    PlayerActive[] targetAlly;
    EnemyActive[] targetEnemy;

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
                //ShowAllyTarget();
                break;

            case SkillTargetType.Self:
                //ExecuteSkill(selectedUnit); // langsung eksekusi
                break;

            case SkillTargetType.MultipleEnemy:
                //ExecuteSkill(selectedUnit); // nanti di ActionState
                break;

            case SkillTargetType.MultipleAlly:
                break;
        }
    }

    void ShowSingleTargetHud()
    {
        //HudManager.Instance.ActionChoice(false);
        //HudManager.Instance.EnemyUnitChoose(true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseEnemyUnit, true);
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

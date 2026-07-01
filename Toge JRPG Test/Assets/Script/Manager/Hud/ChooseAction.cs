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

    public SkillsSO selectedSkill;
    public PlayerActive selectedUnit;

    void SelectSkill(PlayerActive playerUnit, SkillsSO skill)
    {
        selectedSkill = skill;
        selectedUnit = playerUnit;

        Debug.Log("Skill yang dipilih " + selectedSkill.SkillName);

        //switch (selectedSkill.TargetType)
        //{
        //    case SkillTargetType.SingleEnemy:
        //        ShowEnemyTarget();
        //        break;

        //    case SkillTargetType.SingleAlly:
        //        ShowAllyTarget();
        //        break;

        //    case SkillTargetType.Self:
        //        ExecuteSkill(selectedUnit); // langsung eksekusi
        //        break;

        //    case SkillTargetType.AllEnemies:
        //        ExecuteSkill(selectedUnit); // nanti di ActionState
        //        break;
        //}
    }

    void ButtonDestroy()
    {
        foreach(GameObject btn in buttonList)
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
        HudManager.Instance.PlayerUnitChoose(true);
        HudManager.Instance.ActionChoice(false);
    }
}

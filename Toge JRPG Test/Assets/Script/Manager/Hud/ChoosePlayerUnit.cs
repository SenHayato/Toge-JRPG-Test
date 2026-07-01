using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerUnit : Singleton<ChoosePlayerUnit>
{
    [SerializeField] PlayerActive[] playerActives;
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] Transform buttonSpawner;
    [SerializeField] GameObject backButton;
    public bool isAllyTarget = false;

    private void OnEnable()
    {
        playerActives = FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        ButtonSpawner();
        backButton.SetActive(isAllyTarget);
    }

    List<GameObject> buttonSpawned = new List<GameObject>();

    void ButtonSpawner()
    {
        foreach (PlayerActive unit in playerActives)
        {
            //PlayerActive capturedUnit = unit;

            GameObject btnObj = Instantiate(buttonPrefabs, buttonSpawner);
            buttonSpawned.Add(btnObj);

            Button btn = btnObj.GetComponent<Button>();
            TextMeshProUGUI unitName = btnObj.GetComponentInChildren<TextMeshProUGUI>();
            unitName.text = unit.modelName;

            btn.onClick.AddListener(() =>
            {
                //Debug.Log(unit.modelName);
                if (isAllyTarget)
                {
                    Debug.Log("Buff Ally");
                    BattleManager.Instance.AssignSingleTarget(unit);
                    BattleManager.Instance.stateMachine.ChangeState(BattleManager.Instance.actionState);
                }
                else
                {
                    AssignButton(unit);
                }
            });
        }
    }

    void ButtonDestroy()
    {
        foreach (GameObject btn in buttonSpawned)
        {
            Destroy(btn);
        }
        playerActives = null;
    }

    private void OnDisable()
    {
        ButtonDestroy();
        buttonSpawned.Clear();
        if (isAllyTarget)
        {
            isAllyTarget = false;
        }
    }

    //Assign untuk Unit Skill
    void AssignButton(PlayerActive playerUnit)
    {
        ChooseUnitButton();
        ChooseAction.Instance.SpawnSkillButton(playerUnit);
    }

    public void BackToUnit()
    {
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, false);
        isAllyTarget = false;
        backButton.SetActive(false);
    }

    public void ChooseUnitButton()
    {
        //HudManager.Instance.PlayerUnitChoose(false);
        //HudManager.Instance.ActionChoice(true);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseAction, true);
    }
}

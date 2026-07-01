using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerUnit : Singleton<ChoosePlayerUnit>
{
    [SerializeField] PlayerActive[] playerActives;
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] Transform buttonSpawner;

    private void OnEnable()
    {
        playerActives = FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        ButtonSpawner();
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
                AssignButton(unit);
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
    }

    void AssignButton(PlayerActive playerUnit)
    {
        ChooseUnitButton();
        ChooseAction.Instance.SpawnSkillButton(playerUnit);
    }

    public void ChooseUnitButton()
    {
        HudManager.Instance.PlayerUnitChoose(false);
        HudManager.Instance.ActionChoice(true);
    }
}

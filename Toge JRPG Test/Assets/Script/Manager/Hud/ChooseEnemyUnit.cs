using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseEnemyUnit : Singleton<ChooseEnemyUnit>
{
    [SerializeField] EnemyActive[] enemyActives;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform buttonSpawner;

    private void OnEnable()
    {
        enemyActives = FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        SetUpButton();
    }

    List<GameObject> buttonSpanwed = new List<GameObject>();
    void SetUpButton()
    {
        foreach (var enemy in enemyActives)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonSpawner);
            Button targetButton = btn.GetComponent<Button>();
            buttonSpanwed.Add(btn);

            TextMeshProUGUI buttonText = btn.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = enemy.modelName;

            targetButton.onClick.AddListener(() =>
            {
                Debug.Log("Target Choose " + enemy.modelName);
            });
        }
    }

    void DestroyButton()
    {
        foreach(GameObject btn in buttonSpanwed)
        {
            Destroy(btn);
        }
        buttonSpanwed.Clear();
    }

    public void BackButton()
    {
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChooseEnemyUnit, false);
        HudManager.Instance.ToggleHUD(HudManager.Instance.ChoosePlayerUnit, true);
    }

    private void OnDisable()
    {
        DestroyButton();
        enemyActives = null;
    }
}

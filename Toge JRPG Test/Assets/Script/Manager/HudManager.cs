using UnityEngine;

public class HudManager : Singleton<HudManager>
{
    [Header("Exploration  HUD")]
    public GameObject ExplorationHud;

    [Header("Battle HUD")]
    public GameObject BattleHud;

    [Header("In Battle HUD")]
    public GameObject BattleMonitor;
    public GameObject ChoosePlayerUnit;
    public GameObject ChooseEnemyUnit;
    public GameObject ChooseAction;
    public GameObject QteHud;

    public void ShowHud(GameObject hudObj)
    {
        hudObj.SetActive(true);
    }

    public void HideHud(GameObject hudObj)
    {
        hudObj.SetActive(false);
    }

    #region GlobalMethod
    public void BattleHudSetUp()
    {
        ShowHud(BattleHud);
        HideHud(ExplorationHud);
    }

    public void ExplorationHudSetUp()
    {
        HideHud(BattleHud);
        ShowHud(ExplorationHud);
    }

    public void HideAllHud()
    {
        HideHud(BattleHud);
        HideHud(ExplorationHud);
    }

    public void OnExitAction()
    {
        ChooseEnemyUnit.SetActive(false);
        ChooseAction.SetActive(false);
        ChoosePlayerUnit.SetActive(false);
        QteHud.SetActive(false);
    }

    public void OnPlayerTurn()
    {
        ChoosePlayerUnit.SetActive(true);
        ChooseEnemyUnit.SetActive(false);
        ChooseAction.SetActive(false);
    }
    #endregion

    #region Battle HUD Method
    public void ToggleHUD(GameObject hud, bool toggle)
    {
        hud.SetActive(toggle);
    }
    #endregion
}

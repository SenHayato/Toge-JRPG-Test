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
}

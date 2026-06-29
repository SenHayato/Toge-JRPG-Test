using UnityEngine;

public class HudManager : Singleton<HudManager>
{
    [Header("Exploration  HUD")]
    [SerializeField] GameObject ExplorationHud;

    [Header("Battle HUD")]
    [SerializeField] GameObject BattleHud;

    [Header("In Battle HUD")]
    [SerializeField] GameObject BattleMonitor;
    [SerializeField] GameObject ChoosePlayerUnit;
    [SerializeField] GameObject ChooseEnemyUnit;
    [SerializeField] GameObject ChooseAction;
    [SerializeField] GameObject QteHud;

    private void Start()
    {

    }
}

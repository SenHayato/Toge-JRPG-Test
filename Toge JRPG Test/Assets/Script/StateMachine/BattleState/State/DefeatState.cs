using UnityEngine;

public class DefeatState : IState
{
    private BattleManager battleManager;

    public DefeatState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.Defeat;
        //lempar ke main menu
        Debug.Log("Masuk");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

using UnityEngine;

public class BattleEndState : IState
{
    private BattleManager battleManager;

    public BattleEndState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public  void Enter()
    {
        battleManager.battleProgress = BattleInProgress.BattleEnd;
        Debug.Log("Masuk");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

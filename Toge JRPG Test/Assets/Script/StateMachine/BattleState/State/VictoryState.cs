using UnityEngine;

public class VictoryState : IState
{
    private BattleManager battleManager;

    public VictoryState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }

    public void Enter()
    {
        battleManager.battleProgress = BattleInProgress.Victory;
        //jalankan cutscene akhir
        Debug.Log("Masuk");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Keluar");
    }
}

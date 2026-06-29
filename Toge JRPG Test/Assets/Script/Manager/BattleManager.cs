using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public BattleStateMachine stateMachine;

    [Header("Battle State")]
    public BattleInProgress battleProgress;
}

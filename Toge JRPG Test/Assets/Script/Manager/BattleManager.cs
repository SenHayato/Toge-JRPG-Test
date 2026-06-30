using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public BattleStateMachine stateMachine;

    //state
    public BattleStartState battleStart;
    public PlayerTurnState playerTurn;
    public EnemyTurnState enemyTurn;
    public ActionState actionState;
    public CheckBattleState checkBattle;
    public BattleEndState battleEnd;
    public DefeatState defeatState;
    public VictoryState victoryState;

    [Header("Battle State")]
    public BattleInProgress battleProgress;

    public override void Awake()
    {
        base.Awake();

        stateMachine = new BattleStateMachine();

        battleStart = new BattleStartState(this, stateMachine);
        playerTurn = new PlayerTurnState(this, stateMachine);
        enemyTurn = new EnemyTurnState(this, stateMachine);
        actionState = new ActionState(this, stateMachine);
        checkBattle = new CheckBattleState(this, stateMachine);
        battleEnd = new BattleEndState(this, stateMachine);
        defeatState = new DefeatState(this, stateMachine);
        victoryState = new VictoryState(this, stateMachine);
    }

    void StartBattle()
    {
        stateMachine.Initialize(battleStart);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}

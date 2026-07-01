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
    public SkillsSO selectedSkill;
    public PlayerActive selectedUnit;
    public PlayerActive[] targetAlly;
    public EnemyActive[] targetEnemy;

    //public override void Awake()
    //{
    //    base.Awake();
    //}

    private void Start()
    {
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

    public void StartBattle()
    {
        stateMachine.Initialize(battleStart);
    }

    private void Update()
    {
        if (stateMachine.currentState != null)
        {
            stateMachine.currentState.Update();
        }
    }

    #region Method
    public void SetUpBattle()
    {
        BattleSpawnerManager.Instance.AssignComponent();
        BattleSpawnerManager.Instance.SpawnUnit();
    }

    public void BattleStartToPlayerTurn()
    {
        Invoke(nameof(StartToPlayer), 0.2f);
    }

    void StartToPlayer()
    {
        ChangeBattleState(playerTurn);
    }

    public void ChangeBattleState(BattleState battleState)
    {
        stateMachine.ChangeState(battleState);
    }
    #endregion
    #region AssignData

    public void AssignData(SkillsSO skill)
    {
        selectedSkill = skill;
    }

    public void AssignData(PlayerActive unit)
    {
        selectedUnit = unit;
    }

    public void AssignMultipleTarget(PlayerActive[] units)
    {
        targetAlly = units;
    }

    public void AssingMultipleTarget(EnemyActive[] units)
    {
        targetEnemy = units;
    }
    #endregion
}

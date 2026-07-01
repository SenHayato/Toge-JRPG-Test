using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public StateMachine stateMachine;

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
    public CharacterUnit selectedUnit;
    public List<PlayerActive> targetAlly = new List<PlayerActive>();
    public List<EnemyActive> targetEnemy = new List<EnemyActive>();

    //public override void Awake()
    //{
    //    base.Awake();
    //}

    private void Start()
    {
        stateMachine = new StateMachine(this);

        battleStart = new BattleStartState(this);
        playerTurn = new PlayerTurnState(this);
        enemyTurn = new EnemyTurnState(this);
        actionState = new ActionState(this);
        checkBattle = new CheckBattleState(this);
        battleEnd = new BattleEndState(this);
        defeatState = new DefeatState(this);
        victoryState = new VictoryState(this);
    }

    public void StartBattle()
    {
        stateMachine.ChangeState(battleStart);
    }

    private void Update()
    {
        if (stateMachine.CurrentState != null)
        {
            stateMachine.CurrentState.Update();
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

    public void ChangeBattleState(IState battleState)
    {
        stateMachine.ChangeState(battleState);
    }

    //public IEnumerator ActionSkill(CharacterUnit user, Transform moveTarget)
    //{
    //    user = selectedUnit;
    //    SkillsSO skill = selectedSkill;
    //    List<EnemyActive> targets = targetEnemy;
    //    if (skill.UnitPosition == SkillPosition.MoveToTarget)
    //    {
    //        user.characterController.Move(moveTarget * 3f * Time.deltaTime);
    //    }

    //    user.stateMachine.ChangeState(stateMachine);

    //    yield return new WaitForSeconds(skill.Animation.length);

    //    skill.Execute(user, targets);

    //    battleManager.ChangeState(checkResultState);
    //}
    #endregion
    #region AssignData and Target

    public void AssignData(SkillsSO skill)
    {
        selectedSkill = skill;
    }

    public void AssignData(PlayerActive unit)
    {
        selectedUnit = unit;
    }

    public void AssignMultipleTarget(EnemyActive[] units)
    {
        units = FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach(EnemyActive unit in units)
        {
            targetEnemy.Add(unit);
        }
    }

    public void AssignMultipleTarget(PlayerActive[] units)
    {
        units = FindObjectsByType<PlayerActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach (PlayerActive unit in units)
        {
            targetAlly.Add(unit);
        }
    }

    public void AssignSingleTarget(PlayerActive unit)
    {
        targetAlly.Add(unit);
    }

    public void AssignSingleTarget(EnemyActive unit)
    {
        targetEnemy.Add(unit);
    }

    public void ClearTargetData()
    {
        if (targetEnemy != null)
        {
            targetEnemy.Clear();
        }

        if (targetAlly != null)
        {
            targetAlly.Clear();
        }
    }
    #endregion
}

using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public PlayerActive PlayerActive;
    public int enemyInBattle;
    public GameObject QteManagerHud;

    [Header("Flowcahrt")]
    [SerializeField] Flowchart flowCutscene;
    [SerializeField] string cutSceneBlock;

    [Header("Target Monitor")]
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

        PlayerActive = FindFirstObjectByType<PlayerActive>();
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
        enemyInBattle = FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None).Length;
        BattleSpawnerManager.Instance.AssignComponent();
        BattleSpawnerManager.Instance.SpawnUnit();
    }

    //panggil jika enemy spawn baru di tengah battle
    public void EnemyCountUp()
    {
        enemyInBattle++;
    }

    //panggil ketika HP musuh 0
    public void EnemyCountDown()
    {
        enemyInBattle--;
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

    [Header("Target to Skill")]
    public List<CharacterUnit> target = new List<CharacterUnit>();
    public void TargetAssign()
    {
        switch (selectedSkill.target)
        {
            case SkillTarget.Enemy:
                foreach (EnemyActive enemy in targetEnemy)
                {
                    target.Add(enemy);
                }
                break;
            case SkillTarget.Ally:
                foreach (PlayerActive player in targetAlly)
                {
                    Debug.Log("Kena target " + player.modelName);
                    target.Add(player);
                }
                break;
        }
    }

    //panggil di ActionState
    public IEnumerator ExecuteSkill(SkillsSO skill)
    {
        TargetAssign();

        if (skill.QteType != QTEType.NoNeed)
        {
            QteManagerHud.SetActive(true);
            if (skill.QteType == QTEType.Mash)
            {
                QTEManager.Instance.SetQTEText("Spam Button");
            }
            else
            {
                QTEManager.Instance.SetQTEText(" ");
            }
            yield return new WaitForSeconds(0.5f);

            QTEManager.Instance.StartQTE(skill.QteType);

            yield return new WaitUntil(() => !QTEManager.Instance.IsRunning);

            Debug.Log("Qte hasil " + QTEManager.Instance.Result);
            ApplySkillEffect(selectedSkill, QTEManager.Instance.Result);
            QteManagerHud.SetActive(false);
        }
        else
        {
            ApplySkillEffect(selectedSkill, QTEResult.None);
        }

            yield return new WaitForSeconds(skill.Animation.length);
        target.Clear();
        stateMachine.ChangeState(checkBattle);
    }

    //public void MoveToPosition(Transform target)
    //{
    //    if (selectedSkill.UnitPosition == SkillPosition.MoveToTarget)
    //    {
    //        Vector3 direction = (target.position - selectedUnit.transform.position).normalized;
    //        selectedUnit.characterController.Move(direction * selectedUnit.moveSpeed * Time.deltaTime);
    //    }
    //}

    public void SkillStart(int valueAdd) //panggil di action state setelah animasi
    {
        foreach (CharacterUnit unit in target)
        {
            switch (selectedSkill.skillType)
            {
                case SkillType.Attack:
                    unit.TakeDamage(selectedSkill.Power * valueAdd);
                    break;
                case SkillType.Heal:
                    unit.Heal(selectedSkill.Power * valueAdd);
                    break;
                case SkillType.Mana:
                    unit.FillMana(selectedSkill.Power * valueAdd);
                    break;
                case SkillType.Guard:
                    unit.Guard();
                    break;
            }
        }
    }

    void ApplySkillEffect(SkillsSO skill, QTEResult result)
    {
        int multiplier = 1;

        if (skill.QteType != QTEType.NoNeed)
        {
            if (skill.executor == SkillExecutor.Ally)
            {
                multiplier = result switch
                {
                    QTEResult.Perfect => 3,
                    QTEResult.Good => 2,
                    QTEResult.Failed => 1,
                    _ => 1
                };
            }
            else
            {
                multiplier = result switch
                {
                    QTEResult.Perfect => 0,
                    QTEResult.Good => 1,
                    QTEResult.Failed => 2,
                    _ => 1
                };
            }
        }

        SkillStart(multiplier);
    }

    //void UnitMove()
    //{
    //    if (selectedSkill.UnitPosition == SkillPosition.MoveToTarget)
    //    {
    //        Vector3 direction =
    //            (target[0].transform.position - selectedUnit.transform.position).normalized;selectedUnit.characterController.Move(
    //            direction * selectedUnit.moveSpeed * Time.deltaTime);
    //    }
    //}

    public void AssignData(SkillsSO skill)
    {
        selectedSkill = skill;
    }

    public void AssignData(CharacterUnit unit)
    {
        selectedUnit = unit;
    }

    public void AssignMultipleTarget(EnemyActive unit)
    {
        targetEnemy.Add(unit);
    }

    public void AssignMultipleTarget(PlayerActive unit)
    {
        targetAlly.Add(unit);
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

    public BattleInProgress wasTurn;

    public void CheckBattle()
    {
        if (PlayerActive.Health <= 0)
        {
            PlayerActive.stateMachine.ChangeState(PlayerActive.deadState);
            stateMachine.ChangeState(defeatState);
        }
        else if (enemyInBattle <= 0)
        {
            stateMachine.ChangeState(victoryState);
        }
        else
        {
            if (wasTurn == BattleInProgress.PlayerTurn)
            {
                stateMachine.ChangeState(enemyTurn);
            }
            else if (wasTurn == BattleInProgress.EnemyTurn)
            {
                stateMachine.ChangeState(playerTurn);
            }
        }
    }

    public List<EnemyActive> enemiesTurn;
    public void GetEnemyOnTurn()
    {
        enemiesTurn = new List<EnemyActive>(FindObjectsByType<EnemyActive>(FindObjectsInactive.Exclude, FindObjectsSortMode.None));
        int randomEnemy = Random.Range(0, enemiesTurn.Count);
        selectedUnit = enemiesTurn[randomEnemy];

        int randomSkill = Random.Range(0, selectedUnit.skillManager.skills.Count);
        selectedSkill = selectedUnit.skillManager.skills[randomSkill];

        ChooseAction.Instance.SelectSkill(selectedUnit, selectedSkill);
    }

    public void Defeat()
    {
        BackToMenu();
    }

    public void Victory()
    {
        flowCutscene.ExecuteBlock(cutSceneBlock);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
    #endregion
}

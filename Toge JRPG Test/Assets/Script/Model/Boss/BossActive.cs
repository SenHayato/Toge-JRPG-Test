using System;
using UnityEngine;

public class BossActive : EnemyActive
{
    [Header("Boss State")]
    public BossInState inState;
    public BossStateMachine stateMachine;

    public BossAttackState attackState;
    public BossDeadState deadState;
    public BossHurtState hurtState;
    public BossIdleState idleState;
    public BossWalkState walkState;

    public override void Awake()
    {
        stateMachine = new BossStateMachine();

        idleState = new BossIdleState(this, stateMachine);
        deadState = new BossDeadState(this, stateMachine);
        hurtState = new BossHurtState(this, stateMachine);
        attackState = new BossAttackState(this, stateMachine);
        walkState = new BossWalkState(this, stateMachine);

        MaxHealth = modelData.Health;
        modelName = modelData.EntityName;
        Attack = modelData.Attack;
        Defend = modelData.Defend;
        Aggility = modelData.Aggility;
        Mana = modelData.Mana;
    }

    public override void Start()
    {
        Health = MaxHealth;
        Health = Mathf.Max(0, MaxHealth);

        stateMachine.Initialize(idleState);
    }

    public override void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Method

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        stateMachine.ChangeState(hurtState);
    }

    public override void Hurt()
    {
        Invoke(nameof(ChangeToIdle), 0.4f);
    }

    void ChangeToIdle()
    {
        stateMachine.ChangeState(idleState);
    }

    public override void Dead()
    {
        if (Health <= 0)
        {
            stateMachine.ChangeState(deadState);
        }
        else
        {
            stateMachine.ChangeState(idleState);
        }
    }
    #endregion
}

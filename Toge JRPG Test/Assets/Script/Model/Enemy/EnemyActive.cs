using System;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class EnemyActive : CharacterUnit
{
    public override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(this);

        idleState = new IdleState(this);
        attackState = new AttackState(this);
        hurtState = new HurtState(this);
        deadState = new DeadState(this);
        moveState = new MoveState(this);
    }
    public override void Start()
    {
        base.Start();

        MaxHealth = modelData.Health;
        modelName = modelData.EntityName;
        Attack = modelData.Attack;
        Defend = modelData.Defend;
        Aggility = modelData.Aggility;
        Mana = modelData.Mana;

        Health = MaxHealth;
        Health = Mathf.Max(0, MaxHealth);

        stateMachine.ChangeState(idleState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void ChangeToAttackState(int attackNum)
    {
        base.ChangeToAttackState(attackNum);
        attackState.attackNum = attackNum;
        stateMachine.ChangeState(attackState);
    }

    public override void TakeDamage(int damage)
    {
        if (isGuard)
        {
            isGuard = false;
            Health -= damage;
        }
        else
        {
            Health -= damage;
        }
        Dead();
        base.TakeDamage(damage);
        //Ubah state di script turunan masing-masing
    }

    public override void Heal(int healValue)
    {

    }

    public override void FillMana(int manaValue)
    {

    }

    public override void Hurt()
    {
        Invoke(nameof(ChangeToIdle), 0.4f);
    }

    public override void ChangeToIdle()
    {
        base.ChangeToIdle();
        stateMachine.ChangeState(idleState);
    }

    public override void Dead()
    {
        base.Dead();
        if (Health <= 0)
        {
            stateMachine.ChangeState(deadState);
            BattleManager.Instance.EnemyCountDown();
        }
    }
}

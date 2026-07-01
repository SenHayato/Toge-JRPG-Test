using System;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class EnemyActive : CharacterUnit
{
    public override void Awake()
    {
        stateMachine = new StateMachine(this);

        idleState = new IdleState(this);
        attackState = new AttackState(this);
        hurtState = new HurtState(this);
        deadState = new DeadState(this);
        moveState = new MoveState(this);

        MaxHealth = modelData.Health;
        modelName = modelData.EntityName;
        Attack = modelData.Attack;
        Defend = modelData.Defend;
        Aggility = modelData.Aggility;
        Mana = modelData.Mana;

        base.Awake();
    }
    public override void Start()
    {
        base.Start();
        stateMachine.ChangeState(idleState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        base.TakeDamage(damage);
        //Ubah state di script turunan masing-masing
    }

    public override void Heal(int healValue)
    {

    }

    public override void FillMana(int manaValue)
    {

    }

    public override void Hurt() { }

    public override void Dead() { }
}

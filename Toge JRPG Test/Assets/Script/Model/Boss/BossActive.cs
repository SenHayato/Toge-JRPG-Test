using System;
using UnityEngine;

public class BossActive : EnemyActive
{
    //public override void Awake()
    //{
    //    MaxHealth = modelData.Health;
    //    modelName = modelData.EntityName;
    //    Attack = modelData.Attack;
    //    Defend = modelData.Defend;
    //    Aggility = modelData.Aggility;
    //    Mana = modelData.Mana;
    //}

    public override void Start()
    {
        MaxHealth = modelData.Health;
        modelName = modelData.EntityName;
        Attack = modelData.Attack;
        Defend = modelData.Defend;
        Aggility = modelData.Aggility;
        Mana = modelData.Mana;

        Health = MaxHealth;
        Health = Mathf.Max(0, MaxHealth);

        //stateMachine.Initialize(idleState);
    }

    public override void Update()
    {
        //stateMachine.currentState.Update();
    }

    #region Method

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        base.TakeDamage(damage);
    }

    //public override void Hurt()
    //{
    //    Invoke(nameof(ChangeToIdle), 0.4f);
    //}

    //public void ChangeToIdle()
    //{
    //    stateMachine.ChangeState(idleState);
    //}

    //public override void Dead()
    //{
    //    if (Health <= 0)
    //    {
    //        stateMachine.ChangeState(deadState);
    //    }
    //    else
    //    {
    //        stateMachine.ChangeState(idleState);
    //    }
    //}
    #endregion
}

using System;
using UnityEngine;

public class BossActive : EnemyActive
{
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

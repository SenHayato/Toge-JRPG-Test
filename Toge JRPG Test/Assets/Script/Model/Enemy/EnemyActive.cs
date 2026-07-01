using System;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class EnemyActive : CharacterUnit
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
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

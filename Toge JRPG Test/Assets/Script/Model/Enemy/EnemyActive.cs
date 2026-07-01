using System;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class EnemyActive : MonoBehaviour, IDamageable
{
    [Header("Enemy Status")]
    public EntitySO modelData;
    public string modelName;
    public int MaxHealth;
    public int Health;
    public int Attack;
    public int Defend;
    public int Mana;
    public int Aggility;

    [Header("Enemy Compoenent")]
    public Animator enemyAnimator;
    public SpriteRenderer spriteRenderer;
    public SkillManagerSO skillManager;

    public event Action<int, int> OnHealthChanged;
    public virtual void Awake()
    {

    }
    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Dead();
        OnHealthChanged?.Invoke(Health, MaxHealth);
        //Ubah state di script turunan masing-masing
    }

    public void Heal(int healValue)
    {
        Health += healValue;
        OnHealthChanged?.Invoke(Health, MaxHealth);
    }

    public void FillMana(int manaValue)
    {
        Mana += manaValue;
    }

    public virtual void Hurt() { }

    public virtual void Dead() { }
}

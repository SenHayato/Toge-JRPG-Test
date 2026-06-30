using System;
using UnityEngine;

public class BossActive : MonoBehaviour, IDamageable
{
    [Header("Boss State")]
    public BossInState inState;
    public BossStateMachine stateMachine;

    public BossAttackState attackState;
    public BossDeadState deadState;
    public BossHurtState hurtState;
    public BossIdleState idleState;
    public BossWalkState walkState;

    [Header("Boss Status")]
    [SerializeField] EntitySO modelData;
    public string modelName;
    public int MaxHealth;
    public int Health;
    [SerializeField] int Attack;
    [SerializeField] int Defend;
    [SerializeField] int Mana;
    [SerializeField] int Aggility;

    [Header("Boss Compoenent")]
    public Animator bossAnimator;
    public SpriteRenderer spriteRenderer;

    public event Action<int, int> OnHealthChanged;

    private void Awake()
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

    private void Start()
    {
        Health = MaxHealth;
        Health = Mathf.Max(0, MaxHealth);

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Method
    public void Dead()
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        stateMachine.ChangeState(hurtState);

        OnHealthChanged?.Invoke(Health, MaxHealth);
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

    public void Hurt()
    {
        Invoke(nameof(ChangeToIdle), 0.4f);
    }

    void ChangeToIdle()
    {
        stateMachine.ChangeState(idleState);
    }
    #endregion
}

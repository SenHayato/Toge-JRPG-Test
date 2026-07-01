using System;
using UnityEngine;

public abstract class CharacterUnit : MonoBehaviour, IDamageable
{
    [Header("State Monitor")]
    public CharactherInState inState;
    public StateMachine stateMachine;

    public IdleState idleState;
    public HurtState hurtState;
    public DeadState deadState;
    public MoveState moveState;
    public AttackState attackState;

    [Header("Status")]
    public EntitySO modelData;
    public string modelName;
    public int MaxHealth;
    public int Health;
    public int Attack;
    public int Defend;
    public int Mana;
    public int Aggility;
    public bool isRunning = false;

    [Header("Compoenent")]
    public Animator charAnimator;
    public SpriteRenderer spriteRenderer;
    public SkillManagerSO skillManager;

    [Header("Component")]
    public float moveSpeed;
    public Vector2 moveValue;
    public CharacterController characterController;

    public event Action<int, int> OnHealthChanged;
    public virtual void Awake() { }

    public virtual void Update() { }

    public virtual void Start() { }

    public virtual void OnDestroy() { }

    public virtual void OnDisable() { }

    public virtual void OnEnable() { }

    public virtual void Movement() { }

    public virtual void TakeDamage(int damage)
    {
        Dead();
        OnHealthChanged?.Invoke(Health, MaxHealth);
        //Ubah state di script turunan masing-masing
    }

    public virtual void Heal(int healValue)
    {
        Health += healValue;
        OnHealthChanged?.Invoke(Health, MaxHealth);
    }

    public virtual void FillMana(int manaValue)
    {
        Mana += manaValue;
    }

    public virtual void Dead() { }

    public virtual void Hurt() { }
}

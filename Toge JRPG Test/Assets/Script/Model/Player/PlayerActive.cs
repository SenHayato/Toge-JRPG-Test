using System;
using UnityEngine;

public class PlayerActive : CharacterUnit, IDamageable
{
    [Header("State Monitor")]
    public PlayerInState playerInState;
    public PlayerStateMachine stateMachine;
    public bool isRunning = false;

    public PlayerIdleState idleState;
    public PlayerAttackState attackState;
    public PlayerHurtState hurtState;
    public PlayerDeadState deadState;
    public PlayerWalkState walkState;

    [Header("Unit Status")]
    [SerializeField] EntitySO modelData;
    public string modelName;
    public int MaxHealth;
    public int Health;
    [SerializeField] int Attack;
    [SerializeField] int Defend;
    [SerializeField] int Aggility;
    [SerializeField] int Mana;
    public float moveSpeed;
    public SkillManagerSO skillManager;

    [Header("Player Component")]
    public Vector2 moveValue;
    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    [SerializeField] CharacterController characterController;

    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] InputActive inputActive;

    public event Action<int, int> OnHealthChanged;

    public override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine);
        attackState = new PlayerAttackState(this, stateMachine);
        hurtState = new PlayerHurtState(this, stateMachine);
        deadState = new PlayerDeadState(this, stateMachine);
        walkState = new PlayerWalkState(this, stateMachine);

        MaxHealth = modelData.Health;
        modelName = modelData.EntityName;
        Attack = modelData.Attack;
        Defend = modelData.Defend;
        Aggility = modelData.Aggility;
        Mana = modelData.Mana;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Health = MaxHealth;
        Health = Mathf.Max(0, MaxHealth);
    }

    public override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);

        gameManager = FindFirstObjectByType<GameManager>();
        inputActive = FindFirstObjectByType<InputActive>();

        OnHealthChanged?.Invoke(Health, MaxHealth);
    }

    public override void Update()
    {
        base.Update();
        if (gameManager.gameState == GameState.Exploration)
        {
            stateMachine.currentState.Update();
            if (gameManager.gameState != GameState.Battle)
            {
                ApplyGravity();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            Debug.Log("Tabrak " + other.name);
            inputActive.currentInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (inputActive.currentInteractable != null)
        {
            inputActive.currentInteractable = null;
            Debug.Log("Keluar " + other.name);
        }
    }

    #region PlayerLogic
    public void Movement()
    {
        Vector2 movePosition = moveValue * moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new(movePosition.x, 0f, movePosition.y);
        characterController.Move(moveDirection);
    }

    public void ChangStateAttack(int attackNum)
    {
        attackState.AttackNumber = attackNum;
        stateMachine.ChangeState(attackState);
    }

    float verticalVelocity;
    [SerializeField] float gravity;

    public void ApplyGravity()
    {
        verticalVelocity += gravity * Time.deltaTime;

        characterController.Move(Vector3.down * verticalVelocity * Time.deltaTime);
    }

    public void Revive()
    {
        if (Health > 0)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Dead()
    {
        if (Health <= 0)
        {
            playerInState = PlayerInState.Dead;
            stateMachine.ChangeState(deadState);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        stateMachine.ChangeState(hurtState);
        Dead();
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

    public void ChangeToIdle()
    {
        stateMachine.ChangeState(idleState);
    }
    #endregion

    //public void AnimationWalk()
    //{
    //    //playerAnimator.Play("Move.Walk", 0, 0f);
    //    playerAnimator.Play("Dead");
    //}

    //void ResetParameter()
    //{
    //    AnimatorSetting.ResetAllParameters(playerAnimator);
    //}
    #region Testing
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Damage"))
    //    {
    //        TakeDamage(50);
    //    }
    //}
    #endregion
}

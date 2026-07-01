using System;
using UnityEngine;

public class PlayerActive : CharacterUnit
{
    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] InputActive inputActive;

    public override void Awake()
    {
        base.Awake();
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
        stateMachine.ChangeState(idleState);

        gameManager = FindFirstObjectByType<GameManager>();
        inputActive = FindFirstObjectByType<InputActive>();
    }

    public override void Update()
    {
        base.Update();
        stateMachine.CurrentState.Update();
        if (gameManager.gameState == GameState.Exploration)
        {
            //stateMachine.currentState.Update();
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
    public override void Movement()
    {
        Vector2 movePosition = moveValue * moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new(movePosition.x, 0f, movePosition.y);
        characterController.Move(moveDirection);
    }

    //public void ChangStateAttack(int attackNum)
    //{
    //    attackState.AttackNumber = attackNum;
    //    stateMachine.ChangeState(attackState);
    //}

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

    public override void Hurt()
    {
        Invoke(nameof(ChangeToIdle), 0.4f);
    }

    public void ChangeToIdle()
    {
        stateMachine.ChangeState(idleState);
    }

    public override void TakeDamage(int damage)
    {
        if (!gameManager.testing)
        {
            Health -= damage;
        }
        base.TakeDamage(damage);
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

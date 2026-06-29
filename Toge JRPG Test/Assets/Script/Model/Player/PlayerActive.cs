using Unity.VisualScripting;
using UnityEngine;

public class PlayerActive : MonoBehaviour
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

    [Header("Player Status")]
    [SerializeField] EntitySO modelData;
    public string modelName;
    [SerializeField] int MaxHealth;
    [SerializeField] int Health;
    [SerializeField] int Attack;
    [SerializeField] int Defend;
    [SerializeField] int Aggility;
    [SerializeField] int Mana;
    public float moveSpeed;

    [Header("Player Component")]
    public Vector2 moveValue;
    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;
    [SerializeField] CharacterController characterController;

    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] InputActive inputActive;

    private void Awake()
    {
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

    private void Start()
    {
        Health = MaxHealth;
        Health = Mathf.Max(0, Health);

        stateMachine.Initialize(idleState);

        gameManager = FindFirstObjectByType<GameManager>();
        inputActive = FindFirstObjectByType<InputActive>();
    }

    private void Update()
    {
        if (gameManager.gameState == GameState.Exploration || gameManager.gameState == GameState.Battle)
        {
            stateMachine.currentState.Update();
        }
        ApplyGravity();
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
        //transform.position += new Vector3(movePosition.x, 0f, movePosition.y);
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

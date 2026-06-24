using UnityEngine;

public enum PlayerInState
{
    Idle, Walk, Hurt, Attack, Dead
}

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
    [SerializeField] int MaxHealth;
    [SerializeField] int Heatlh;
    [SerializeField] int Attack;
    public float moveSpeed;

    [Header("Player Component")]
    public Vector2 moveValue;
    public SpriteRenderer spriteRenderer;
    public Animator playerAnimator;

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState (this, stateMachine);
        attackState = new PlayerAttackState (this, stateMachine);
        hurtState = new PlayerHurtState(this, stateMachine);
        deadState = new PlayerDeadState (this, stateMachine);
        walkState = new PlayerWalkState (this, stateMachine);
    }

    private void Start()
    {
        Heatlh = MaxHealth;
        Heatlh = Mathf.Max(0, Heatlh);

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    #region PlayerLogic
    public void Movement()
    {
        Vector2 movePosition = moveValue * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(movePosition.x, 0f, movePosition.y);
    }

    public void Revive()
    {
        if (Heatlh > 0)
        {
            stateMachine.ChangeState(idleState);
        }
    }

    public void Dead()
    {
        if (Heatlh <= 0)
        {
            playerInState = PlayerInState.Dead;
            stateMachine.ChangeState(deadState);
        }
    }

    public void TakeDamage(int damage)
    {
        Heatlh -= damage;
        stateMachine.ChangeState(hurtState);
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

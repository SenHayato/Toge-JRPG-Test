using UnityEngine;

public enum BossInState
{
    Idle, Attack, Hurt, Dead, Walk
}

public class BossActive : MonoBehaviour
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
    [SerializeField] int MaxHealth;
    [SerializeField] int Health;
    [SerializeField] int Attack;
    [SerializeField] float moveSpeed;

    [Header("Boss Compoenent")]
    public Animator bossAnimator;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        stateMachine = new BossStateMachine();

        idleState = new BossIdleState(this, stateMachine);
        deadState = new BossDeadState(this, stateMachine);
        hurtState = new BossHurtState(this, stateMachine);
        attackState = new BossAttackState(this, stateMachine);
        walkState = new BossWalkState(this, stateMachine);
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

    public void TakeDamage (int damage)
    {
        Health -= damage;
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
}

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
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}

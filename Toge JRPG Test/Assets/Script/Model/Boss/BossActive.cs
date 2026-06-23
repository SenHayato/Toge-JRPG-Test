using UnityEngine;

public class BossActive : MonoBehaviour
{
    public BossStateMachine stateMachine;

    public BossAttackState attackState;
    public BossDeadState deadState;
    public BossHurtState hurtState;
    public BossIdleState idleState;
    public BossWalkState walkState;

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
}

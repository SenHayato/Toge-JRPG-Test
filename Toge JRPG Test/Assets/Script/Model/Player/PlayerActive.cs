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

    public PlayerIdleState idleState;
    public PlayerAttackState attackState;
    public PlayerHurtState hurtState;
    public PlayerDeadState deadState;
    public PlayerWalkState walkState;

    [Header("Player Component")]
    public Vector2 moveValue;
    [SerializeField] float moveSpeed;
    public SpriteRenderer spriteRenderer;

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
    #endregion
}

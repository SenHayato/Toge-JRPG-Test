using UnityEngine;

public class PlayerState
{
    protected PlayerActive playerActive;
    protected PlayerStateMachine playerStateMachine;

    public PlayerState(PlayerActive playerActives, PlayerStateMachine playerStateMachine)
    {
        this.playerActive = playerActives;
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update()
    {
        playerActive.Dead();
        playerActive.ApplyGravity();
    }
    public virtual void Exit() { }
}

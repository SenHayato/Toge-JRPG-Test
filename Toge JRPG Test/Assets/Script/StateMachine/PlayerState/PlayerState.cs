using UnityEngine;

public class PlayerState
{
    protected PlayerActive playerActive;
    protected PlayerStateMachine playerStateMachine;

    public PlayerState(PlayerActive playerActives, PlayerStateMachine stateMachine)
    {
        this.playerActive = playerActives;
        this.playerStateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

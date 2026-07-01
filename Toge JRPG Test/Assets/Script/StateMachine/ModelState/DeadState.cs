using UnityEngine;

public class DeadState : IState
{
    private CharacterUnit unit;

    public DeadState(CharacterUnit unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.inState = CharactherInState.Dead;
        unit.charAnimator.SetBool("IsDead", true);
    }

    public void Update() { }

    public void Exit()
    {
        unit.charAnimator.SetBool("IsDead", false);
    }
}

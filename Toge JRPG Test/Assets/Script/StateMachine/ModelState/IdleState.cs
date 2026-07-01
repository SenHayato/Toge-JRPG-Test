using UnityEngine;

public class IdleState : IState
{
    private CharacterUnit unit;

    public IdleState(CharacterUnit unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.inState = CharactherInState.Move;
        unit.charAnimator.SetBool("IsIdle", true);
    }

    public void Update()
    {
        if (unit.moveValue != Vector2.zero)
        {
            unit.stateMachine.ChangeState(unit.moveState);
        }
    }

    public void Exit()
    {
        unit.charAnimator.SetBool("IsIdle", false);
    }
}

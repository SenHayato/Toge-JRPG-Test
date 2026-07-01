using UnityEngine;

public class MoveState : IState
{
    private CharacterUnit unit;

    public MoveState(CharacterUnit unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.inState = CharactherInState.Move;
        unit.charAnimator.SetBool("IsMove", true);
    }

    public void Update()
    {
        unit.charAnimator.SetBool("IsRun", unit.isRunning);
        Running();
        FlipSprite();
        unit.Movement();
        if (unit.moveValue == Vector2.zero)
        {
            unit.stateMachine.ChangeState(unit.idleState);
        }
    }

    public void Exit()
    {
        unit.charAnimator.SetBool("IsMove", false);
        unit.charAnimator.SetBool("IsRun", false);
    }

    void FlipSprite()
    {
        if (unit.moveValue.x < 0)
        {
            unit.spriteRenderer.flipX = true;
        }
        else
        {
            unit.spriteRenderer.flipX= false;
        }
    }

    void Running()
    {
        if (unit.isRunning)
        {
            unit.moveSpeed = 5;
        }
        else
        {
            unit.moveSpeed = 1.5f;
        }
    }
}

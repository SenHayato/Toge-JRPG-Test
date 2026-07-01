using UnityEngine;

public class HurtState : IState
{
    private CharacterUnit unit;

    public HurtState(CharacterUnit unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.inState = CharactherInState.Hurt;
        unit.charAnimator.SetBool("IsHurt", true);
    }

    public void Update() { }

    public void Exit()
    {
        unit.charAnimator.SetBool("IsHurt", false);
    }
}

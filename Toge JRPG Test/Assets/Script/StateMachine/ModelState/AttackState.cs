using UnityEngine;

public class AttackState : IState
{
    private CharacterUnit unit;
    public int attackNum;
    public AttackState(CharacterUnit unit)
    {
        this.unit = unit;
    }

    public void Enter()
    {
        unit.inState = CharactherInState.Attack;
        unit.PlayAttackSound();
        unit.charAnimator.SetInteger("AttackNum", attackNum);
        unit.charAnimator.SetBool("IsAttack", true);
        unit.charAnimator.SetBool("IsIdle", false);
    }

    public void Update() { }

    public void Exit()
    {
        unit.charAnimator.SetInteger("AttackNum", 0);
        unit.charAnimator.SetBool("IsAttack", false);
    }
}

using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage);
    public void Heal(int healValue);
    public void FillMana(int manaValue);
}

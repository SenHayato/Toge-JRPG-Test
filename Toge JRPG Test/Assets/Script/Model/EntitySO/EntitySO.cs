using UnityEngine;

[CreateAssetMenu(fileName = "EntitySO", menuName = "Scriptable Objects/EntitySO")]
public class EntitySO : ScriptableObject
{
    public string EntityName;
    public int MaxHealth;
    public int DefaultAttack;
    public int DefaultDefend;
    public float MoveSpeed;
}

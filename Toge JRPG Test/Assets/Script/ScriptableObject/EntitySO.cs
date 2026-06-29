using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntitySO", menuName = "Scriptable Objects/EntitySO")]
public class EntitySO : ScriptableObject
{
    public string EntityName;
    public int Health;
    public int Mana;
    public int Attack;
    public int Defend;
    public int Aggility;
    public List<SkillsSO> skills;
}

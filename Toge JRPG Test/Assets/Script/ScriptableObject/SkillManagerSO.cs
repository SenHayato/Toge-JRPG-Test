using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "Scriptable Objects/SkillManager")]
public class SkillManagerSO : ScriptableObject
{
    public List<SkillsSO> skills = new List<SkillsSO>();
}

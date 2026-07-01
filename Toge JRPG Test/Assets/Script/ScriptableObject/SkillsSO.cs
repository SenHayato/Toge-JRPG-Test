using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "Scriptable Objects/SkillsSO")]
public class SkillsSO : ScriptableObject
{
    public string SkillName;
    public int ManaCost;
    public int Power;
    public int AttackNumber;
    public SkillTarget target;
    public SkillType skillType; 
    public SkillTargetType TargetType;
    public SkillPosition UnitPosition;
    public AnimationClip Animation;
    public QTEType QteType;
}
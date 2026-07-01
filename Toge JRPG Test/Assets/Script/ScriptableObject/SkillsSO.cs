using UnityEngine;

[CreateAssetMenu(fileName = "SkillsSO", menuName = "Scriptable Objects/SkillsSO")]
public class SkillsSO : ScriptableObject
{
    public string SkillName;
    public int ManaCost;
    public int Power;
    public SkillTargetType TargetType;
    public AnimationClip Animation;
    public QTEType QteType;
}
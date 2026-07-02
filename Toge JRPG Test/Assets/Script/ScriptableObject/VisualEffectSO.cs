using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VisualEffect
{
    public VisualType VisualType;
    public GameObject visualObj;
}

[CreateAssetMenu(fileName = "VisualEffectSO", menuName = "Scriptable Objects/VisualEffectSO")]
public class VisualEffectSO : ScriptableObject
{
    public List<VisualEffect> effects = new List<VisualEffect>();
}

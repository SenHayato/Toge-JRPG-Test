using UnityEngine;

public class ChooseAction : Singleton<ChooseAction>
{
    [SerializeField] GameObject buttonPrefabs;
    [SerializeField] Transform buttonSpawner;

    public void OnEnable()
    {
        
    }

    public void SpawnSkillButton(PlayerActive unit)
    {
        //SkillsSO[] skills = unit.skillManager.skills;
        Debug.Log("Skill " + unit.modelName);
    }

    public void BackToUnit()
    {
        HudManager.Instance.PlayerUnitChoose(true);
        HudManager.Instance.ActionChoice(false);
    }
}

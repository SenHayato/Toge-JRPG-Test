using UnityEngine;

public class ChoosePlayerUnit : Singleton<ChoosePlayerUnit>
{
    public void ChooseUnitButton()
    {
        HudManager.Instance.PlayerUnitChoose(false);
        HudManager.Instance.ActionChoice(true);
    }
}

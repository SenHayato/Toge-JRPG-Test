using UnityEngine;

public class ChoosePlayerUnit : MonoBehaviour
{
    public void ChooseUnitButton()
    {
        HudManager.Instance.PlayerUnitChoose(false);
        HudManager.Instance.ActionChoice(true);
    }
}

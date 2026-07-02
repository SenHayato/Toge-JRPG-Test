using UnityEngine;

public class Footstep : MonoBehaviour
{
    public void FootStepSound()
    {
        AudioManager.Instance.PlaySound(SoundType.Walk, false);
    }
}

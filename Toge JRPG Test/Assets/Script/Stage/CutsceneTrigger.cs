using Fungus;
using UnityEngine;
using static System.TimeZoneInfo;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockName;
    [SerializeField] LayerMask playerMask;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerMask) != 0)
        {
            flowchart.ExecuteBlock(blockName);
            gameManager.ChangeToCutscene();
        }
    }

    //public void TriggerInteract()
    //{
    //    flowchart.ExecuteBlock(blockName);
    //    gameManager.ChangeToCutscene();
    //}
}

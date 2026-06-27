using Fungus;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockName;
    [SerializeField] LayerMask playerMask;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerMask)
        {
            flowchart.ExecuteBlock(blockName);
            gameManager.ChangeToCutscene();
        }
    }
}

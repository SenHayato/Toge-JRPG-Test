using Fungus;
using TMPro;
using UnityEngine;

public class StageTransition : MonoBehaviour
{
    [Header("Transition Component")]
    [SerializeField] LayerMask playerLayer;
    [SerializeField] TransitionType transitionType;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockNameTrigger;

    [Header("Hover Component")]
    [SerializeField] GameObject canvasPopUp;
    [SerializeField] TextMeshProUGUI tmpPopUp;
    [SerializeField] string popUpText;
    
    void Start()
    {
        canvasPopUp.SetActive(false);
        CanvasSetUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer && transitionType == TransitionType.Trigger)
        {
            ExecuteTrans();
            Debug.Log("Trigger");
        }
        else if (other.gameObject.layer == playerLayer && transitionType == TransitionType.Hover)
        {
            canvasPopUp.SetActive(true);
            Debug.Log("Hover");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer && transitionType == TransitionType.Hover)
        {
            canvasPopUp.SetActive(false);
            Debug.Log("Hover Exit");
        }
    }

    void ExecuteTrans()
    {
        flowchart.ExecuteBlock(blockNameTrigger);
    }

    void CanvasSetUp()
    {
        tmpPopUp.text = popUpText;
    }

    enum TransitionType
    {
        Hover, Trigger
    }
}

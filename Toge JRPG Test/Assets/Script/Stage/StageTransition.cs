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
    [SerializeField] float direction;

    [Header("Hover Component")]
    [SerializeField] GameObject canvasPopUp;
    [SerializeField] TextMeshProUGUI tmpPopUp;
    [SerializeField] string popUpText;

    //[Header("Reference")]
    //[SerializeField] GameManager gameManager;
    //[SerializeField] PlayerActive playerActive;
    
    void Start()
    {
        canvasPopUp.SetActive(false);
        CanvasSetUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transitionType == TransitionType.Trigger && ((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            ExecuteTrans();
            Debug.Log("Trigger");
        }
        else if (transitionType == TransitionType.Hover && ((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            canvasPopUp.SetActive(true);
            Debug.Log("Hover");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transitionType == TransitionType.Hover && ((1 << other.gameObject.layer) & playerLayer) != 0)
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

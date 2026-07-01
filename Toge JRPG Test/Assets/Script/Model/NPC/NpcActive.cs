using Fungus;
using UnityEngine;

public class NpcActive : CharacterUnit, IInteractable
{
    [Header("Dialogue")]
    [SerializeField] DialogueSO modelDialogue;
    [SerializeField] Flowchart npcFlowchart;
    [SerializeField] string blockName;
    [SerializeField] GameObject interactionPopUp;

    [Header("Condition")]
    [SerializeField] bool inInteraction;

    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerActive playerActive;

    public override void Awake()
    {
        base.Awake();
        modelName = modelData.EntityName;
        blockName = modelDialogue.blockName;
        interactionPopUp.SetActive(true);
    }

    public override void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerActive = FindFirstObjectByType<PlayerActive>();
    }

    public void Interact()
    {
        InteractToggle();
        if (!inInteraction)
        {
            inInteraction = true;
            npcFlowchart.ExecuteBlock(blockName);
            playerActive.ChangeToIdle();
            gameManager.ChangeToDialogue();
            Debug.Log("Berinteraksi dengan " + modelName);
        }
    }

    public void InteractDone()
    {
        if (inInteraction)
        {
            inInteraction = false;
        }

        InteractToggle();
    }

    public void InteractToggle()
    {
        if (!inInteraction)
        {
            interactionPopUp.SetActive(true);
        }
        else
        {
            interactionPopUp.SetActive(false);
        }
    }

    //void Update()
    //{

    //}
}

using Fungus;
using UnityEngine;

public class NpcActive : MonoBehaviour,  IInteractable
{
    [Header("NPC Stats")]
    [SerializeField] EntitySO modelData;
    [SerializeField] string modelName;

    [Header("Dialogue")]
    [SerializeField] DialogueSO modelDialogue;
    [SerializeField] Flowchart npcFlowchart;
    [SerializeField] string blockName;

    [Header("Condition")]
    [SerializeField] bool inInteraction;

    [Header("Reference")]
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerActive playerActive;

    private void Awake()
    {
        modelName = modelData.EntityName;
        blockName = modelDialogue.blockName;
    }

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerActive = FindFirstObjectByType<PlayerActive>();
    }

    public void Interact()
    {
        if (!inInteraction)
        {
            //inInteraction = true;
            npcFlowchart.ExecuteBlock(blockName);
            playerActive.ChangeToIdle();
            gameManager.ChangeToDialogue();
            Debug.Log("Berinteraksi dengan " + modelName);
        }
    }

    void Update()
    {
        
    }
}

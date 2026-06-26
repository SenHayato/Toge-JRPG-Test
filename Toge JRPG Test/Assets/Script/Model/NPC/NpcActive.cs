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

    private void Awake()
    {
        modelName = modelData.EntityName;
        blockName = modelDialogue.blockName;
    }

    public void Interact()
    {
        if (!inInteraction)
        {
            //inInteraction = true;
            npcFlowchart.ExecuteBlock(blockName);
            Debug.Log("Berinteraksi dengan " + modelName);
        }
    }

    void Update()
    {
        
    }
}

using UnityEngine;

public class NpcActive : MonoBehaviour,  IInteractable
{
    [SerializeField] EntitySO modelData;
    [SerializeField] string modelName;

    [Header("Condition")]
    [SerializeField] bool inInteraction;
    void Start()
    {
        modelName = modelData.EntityName;
    }

    public void Interact()
    {
        if (!inInteraction)
        {
            inInteraction = true;
            Debug.Log("Berinteraksi dengan " + modelName);
        }
    }

    void Update()
    {
        
    }
}

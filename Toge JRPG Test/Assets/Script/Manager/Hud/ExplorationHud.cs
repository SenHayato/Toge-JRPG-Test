using UnityEngine;
using UnityEngine.UI;

public class ExplorationHud : MonoBehaviour
{
    [SerializeField] Slider playerHp;
    [SerializeField] PlayerActive playerActive;
    float playerHpValue => playerActive.Health;
    float maxPlayerHp => playerActive.MaxHealth;
    void Start()
    {
        playerActive = FindFirstObjectByType<PlayerActive>();

        Debug.Log(playerHpValue.ToString()+ " " + maxPlayerHp.ToString());
    }

    void SetUpBar()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;

public class BattleMonitorHud : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] PlayerActive playerActive;
    [SerializeField] Slider playerHpBar;

    [Header("Boss Stats")]
    [SerializeField] BossActive bossActive;
    [SerializeField] Slider bossHpBar;

    //private void Awake()
    //{
        
    //}

    private void OnEnable()
    {
        playerActive = FindFirstObjectByType<PlayerActive>();
        bossActive = FindFirstObjectByType<BossActive>();
    }

    private void Start()
    {
        SetUpHealthBar();
    }

    void SetUpHealthBar()
    {
        if (playerActive != null)
        {
            UpdatePlayerHealth(playerActive.Health, playerActive.MaxHealth);
            playerActive.OnHealthChanged += UpdatePlayerHealth;
        }

        if (bossActive != null)
        {
            UpdateBossHealth(bossActive.Health, bossActive.MaxHealth);
            bossActive.OnHealthChanged += UpdateBossHealth;
        }
    }
        

    private void OnDisable()
    {
        if (playerActive != null)
        {
            playerActive.OnHealthChanged -= UpdatePlayerHealth;
        }

        if (bossActive != null)
        {
            bossActive.OnHealthChanged -= UpdateBossHealth;
        }
    }

    void UpdatePlayerHealth(int currentHp, int maxHp)
    {
        //Debug.Log("Player " + currentHp);
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = currentHp;
    }

    void UpdateBossHealth(int currentHp, int maxHp)
    {
        //Debug.Log("Boss " + currentHp);
        bossHpBar.maxValue = maxHp;
        bossHpBar.value = currentHp;
    }
}

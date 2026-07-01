using UnityEngine;
using UnityEngine.UI;

public class BattleMonitorHud : Singleton<BattleMonitorHud>
{
    [Header("Player Stats")]
    [SerializeField] PlayerActive playerActive;
    [SerializeField] Slider playerHpBar;

    [Header("Boss Stats")]
    [SerializeField] EnemyActive enemyActive;
    [SerializeField] Slider bossHpBar;


    private void OnEnable()
    {
        playerActive = FindFirstObjectByType<PlayerActive>();
        enemyActive = FindFirstObjectByType<EnemyActive>();
    }

    #region SetUp
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

        if (enemyActive != null)
        {
            UpdateBossHealth(enemyActive.Health, enemyActive.MaxHealth);
            enemyActive.OnHealthChanged += UpdateBossHealth;
        }
    } 

    private void OnDisable()
    {
        if (playerActive != null)
        {
            playerActive.OnHealthChanged -= UpdatePlayerHealth;
        }

        if (enemyActive != null)
        {
            enemyActive.OnHealthChanged -= UpdateBossHealth;
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
    #endregion
}

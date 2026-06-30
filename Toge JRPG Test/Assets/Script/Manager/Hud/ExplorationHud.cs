using UnityEngine;
using UnityEngine.UI;

public class ExplorationHud : MonoBehaviour
{
    [SerializeField] Slider playerHpBar;
    [SerializeField] PlayerActive player;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerActive>();
    }

    private void OnEnable()
    {
        if (player != null)
        {
            UpdateHealthBar(player.Health, player.MaxHealth);
            player.OnHealthChanged += UpdateHealthBar;
        }
    }

    private void OnDisable()
    {
        if (player != null)
        {
            player.OnHealthChanged -= UpdateHealthBar;
        }
    }

    void UpdateHealthBar(int currentHp, int maxHp)
    {
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = currentHp;
    }
}

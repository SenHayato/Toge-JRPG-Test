using UnityEngine;

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState gameState;

    [Header("Battle Manager")]
    [SerializeField] BattleManager battleManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeToExploration()
    {
        if (gameState != GameState.Exploration)
        {
            gameState = GameState.Exploration;
        }
    }
}
